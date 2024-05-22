using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("prod/jobevent")]
    [EnableCors("AllowAnyOrigin")]
    public class JobEventController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobEventService _jobEventService;

        public JobEventController(IJobEventService jobEventService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(JobEventController));
            _jobEventService = jobEventService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<JobEvent>> Get()
        {
            try
            { 
                var jobEvents = _jobEventService.GetAll();
                return Ok(jobEvents);
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
        public ActionResult<JobEvent> Get(string id)
        {
            try
            {
                var jobEvent = _jobEventService.GetById(id);
                return Ok(jobEvent);

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
        public IActionResult Post([FromBody] JobEvent jobEvent)
        {
            try
            {
                if (jobEvent == null)
                    return BadRequest();

                jobEvent.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    jobEvent.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _jobEventService.Create(jobEvent);
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
        public IActionResult Put(string id, [FromBody] JobEvent jobEvent)
        {
            try
            {
                if (!jobEvent.RowId.Equals(id))
                    return BadRequest("RowId mismatch");

                var jobEventToUpdate = _jobEventService.GetById(id);

                if (jobEventToUpdate == null)
                    return NotFound($"JobEvent with RowId = {id} not found");

                jobEvent.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    jobEvent.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _jobEventService.Update(jobEvent);
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
                var jobEventToDelete = _jobEventService.GetById(id);

                if (jobEventToDelete == null)
                    return NotFound($"JobEvent with RowId = {id} not found");

                _jobEventService.Delete(id);
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

