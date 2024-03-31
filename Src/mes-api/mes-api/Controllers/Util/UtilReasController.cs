using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BOL.API.Domain.Models.Util;
using BOL.API.Service.Interfaces.Utilization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bol.api.Controllers.Util
{
    [Route("util/utilreas")]
    [EnableCors("AllowAnyOrigin")]
    public class UtilReasController : ControllerBase
    {
        private readonly IUtilReasService _utilReasService;
        private readonly ILogger _logger;
        public UtilReasController(IUtilReasService UtilReasService, ILoggerFactory loggerFactory)
        {
            _utilReasService = UtilReasService;
            _logger = loggerFactory.CreateLogger(nameof(UtilReasController));
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<UtilReas>>> Get()
        {
            try
            {
                var data = await _utilReasService.GetAllAsync();
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // GET api/values/5
        [HttpGet("{ReasCd}")]
        public async Task<ActionResult<UtilReas>> Get(int reasCd)
        {
            try
            {
                var data = await _utilReasService.GetAsync(reasCd);
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
        public async Task<IActionResult> Post([FromBody] UtilReas utilReas)
        {
            try
            {
                if (utilReas == null)
                    return BadRequest();

                utilReas.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    utilReas.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                await _utilReasService.CreateAsync(utilReas);
                return Created();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // PUT api/values/5
        [HttpPut("{reasCd}")]
        public async Task<IActionResult> Put(int reasCd, [FromBody] UtilReas utilReas)
        {
            try
            {
                if (reasCd != utilReas.ReasCd)
                    return BadRequest("ReasCd mismatch");

                var utilReasToUpdate = await _utilReasService.GetAsync(reasCd);

                if (utilReasToUpdate == null)
                    return NotFound($"UtilReas with ReasCd = {reasCd} not found");

                utilReas.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    utilReas.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                var data = await _utilReasService.UpdateAsync(utilReas);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{reasCd}")]
        public async Task<IActionResult> Delete(int reasCd)
        {
            try
            {
                var utilReasToDelete = await _utilReasService.GetAsync(reasCd);

                if (utilReasToDelete == null)
                    return NotFound($"UtilReas with ReasCd = {reasCd} not found");

                var data = await _utilReasService.DeleteAsync(utilReasToDelete);
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

