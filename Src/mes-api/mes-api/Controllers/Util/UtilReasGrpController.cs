using System.Security.Claims;
using BOL.API.Domain.Models.Util;
using BOL.API.Service.Interfaces.Utilization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bol.api.Controllers.Util
{
    [Route("util/utilreasgrp")]
    [EnableCors("AllowAnyOrigin")]
    public class UtilReasGrpController : ControllerBase
    {
        private readonly IUtilReasGrpService _utilReasGrpService;
        private readonly ILogger _logger;

        public UtilReasGrpController(IUtilReasGrpService utilReasGrpService, ILoggerFactory loggerFactory)
        {
            _utilReasGrpService = utilReasGrpService;
            _logger = loggerFactory.CreateLogger(nameof(UtilReasGrpController));
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UtilReasGrp>>> Get()
        {
            try
            {
                var data = await _utilReasGrpService.GetAllAsync();
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // GET api/values/5
        [HttpGet("{reasGrpId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UtilReasGrp>> Get(int reasGrpId)
        {
            try
            {
                var data = await _utilReasGrpService.GetAsync(reasGrpId);
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
        public async Task<IActionResult> Post([FromBody] UtilReasGrp utilReasGrp)
        {
            try
            {
                if (utilReasGrp == null)
                    return BadRequest();

                utilReasGrp.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    utilReasGrp.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                await _utilReasGrpService.CreateAsync(utilReasGrp);
                return Created();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // PUT api/values/5
        [HttpPut("{reasGrpId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int reasGrpId, [FromBody] UtilReasGrp utilReasGrp)
        {
            try
            {
                if (reasGrpId != utilReasGrp.ReasGrpId)
                    return BadRequest("StateCd mismatch");

                var utilStateToUpdate = await _utilReasGrpService.GetAsync(reasGrpId);

                if (utilStateToUpdate == null)
                    return NotFound($"UtilReasGrp with ReasGrpId = {reasGrpId} not found");

                utilReasGrp.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    utilReasGrp.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                var data = await _utilReasGrpService.UpdateAsync(utilReasGrp);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{reasGrpId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int reasGrpId)
        {
            try
            {
                var utilStateToDelete = await _utilReasGrpService.GetAsync(reasGrpId);

                if (utilStateToDelete == null)
                    return NotFound($"UtilReasGrp with ReasGrpId = {reasGrpId} not found");

                var data = await _utilReasGrpService.DeleteAsync(utilStateToDelete);
                return NoContent();
            }
            catch(Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}

