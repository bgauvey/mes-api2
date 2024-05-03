using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/shiftsched")]
    [EnableCors("AllowAnyOrigin")]
    public class ShiftSchedController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IShiftSchedService _shiftSchedService;

        public ShiftSchedController(IShiftSchedService shiftSchedService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ShiftSchedController));
            _shiftSchedService = shiftSchedService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ShiftSched>> Get()
        {
            try
            { 
                var shiftScheds = _shiftSchedService.GetAll();
                return Ok(shiftScheds);
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
        public ActionResult<ShiftSched> Get(int id)
        {
            try
            {
                var shiftSched = _shiftSchedService.GetById(id);
                return Ok(shiftSched);

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
        public IActionResult Post([FromBody] ShiftSched shiftSched)
        {
            try
            {
                if (shiftSched == null)
                    return BadRequest();

                shiftSched.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    shiftSched.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _shiftSchedService.Create(shiftSched);
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
        public IActionResult Put(int id, [FromBody] ShiftSched shiftSched)
        {
            try
            {
                if (id != shiftSched.RowId)
                    return BadRequest("RowId mismatch");

                var shiftSchedToUpdate = _shiftSchedService.GetById(id);

                if (shiftSchedToUpdate == null)
                    return NotFound($"Shift Schedule with RowId = {id} not found");

                shiftSched.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    shiftSched.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _shiftSchedService.Update(shiftSched);
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
                var shiftSchedToDelete = _shiftSchedService.GetById(id);

                if (shiftSchedToDelete == null)
                    return NotFound($"Shift Schedule with RowId = {id} not found");

                _shiftSchedService.Delete(id);
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

