using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("prod/jobschedexec")]
    [EnableCors("AllowAnyOrigin")]
    public class JobSchedExecController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobSchedExecService _jobSchedExecService;

        public JobSchedExecController(IJobSchedExecService jobSchedExecService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(JobSchedExecController));
            _jobSchedExecService = jobSchedExecService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<JobSchedExec>> Get()
        {
            try
            { 
                var jobSchedExecs = _jobSchedExecService.GetAll();
                return Ok(jobSchedExecs);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<JobSchedExec> Get(string id)
        {
            try
            {
                var jobSchedExec = _jobSchedExecService.GetById(id);
                return Ok(jobSchedExec);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // POST api/values
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult Post([FromBody] JobSchedExec jobSchedExec)
        {
            try
            {
                if (jobSchedExec == null)
                    return BadRequest();

                jobSchedExec.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    jobSchedExec.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _jobSchedExecService.Create(jobSchedExec);
                return Created();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult Put(string id, [FromBody] JobSchedExec jobSchedExec)
        {
            try
            {
                if (!jobSchedExec.EntId.Equals(id))
                    return BadRequest("EntId mismatch");

                var jobSchedExecToUpdate = _jobSchedExecService.GetById(id);

                if (jobSchedExecToUpdate == null)
                    return NotFound($"JobSchedExec with EntId = {id} not found");

                jobSchedExec.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    jobSchedExec.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _jobSchedExecService.Update(jobSchedExec);
                return Created();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult Delete(string id)
        {
            try
            {
                var jobSchedExecToDelete = _jobSchedExecService.GetById(id);

                if (jobSchedExecToDelete == null)
                    return NotFound($"JobSchedExec with EntId = {id} not found");

                _jobSchedExecService.Delete(id);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// Deletes the data from Temp_Shift_Exc table.
        /// </summary>
        /// <returns></returns>
        [HttpPut("DropTempShiftExc", Name = "DropTempShiftExc")]
        [Authorize]
        public async Task<IActionResult> DropTempShiftExcAsync()
        {
            try
            {
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => Convert.ToInt32(c.Value)).SingleOrDefault();

                var data = await _jobSchedExecService.DropTempShiftExcAsync(sessionId);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// Refresh the contents of the temporary data in temp_shift_exc table with the contents of the "real" Shift_Exc table.
        /// </summary>
        /// <returns></returns>
        [HttpPut("RefreshTempShiftExc", Name = "RefreshTempShiftExc")]
        [Authorize]
        public async Task<IActionResult> RefreshTempShiftExcAsync()
        {
            try
            {
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => Convert.ToInt32(c.Value)).SingleOrDefault();

                var data = await _jobSchedExecService.RefreshTempShiftExcAsync(sessionId);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To apply the specified schedule in one transaction.
        /// </summary>
        /// <param name="xmlCommand"></param>
        /// <returns></returns>
        [HttpPut("ApplySchedule", Name = "ApplySchedule")]
        [Authorize]
        public async Task<IActionResult> ApplyScheduleAsync(string xmlCommand)
        {
            try
            {
                var data = await _jobSchedExecService.ApplyScheduleAsync(xmlCommand);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}

