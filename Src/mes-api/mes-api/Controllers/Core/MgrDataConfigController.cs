using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/mgrdataconfig")]
    [EnableCors("AllowAnyOrigin")]
    public class MgrDataConfigController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMgrDataConfigService _mgrDataConfigService;

        public MgrDataConfigController(IMgrDataConfigService mgrDataConfigService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(MgrDataConfigController));
            _mgrDataConfigService = mgrDataConfigService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<MgrDataConfig>> Get()
        {
            try
            { 
                var mgrDataConfigs = _mgrDataConfigService.GetAll();
                return Ok(mgrDataConfigs);
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
        public ActionResult<MgrDataConfig> Get(int id)
        {
            try
            {
                var mgrDataConfig = _mgrDataConfigService.GetById(id);
                return Ok(mgrDataConfig);

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
        public IActionResult Post([FromBody] MgrDataConfig mgrDataConfig)
        {
            try
            {
                if (mgrDataConfig == null)
                    return BadRequest();

                mgrDataConfig.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    mgrDataConfig.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _mgrDataConfigService.Create(mgrDataConfig);
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
        public IActionResult Put(int id, [FromBody] MgrDataConfig mgrDataConfig)
        {
            try
            {
                if (id != mgrDataConfig.RepId)
                    return BadRequest("RepId mismatch");

                var mgrDataConfigToUpdate = _mgrDataConfigService.GetById(id);

                if (mgrDataConfigToUpdate == null)
                    return NotFound($"MgrDataConfig with RepId = {id} not found");

                mgrDataConfig.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    mgrDataConfig.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _mgrDataConfigService.Update(mgrDataConfig);
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
                var mgrDataConfigToDelete = _mgrDataConfigService.GetById(id);

                if (mgrDataConfigToDelete == null)
                    return NotFound($"MgrDataConfig with RepId = {id} not found");

                _mgrDataConfigService.Delete(id);
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

