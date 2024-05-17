using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("prod/uom")]
    [EnableCors("AllowAnyOrigin")]
    public class UomController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUomService _uomService;

        public UomController(IUomService uomService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(UomController));
            _uomService = uomService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get()
        {
            try
            { 
                var uoms = await _uomService.GetAllAsync();
                return Ok(uoms);
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
                var uom = await _uomService.GetByIdAsync(id);
                return Ok(uom);

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
        public async Task<ActionResult> Post([FromBody] Uom uom)
        {
            try
            {
                if (uom == null)
                    return BadRequest();

                uom.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    uom.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                await _uomService.CreateAsync(uom);
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
        public async Task<ActionResult> Put(int id, [FromBody] Uom uom)
        {
            try
            {
                if (id != uom.UomId)
                    return BadRequest("UomId mismatch");

                var uomToUpdate = _uomService.GetByIdAsync(id);

                if (uomToUpdate == null)
                    return NotFound($"Uom with UomId = {id} not found");

                uom.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    uom.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                await _uomService.UpdateAsync(uom);
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
                var uomToDelete = _uomService.GetByIdAsync(id);

                if (uomToDelete == null)
                    return NotFound($"Uom with UomId = {id} not found");

                await _uomService.DeleteAsync(id);
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

