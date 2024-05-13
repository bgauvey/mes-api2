using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/uiconfig")]
    [EnableCors("AllowAnyOrigin")]
    public class UiConfigController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUiConfigService _uiConfigService;

        public UiConfigController(IUiConfigService uiConfigService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(UiConfigController));
            _uiConfigService = uiConfigService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<UiConfig>> Get()
        {
            try
            { 
                var uiConfigs = _uiConfigService.GetAll();
                return Ok(uiConfigs);
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
        public ActionResult<UiConfig> Get(int id)
        {
            try
            {
                var uiConfig = _uiConfigService.GetById(id);
                return Ok(uiConfig);

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
        public IActionResult Post([FromBody] UiConfig uiConfig)
        {
            try
            {
                if (uiConfig == null)
                    return BadRequest();

                uiConfig.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    uiConfig.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _uiConfigService.Create(uiConfig);
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
        public IActionResult Put(int id, [FromBody] UiConfig uiConfig)
        {
            try
            {
                if (id != uiConfig.RowId)
                    return BadRequest("RowId mismatch");

                var uiConfigToUpdate = _uiConfigService.GetById(id);

                if (uiConfigToUpdate == null)
                    return NotFound($"UiConfig with RowId = {id} not found");

                uiConfig.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    uiConfig.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _uiConfigService.Update(uiConfig);
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
                var uiConfigToDelete = _uiConfigService.GetById(id);

                if (uiConfigToDelete == null)
                    return NotFound($"UiConfig with RowId = {id} not found");

                _uiConfigService.Delete(id);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To save multiple configuration parameters for a given config_id, screen and section. 
        /// </summary>
        /// <param name="configId"></param>
        /// <param name="screenId"></param>
        /// <param name="sectionId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPut("SaveSectionParams")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public async Task<IActionResult> SaveSectionParamsAsync(string configId, string screenId, string sectionId, string parameters)
        {
            try
            {
                string lastEditBy = null ;
                if (ClaimsPrincipal.Current != null)
                    lastEditBy = ClaimsPrincipal.Current.Identity.Name;

                var result = await _uiConfigService.SaveSectionParamsAsync(configId, screenId, sectionId, parameters, lastEditBy);
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

