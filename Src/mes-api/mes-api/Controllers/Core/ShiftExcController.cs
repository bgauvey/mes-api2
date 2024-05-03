using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using BOL.API.Service.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bol.api.Controllers.Core
{
    [Route("core/shiftexc")]
    [EnableCors("AllowAnyOrigin")]
    public class ShiftExcController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IShiftExcService _shiftExcService;

        public ShiftExcController(IShiftExcService shiftExcService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ShiftExcController));
            _shiftExcService = shiftExcService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ShiftExc>> Get()
        {
            try
            { 
                var shiftExcs = _shiftExcService.GetAll();
                return Ok(shiftExcs);
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
        public ActionResult<ShiftExc> Get(int id)
        {
            try
            {
                var shiftExc = _shiftExcService.GetById(id);
                return Ok(shiftExc);

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
        public IActionResult Post([FromBody] ShiftExc shiftExc)
        {
            try
            {
                if (shiftExc == null)
                    return BadRequest();

                shiftExc.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    shiftExc.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _shiftExcService.Create(shiftExc);
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
        public IActionResult Put(int id, [FromBody] ShiftExc shiftExc)
        {
            try
            {
                if (id != shiftExc.RowId)
                    return BadRequest("RowId mismatch");

                var shiftExcToUpdate = _shiftExcService.GetById(id);

                if (shiftExcToUpdate == null)
                    return NotFound($"ShiftExc with RowId = {id} not found");

                shiftExc.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    shiftExc.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _shiftExcService.Update(shiftExc);
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
                var shiftExcToDelete = _shiftExcService.GetById(id);

                if (shiftExcToDelete == null)
                    return NotFound($"ShiftExc with RowId = {id} not found");

                _shiftExcService.Delete(id);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// Returns a list of all shift exceptions in a given date range.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpGet("GetExceptions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetExceptionsAsync(DateTime startTime, DateTime endTime)
        {
            try
            {
                var data = await _shiftExcService.GetExceptionsAsync(startTime, endTime);

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

