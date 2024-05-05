using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/emailatt")]
    [EnableCors("AllowAnyOrigin")]
    public class EmailattController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IEmailattService _emailattService;

        public EmailattController(IEmailattService emailattService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(EmailattController));
            _emailattService = emailattService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Emailatt>> Get()
        {
            try
            { 
                var emailatts = _emailattService.GetAll();
                return Ok(emailatts);
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
        public ActionResult<Emailatt> Get(int id)
        {
            try
            {
                var emailatt = _emailattService.GetById(id);
                return Ok(emailatt);

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
        public IActionResult Post([FromBody] Emailatt emailatt)
        {
            try
            {
                if (emailatt == null)
                    return BadRequest();

                emailatt.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    emailatt.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _emailattService.Create(emailatt);
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
        public IActionResult Put(int id, [FromBody] Emailatt emailatt)
        {
            try
            {
                if (id != emailatt.RowId)
                    return BadRequest("RowId mismatch");

                var emailattToUpdate = _emailattService.GetById(id);

                if (emailattToUpdate == null)
                    return NotFound($"Emailatt with RowId = {id} not found");

                emailatt.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    emailatt.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _emailattService.Update(emailatt);
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
                var emailattToDelete = _emailattService.GetById(id);

                if (emailattToDelete == null)
                    return NotFound($"Emailatt with RowId = {id} not found");

                _emailattService.Delete(id);
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

