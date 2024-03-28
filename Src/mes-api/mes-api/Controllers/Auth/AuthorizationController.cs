
using BOL.API.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Auth
{
    [Route("auth")]
    public class AuthorizationController : ControllerBase
    {
        private readonly BOL.API.Service.Interfaces.IAuthorizationService _authorizationService;
        private readonly ILogger _logger;

        public AuthorizationController(BOL.API.Service.Interfaces.IAuthorizationService authorizationService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(AuthorizationController));
            _authorizationService = authorizationService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] AuthenticateModel model)
        {
            try
            {
                User user = await _authorizationService.Login(model);

                if (user == null)
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }

                return Ok(user.Token);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("logoff")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> LogOff(int? EntId)
        {
            try
            {
                return await _authorizationService.LogOff(EntId);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("changepassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> ChangePassword(string userId, string oldPassword, string newPassword)
        {
            try
            {
                return await _authorizationService.ChangePassword(userId, oldPassword, newPassword);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("logonent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> LogOnEnt(int EntId, int? CurlabCd, int? CurDeptId, double? PctLabToApply)
        {
            try
            {
                return await _authorizationService.LogOnEnt(EntId, CurlabCd, CurDeptId, PctLabToApply);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}