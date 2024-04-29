using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using BOL.API.Service.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/language")]
    [EnableCors("AllowAnyOrigin")]
    public class LanguageController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(LanguageController));
            _languageService = languageService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Language>> Get()
        {
            try
            { 
                var languages = _languageService.GetAll();
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
                var language = _languageService.GetById(id);
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
        public IActionResult Post([FromBody] Language language)
        {
            try
            {
                if (language == null)
                    return BadRequest();

                language.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    language.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _languageService.Create(language);
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
        public IActionResult Put(int id, [FromBody] Language language)
        {
            try
            {
                if (id != language.LangId)
                    return BadRequest("LangId mismatch");

                var languageToUpdate = _languageService.GetById(id);

                if (languageToUpdate == null)
                    return NotFound($"Language with LangId = {id} not found");

                language.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    language.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _languageService.Update(language);
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
                var languageToDelete = _languageService.GetById(id);

                if (languageToDelete == null)
                    return NotFound($"Language with LangId = {id} not found");

                _languageService.Delete(id);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To create a new language (of terminology) by cloning all the defined strings from an existing language.
        /// </summary>
        /// <param name="newLangId"></param>
        /// <param name="clonedLangId"></param>
        /// <param name="newLangDesc"></param>
        /// <returns></returns>
        [HttpPost("Clone")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CloneAsync(int newLangId, int clonedLangId, string newLangDesc)
        {
            try
            {
                var data = await _languageService.CloneAsync(newLangId, clonedLangId, newLangDesc);

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return the first free language ID for a new language.
        /// </summary>
        /// <returns></returns>
        [HttpGet("NextFreeLangId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NextFreeLangIdAsync()
        {
            try
            {
                var data = await _languageService.NextFreeLangIdAsync();

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To delete all strings for a given language from the database.
        /// </summary>
        /// <param name="langId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteByLang/{langId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteByLangAsync(int langId)
        {
            try
            {
                var data = await _languageService.DeleteByLangAsync(langId);

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

