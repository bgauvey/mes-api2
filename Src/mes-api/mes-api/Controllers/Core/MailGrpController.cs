using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/mailgrp")]
    [EnableCors("AllowAnyOrigin")]
    public class MailGrpController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMailGrpService _mailGrpService;

        public MailGrpController(IMailGrpService mailGrpService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(MailGrpController));
            _mailGrpService = mailGrpService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<MailGrp>> Get()
        {
            try
            { 
                var mailGrps = _mailGrpService.GetAll();
                return Ok(mailGrps);
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
        public ActionResult<MailGrp> Get(int id)
        {
            try
            {
                var mailGrp = _mailGrpService.GetById(id);
                return Ok(mailGrp);

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
        public IActionResult Post([FromBody] MailGrp mailGrp)
        {
            try
            {
                if (mailGrp == null)
                    return BadRequest();

                mailGrp.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    mailGrp.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _mailGrpService.Create(mailGrp);
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
        public IActionResult Put(int id, [FromBody] MailGrp mailGrp)
        {
            try
            {
                if (id != mailGrp.Id)
                    return BadRequest("Id mismatch");

                var mailGrpToUpdate = _mailGrpService.GetById(id);

                if (mailGrpToUpdate == null)
                    return NotFound($"MailGrp with Id = {id} not found");

                mailGrp.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    mailGrp.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _mailGrpService.Update(mailGrp);
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
                var mailGrpToDelete = _mailGrpService.GetById(id);

                if (mailGrpToDelete == null)
                    return NotFound($"MailGrp with Id = {id} not found");

                _mailGrpService.Delete(id);
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

