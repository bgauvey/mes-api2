
using BOL.API.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers;

[Route("auth")]
public class AuthorizationController : ControllerBase
{
    readonly BOL.API.Service.Interfaces.IAuthorizationService _authorizationService;
    readonly ILogger _logger;

    public AuthorizationController(BOL.API.Service.Interfaces.IAuthorizationService authorizationService, ILoggerFactory loggerFactory)
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

