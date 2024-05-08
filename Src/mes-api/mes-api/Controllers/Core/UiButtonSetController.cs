using System.Net.Mime;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/uibuttonset")]
    [EnableCors("AllowAnyOrigin")]
    public class UiButtonSetController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUiButtonSetService _uiButtonSetService;

        public UiButtonSetController(IUiButtonSetService uiButtonSetService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(UiButtonSetController));
            _uiButtonSetService = uiButtonSetService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<UiButtonSet>> Get()
        {
            try
            { 
                var uiButtonSets = _uiButtonSetService.GetAll();
                return Ok(uiButtonSets);
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
        public ActionResult<UiButtonSet> Get(int id)
        {
            try
            {
                var uiButtonSet = _uiButtonSetService.GetById(id);
                return Ok(uiButtonSet);

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
        public IActionResult Post([FromBody] UiButtonSet uiButtonSet)
        {
            try
            {
                if (uiButtonSet == null)
                    return BadRequest();

                _uiButtonSetService.Create(uiButtonSet);
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
        public IActionResult Put(int id, [FromBody] UiButtonSet uiButtonSet)
        {
            try
            {
                if (id != uiButtonSet.ButtonId)
                    return BadRequest("ButtonId mismatch");

                var uiButtonSetToUpdate = _uiButtonSetService.GetById(id);

                if (uiButtonSetToUpdate == null)
                    return NotFound($"UiButtonSet with ButtonId = {id} not found");

                _uiButtonSetService.Update(uiButtonSet);
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
                var uiButtonSetToDelete = _uiButtonSetService.GetById(id);

                if (uiButtonSetToDelete == null)
                    return NotFound($"UiButtonSet with ButtonId = {id} not found");

                _uiButtonSetService.Delete(id);
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

