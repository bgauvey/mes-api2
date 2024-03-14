
using BOL.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bol.api.Controllers
{
    [Route("auth")]
    public class AuthorizationController : ControllerBase
    {
        readonly BOL.API.Authorization.Services.IAuthorizationService _authorizationService;
        readonly ILogger _logger;

        public AuthorizationController(BOL.API.Authorization.Services.IAuthorizationService authorizationService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(AuthorizationController));
            _authorizationService = authorizationService;
        }

        // POST: auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Login([FromBody] AuthenticateModel model)
        {
            var user = await _authorizationService.Login(model);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user.Token);
        }
    }
}

