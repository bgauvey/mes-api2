using System.Security.Claims;
using BOL.API.Domain.Models.Util;
using BOL.API.Service.Interfaces.Utilization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bol.api.Controllers.Util
{
    [Route("util/utilstate")]
    [EnableCors("AllowAnyOrigin")]
    public class UtilStateController : ControllerBase
    {
        private readonly IUtilStateService _utilStateService;
        private readonly ILogger _logger;
        public UtilStateController(IUtilStateService UtilStateService, ILoggerFactory loggerFactory)
        {
            _utilStateService = UtilStateService;
            _logger = loggerFactory.CreateLogger(nameof(UtilStateController));
        }

        // GET: api/values
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<UtilState>>> Get()
        {
            try
            {
                var data = await _utilStateService.GetAllAsync();
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // GET api/values/5
        [HttpGet("{stateCd}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UtilState>> Get(int stateCd)
        {
            try
            {
                var data = await _utilStateService.GetAsync(stateCd);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]UtilState utilState)
        {
            try
            {
                if (utilState == null)
                    return BadRequest();

                utilState.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    utilState.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                await _utilStateService.CreateAsync(utilState);
                return Created();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // PUT api/values/5
        [HttpPut("{stateCd}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int stateCd, [FromBody]UtilState utilState)
        {
            try
            {
                if (stateCd != utilState.StateCd)
                    return BadRequest("StateCd mismatch");

                var utilStateToUpdate = await _utilStateService.GetAsync(stateCd);

                if (utilStateToUpdate == null)
                    return NotFound($"UtilState with StateCd = {stateCd} not found");

                utilState.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    utilState.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                var data = await _utilStateService.UpdateAsync(utilState);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{stateCd}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int stateCd)
        {
            try
            {
                var utilStateToDelete = await _utilStateService.GetAsync(stateCd);

                if (utilStateToDelete == null)
                    return NotFound($"UtilState with StateCd = {stateCd} not found");

                var data = await _utilStateService.DeleteAsync(utilStateToDelete);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}

