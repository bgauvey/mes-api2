
using BOL.API.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Auth;

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

    [HttpPost("logoff")]
    public async Task<int> LogOff(int? EntId)
    {
        return await _authorizationService.LogOff(EntId);
    }

    [HttpPost("changepassword")]
    public async Task<int> ChangePassword(string userId, string oldPassword, string newPassword)
    {
        return await _authorizationService.ChangePassword(userId, oldPassword, newPassword);
    }

    [HttpPost("logonent")]
    [ProducesResponseType(typeof(string), 200)]
    [ProducesResponseType(typeof(string), 400)]
    public async Task<int> LogOnEnt(int EntId, int? CurlabCd, int? CurDeptId, double? PctLabToApply)
    {
        return await _authorizationService.LogOnEnt(EntId, CurlabCd, CurDeptId, PctLabToApply);
    }
}

