using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BOL.API.Domain.Enums;
using BOL.API.Repository.Interfaces.Security;
using BOL.API.Service.Interfaces.Security;
using BOL.API.Service.Models;
using Microsoft.IdentityModel.Tokens;

namespace BOL.API.Service.Services.Security
{

    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserNameRepository _userNameRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserGrpLinkRepository _userGrpLinkRepository;
        private readonly IGrpNameRepository _grpNameRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _Logger;
        private readonly IConfiguration _configuration;

        public AuthorizationService(IUserNameRepository userNameRepository, ISessionRepository sessionRepository, IUserGrpLinkRepository userGrpLinkRepository,
            IGrpNameRepository grpNameRepository, ILoggerFactory loggerFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _userNameRepository = userNameRepository;
            _sessionRepository = sessionRepository;
            _userGrpLinkRepository = userGrpLinkRepository;
            _grpNameRepository = grpNameRepository;
            _Logger = loggerFactory.CreateLogger(nameof(AuthorizationService));
            _configuration = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> Login(AuthenticateModel authenticateModel)
        {
            return await Login(authenticateModel.Username, authenticateModel.Password, authenticateModel.ClientType);
        }

        public async Task<int> LogOff(int? EntId)
        {
            var sessionId = ClaimsPrincipal.Current.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                               .Select(c => c.Value).SingleOrDefault();
            var userId = ClaimsPrincipal.Current.Identity.Name;
            return await _sessionRepository.LogOff(Convert.ToInt32(sessionId), userId, EntId);
        }

        public async Task<int> LogOnEnt(int EntId, int? CurLabCd, int? CurDeptId, double? PctLabToApply)
        {
            if (ClaimsPrincipal.Current != null)
            {
                var sessionId = ClaimsPrincipal.Current.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                                          .Select(c => c.Value).SingleOrDefault();
                var userId = ClaimsPrincipal.Current.Identity.Name;
                return await _sessionRepository.LogOnEnt(Convert.ToInt32(sessionId), userId, EntId, CurLabCd, CurDeptId, PctLabToApply);
            }
            else
            {
                throw new BadHttpRequestException("User can not be null", 400);
            }
        }

        public async Task<int> ChangePassword(string userId, string oldPassword, string newPassword)
        {
            return await _userNameRepository.ChangePassword(userId, oldPassword, newPassword);
        }

        private async Task<User> Login(string userId, string password, ClientType clientType)
        {
            var user = await Task.Run(() =>
            {
                //  create new session
                var data = Authenticate(userId, password);
                if (data != null)
                {
                    var clientIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                    int sessionId = -1;
                    _sessionRepository.Create(clientType, clientIp, ref sessionId);
                    data.SessionId = sessionId;

                    _sessionRepository.Login(sessionId, userId, password);

                    // generate the JWT token
                    data.Token = GetToken(data);
                }
                return data;
            });
            return user;
        }

        private string GetToken(User user)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt").GetValue<string>("Key"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims(user)),
                Expires = DateTime.UtcNow.AddMinutes(10),
                Issuer = _configuration.GetSection("Jwt").GetValue<string>("Issuer"),
                Audience = _configuration.GetSection("Jwt").GetValue<string>("Audience"),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); ;
        }

        private User Authenticate(string userName, string password)
        {
            if (_userNameRepository.GetByCondition(x => x.UserId.Equals(userName)).Count() == 0)
                throw new UnauthorizedAccessException("Username or password invalid");

            var user = _userNameRepository.GetByCondition(x => x.UserId.Equals(userName)).Single();
            if (user?.Pw == password)
            {
                var data = new User()
                {
                    Id = user.RowId,
                    UserName = user.UserId,
                    UserDesc = user.UserDesc
                };

                data.Roles = GetUserRoles(userName);

                return data;
            }
            return null;
        }

        private Claim[] Claims(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.GivenName, user.UserDesc),
            new Claim(ClaimTypes.Sid, user.SessionId.ToString())
        };
            foreach (string role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims.ToArray();
        }

        private string[] GetUserRoles(string userName)
        {
            List<string> roles = new List<string>();

            var userGrpLinks = _userGrpLinkRepository.GetByCondition(x => x.UserId.Equals(userName)).ToList();
            var grpNames = _grpNameRepository.GetAll().ToList();

            var groups = userGrpLinks
                .Join(grpNames,
                u => u.GrpId,
                g => g.GrpId,
                (u, g) => new { u, g })
                .Select(x => x.g.GrpDesc).AsEnumerable();


            foreach (var group in groups)
            {
                roles.Add(group);
            }
            return roles.ToArray();
        }
    }
}