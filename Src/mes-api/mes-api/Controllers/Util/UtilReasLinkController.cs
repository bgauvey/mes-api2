using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BOL.API.Domain.Models.Util;
using BOL.API.Service.Interfaces.Utilization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bol.api.Controllers.Util
{
    [Route("util/utilreaslink")]
    [EnableCors("AllowAnyOrigin")]
    public class UtilReasLinkController : ControllerBase
    {
        private readonly IUtilReasLinkService _utilReasLinkService;
        private readonly ILogger _logger;

        public UtilReasLinkController(IUtilReasLinkService utilReasLinkService, ILoggerFactory loggerFactory)
        {
            _utilReasLinkService = utilReasLinkService;
            _logger = loggerFactory.CreateLogger(nameof(UtilReasLinkController));
        }

        // GET: api/values
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UtilReasLink>>> Get()
        {
            try
            {
                var data = await _utilReasLinkService.GetAllAsync();
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // GET api/values/5
        [HttpGet("{rowId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UtilReasLink>> Get(int rowId)
        {
            try
            {
                var data = await _utilReasLinkService.GetAsync(rowId);
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
        public async Task<IActionResult> Post([FromBody] UtilReasLink utilReasLink)
        {
            try
            {
                if (utilReasLink == null)
                    return BadRequest();

                utilReasLink.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    utilReasLink.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                await _utilReasLinkService.CreateAsync(utilReasLink);
                return Created();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // PUT api/values/5
        [HttpPut("{rowId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int rowId, [FromBody] UtilReasLink utilReasLink)
        {
            try
            {
                if (rowId != utilReasLink.RowId)
                    return BadRequest("StateCd mismatch");

                var utilReasLinkToUpdate = await _utilReasLinkService.GetAsync(rowId);

                if (utilReasLinkToUpdate == null)
                    return NotFound($"UtilReasLink with RowId = {rowId} not found");

                utilReasLink.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    utilReasLink.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                var data = await _utilReasLinkService.UpdateAsync(utilReasLink);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{rowId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int rowId)
        {
            try
            {
                var utilReasLinkToDelete = await _utilReasLinkService.GetAsync(rowId);

                if (utilReasLinkToDelete == null)
                    return NotFound($"UtilReasLink with RowId = {rowId} not found");

                var data = await _utilReasLinkService.DeleteAsync(utilReasLinkToDelete);
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

