using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("prod/uomconv")]
    [EnableCors("AllowAnyOrigin")]
    public class UomConvController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUomConvService _uomConvService;

        public UomConvController(IUomConvService uomConvService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(UomConvController));
            _uomConvService = uomConvService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get()
        {
            try
            { 
                var uomConvs = await _uomConvService.GetAllAsync();
                return Ok(uomConvs);
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
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var uomConv = await _uomConvService.GetByIdAsync(id);
                return Ok(uomConv);

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
        public async Task<ActionResult> Post([FromBody] UomConv uomConv)
        {
            try
            {
                if (uomConv == null)
                    return BadRequest();

                uomConv.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    uomConv.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                await _uomConvService.CreateAsync(uomConv);
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
        public async Task<ActionResult> Put(int id, [FromBody] UomConv uomConv)
        {
            try
            {
                if (id != uomConv.RowId)
                    return BadRequest("RowId mismatch");

                var uomConvToUpdate = _uomConvService.GetByIdAsync(id);

                if (uomConvToUpdate == null)
                    return NotFound($"UomConv with RowId = {id} not found");

                uomConv.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    uomConv.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                await _uomConvService.UpdateAsync(uomConv);
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
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var uomConvToDelete = _uomConvService.GetByIdAsync(id);

                if (uomConvToDelete == null)
                    return NotFound($"UomConv with RowId = {id} not found");

                await _uomConvService.DeleteAsync(id);
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

