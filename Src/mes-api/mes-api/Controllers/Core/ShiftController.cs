using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/shift")]
    [EnableCors("AllowAnyOrigin")]
    public class ShiftController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ShiftController));
            _shiftService = shiftService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Shift>> Get()
        {
            try
            { 
                var shifts = _shiftService.GetAll();
                return Ok(shifts);
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
        public ActionResult<Shift> Get(int id)
        {
            try
            {
                var shift = _shiftService.GetById(id);
                return Ok(shift);

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
        public IActionResult Post([FromBody] Shift shift)
        {
            try
            {
                if (shift == null)
                    return BadRequest();

                shift.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    shift.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _shiftService.Create(shift);
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
        public IActionResult Put(int id, [FromBody] Shift shift)
        {
            try
            {
                if (id != shift.ShiftId)
                    return BadRequest("ShiftId mismatch");

                var shiftToUpdate = _shiftService.GetById(id);

                if (shiftToUpdate == null)
                    return NotFound($"Shift with ShiftId = {id} not found");

                shift.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    shift.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _shiftService.Update(shift);
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
                var shiftToDelete = _shiftService.GetById(id);

                if (shiftToDelete == null)
                    return NotFound($"Shift with ShiftId = {id} not found");

                _shiftService.Delete(id);
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

