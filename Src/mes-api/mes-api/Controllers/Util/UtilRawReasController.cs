using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BOL.API.Domain.Models.Util;
using BOL.API.Service.Interfaces.Utilization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bol.api.Controllers.Util
{
    [Route("util/utilrawreas")]
    public class UtilRawReasController : Controller
    {
        private readonly IUtilRawReasService _utilRawReasService;
        private readonly ILogger _logger;
        public UtilRawReasController(IUtilRawReasService UtilRawReasService, ILoggerFactory loggerFactory)
        {
            _utilRawReasService = UtilRawReasService;
            _logger = loggerFactory.CreateLogger(nameof(UtilRawReasController));
        }

        // GET: api/values
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<UtilRawReas>>> Get()
        {
            try
            {
                var data = await _utilRawReasService.GetAllAsync();
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
        public async Task<ActionResult<UtilRawReas>> Get(int rowId)
        {
            try
            {
                var data = await _utilRawReasService.GetAsync(rowId);
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
        public async Task<IActionResult> Post([FromBody] UtilRawReas utilRawReas)
        {
            try
            {
                if (utilRawReas == null)
                    return BadRequest();

                utilRawReas.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    utilRawReas.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                await _utilRawReasService.CreateAsync(utilRawReas);
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
        public async Task<IActionResult> Put(int rowId, [FromBody] UtilRawReas utilRawReas)
        {
            try
            {
                if (rowId != utilRawReas.RowId)
                    return BadRequest("ReasCd mismatch");

                var utilRawReasToUpdate = await _utilRawReasService.GetAsync(rowId);

                if (utilRawReasToUpdate == null)
                    return NotFound($"UtilRawReas with RowId = {rowId} not found");

                utilRawReas.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    utilRawReas.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                var data = await _utilRawReasService.UpdateAsync(utilRawReas);
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
                var UtilRawReasToDelete = await _utilRawReasService.GetAsync(rowId);

                if (UtilRawReasToDelete == null)
                    return NotFound($"UtilRawReas with RowId = {rowId} not found");

                var data = await _utilRawReasService.DeleteAsync(UtilRawReasToDelete);
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

