using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BOL.API.Domain.Models.Util;
using BOL.API.Service.Interfaces.Utilization;
using BOL.API.Service.Services.Utilization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bol.api.Controllers.Util
{
    [Route("util/utillog")]
    [EnableCors("AllowAnyOrigin")]
    public class UtilLogController : Controller
    {
        private readonly IUtilLogService _utilLogService;
        private readonly ILogger _logger;
        public UtilLogController(IUtilLogService utilLogService, ILoggerFactory loggerFactory)
        {
            _utilLogService = utilLogService;
            _logger = loggerFactory.CreateLogger(nameof(UtilLogController));
        }


        // GET: api/values
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(DateTime eventTime)
        {
            try
            {
                var data = await _utilLogService.GetAllAsync(eventTime);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // GET api/values/5
        [HttpGet("{logId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UtilLog>> Get(int logId)
        {
            try
            {
                var data = await _utilLogService.GetAsync(logId);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // PUT api/values/5
        [HttpPut("{logId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int logId, [FromBody]UtilLog utilLog)
        {
            try
            { 
                if (logId != utilLog.LogId)
                    return BadRequest("StateCd mismatch");

                var utilLogToUpdate = await _utilLogService.GetAsync(logId);

                if (utilLogToUpdate == null)
                    return NotFound($"UtilLog with LogId = {logId} not found");

                utilLog.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    utilLog.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                var data = await _utilLogService.UpdateAsync(utilLog);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{logId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int logId)
        {
            try
            {
                var utilLogToDelete = await _utilLogService.GetAsync(logId);

                if (utilLogToDelete == null)
                    return NotFound($"UtilLog with LogId = {logId} not found");

                var data = await _utilLogService.DeleteAsync(utilLogToDelete);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("AdjustDuration")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdjustDurationAsync(int entId, DateTime eventTimeLocal, double newDuration)
        {
            try
            {
                var data = await _utilLogService.AdjustDurationAsync(entId, eventTimeLocal, newDuration);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("GetAllByPeriod")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByPeriodAsync(int entId, DateTime startTimeLocal, DateTime endTimeLocal)
        {
            try
            {
                var data = await _utilLogService.GetAllByPeriodAsync(entId, startTimeLocal, endTimeLocal);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("Split")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SplitAsync(int entId, DateTime eventTimeLocal, double newDuration, int shiftId, DateTime shiftStartLocal, int reasCd, bool reasPending, string comments, string rawReasCd)
        {
            try
            {
                var data = await _utilLogService.SplitAsync(entId, eventTimeLocal, newDuration, shiftId, shiftStartLocal, reasCd, reasPending, comments, rawReasCd);
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

