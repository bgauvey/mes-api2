using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/mailgrpmember")]
    [EnableCors("AllowAnyOrigin")]
    public class MailGrpMemberController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMailGrpMemberService _mailGrpMemberService;

        public MailGrpMemberController(IMailGrpMemberService mailGrpMemberService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(MailGrpMemberController));
            _mailGrpMemberService = mailGrpMemberService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<MailGrpMember>> Get()
        {
            try
            { 
                var mailGrpMembers = _mailGrpMemberService.GetAll();
                return Ok(mailGrpMembers);
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
        public ActionResult<MailGrpMember> Get(int id)
        {
            try
            {
                var mailGrpMember = _mailGrpMemberService.GetById(id);
                return Ok(mailGrpMember);

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
        public IActionResult Post([FromBody] MailGrpMember mailGrpMember)
        {
            try
            {
                if (mailGrpMember == null)
                    return BadRequest();

                mailGrpMember.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    mailGrpMember.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _mailGrpMemberService.Create(mailGrpMember);
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
        public IActionResult Put(int id, [FromBody] MailGrpMember mailGrpMember)
        {
            try
            {
                if (id != mailGrpMember.Id)
                    return BadRequest("Id mismatch");

                var mailGrpMemberToUpdate = _mailGrpMemberService.GetById(id);

                if (mailGrpMemberToUpdate == null)
                    return NotFound($"MailGrpMember with Id = {id} not found");

                mailGrpMember.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    mailGrpMember.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _mailGrpMemberService.Update(mailGrpMember);
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
                var mailGrpMemberToDelete = _mailGrpMemberService.GetById(id);

                if (mailGrpMemberToDelete == null)
                    return NotFound($"MailGrpMember with Id = {id} not found");

                _mailGrpMemberService.Delete(id);
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

