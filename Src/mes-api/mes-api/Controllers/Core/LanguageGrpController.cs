using System.Net.Mime;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/systemattrgrp")]
    [EnableCors("AllowAnyOrigin")]
    public class LanguageGrpController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILanguageGrpService _languageGrpService;

        public LanguageGrpController(ILanguageGrpService languageGrpService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(EntController));
            _languageGrpService = languageGrpService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Language>> Get()
        {
            try
            { 
                var languages = _languageGrpService.GetAll();
                return Ok(languages);
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
        public ActionResult<Language> Get(int id)
        {
            try
            {
                var language = _languageGrpService.GetById(id);
                return Ok(language);

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
        public IActionResult Post([FromBody] LanguageGrp languageGrp)
        {
            try
            {
                if (languageGrp == null)
                    return BadRequest();

                _languageGrpService.Create(languageGrp);
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
        public IActionResult Put(int id, [FromBody] LanguageGrp languageGrp)
        {
            try
            {
                if (id != languageGrp.GrpId)
                    return BadRequest("GrpId mismatch");

                var languageToUpdate = _languageGrpService.GetById(id);

                if (languageToUpdate == null)
                    return NotFound($"Language Group with GrpId = {id} not found");

                _languageGrpService.Update(languageGrp);
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
                var languageGrpToDelete = _languageGrpService.GetById(id);

                if (languageGrpToDelete == null)
                    return NotFound($"Language Group with GrpId = {id} not found");

                _languageGrpService.Delete(id);
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

