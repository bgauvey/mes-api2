using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/uiconfigdefault")]
    [EnableCors("AllowAnyOrigin")]
    public class UiConfigDefaultController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUiConfigDefaultService _uiConfigDefaultService;

        public UiConfigDefaultController(IUiConfigDefaultService uiConfigDefaultService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(UiConfigDefaultController));
            _uiConfigDefaultService = uiConfigDefaultService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<UiConfigDefault>> Get()
        {
            try
            { 
                var uiConfigDefaults = _uiConfigDefaultService.GetAll();
                return Ok(uiConfigDefaults);
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
        public ActionResult<UiConfigDefault> Get(int id)
        {
            try
            {
                var uiConfigDefault = _uiConfigDefaultService.GetById(id);
                return Ok(uiConfigDefault);

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
        public IActionResult Post([FromBody] UiConfigDefault uiConfigDefault)
        {
            try
            {
                if (uiConfigDefault == null)
                    return BadRequest();

                uiConfigDefault.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    uiConfigDefault.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _uiConfigDefaultService.Create(uiConfigDefault);
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
        public IActionResult Put(int id, [FromBody] UiConfigDefault uiConfigDefault)
        {
            try
            {
                if (id != uiConfigDefault.RowId)
                    return BadRequest("RowId mismatch");

                var uiConfigDefaultToUpdate = _uiConfigDefaultService.GetById(id);

                if (uiConfigDefaultToUpdate == null)
                    return NotFound($"UiConfigDefault with RowId = {id} not found");

                uiConfigDefault.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    uiConfigDefault.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _uiConfigDefaultService.Update(uiConfigDefault);
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
                var uiConfigDefaultToDelete = _uiConfigDefaultService.GetById(id);

                if (uiConfigDefaultToDelete == null)
                    return NotFound($"UiConfigDefault with RowId = {id} not found");

                _uiConfigDefaultService.Delete(id);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To save multiple configuration parameters for a given screen and section. The parameters are submitted as an XML string
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        [HttpPut("SaveSectionParams", Name = "SaveSectionParams")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public async Task<IActionResult> SaveSectionParamsAsync([FromBody] string jsonData)
        {
            try
            {
                var result = await _uiConfigDefaultService.SaveSectionParamsAsync(jsonData);
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

