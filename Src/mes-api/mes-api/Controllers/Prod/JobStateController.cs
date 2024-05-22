using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("prod/jobstate")]
    [EnableCors("AllowAnyOrigin")]
    public class JobStateController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobStateService _jobStateService;

        public JobStateController(IJobStateService jobStateService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(JobStateController));
            _jobStateService = jobStateService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<JobState>> Get()
        {
            try
            { 
                var jobStates = _jobStateService.GetAll();
                return Ok(jobStates);
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
        public ActionResult<JobState> Get(int id)
        {
            try
            {
                var jobState = _jobStateService.GetById(id);
                return Ok(jobState);

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
        public IActionResult Post([FromBody] JobState jobState)
        {
            try
            {
                if (jobState == null)
                    return BadRequest();

                jobState.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    jobState.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _jobStateService.Create(jobState);
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
        public IActionResult Put(int id, [FromBody] JobState jobState)
        {
            try
            {
                if (id != jobState.StateCd)
                    return BadRequest("StateCd mismatch");

                var jobStateToUpdate = _jobStateService.GetById(id);

                if (jobStateToUpdate == null)
                    return NotFound($"JobState with StateCd = {id} not found");

                jobState.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    jobState.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _jobStateService.Update(jobState);
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
        public IActionResult Delete(int id)
        {
            try
            {
                var jobStateToDelete = _jobStateService.GetById(id);

                if (jobStateToDelete == null)
                    return NotFound($"JobState with StateCd = {id} not found");

                _jobStateService.Delete(id);
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

