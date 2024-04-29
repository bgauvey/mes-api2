using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/systemattrgrp")]
    [EnableCors("AllowAnyOrigin")]
    public class SystemAttrGrpController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISystemAttrGrpService _systemAttrGrpService;

        public SystemAttrGrpController(ISystemAttrGrpService systemAttrGrpService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(SystemAttrGrpController));
            _systemAttrGrpService = systemAttrGrpService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<SystemAttr>> Get()
        {
            try
            { 
                var systemAttrs = _systemAttrGrpService.GetAll();
                return Ok(systemAttrs);
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
        public ActionResult<SystemAttr> Get(int id)
        {
            try
            {
                var systemAttr = _systemAttrGrpService.GetById(id);
                return Ok(systemAttr);

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
        public IActionResult Post([FromBody] SystemAttrGrp systemAttrGrp)
        {
            try
            {
                if (systemAttrGrp == null)
                    return BadRequest();

                _systemAttrGrpService.Create(systemAttrGrp);
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
        public IActionResult Put(int id, [FromBody] SystemAttrGrp systemAttrGrp)
        {
            try
            {
                if (id != systemAttrGrp.GrpId)
                    return BadRequest("GrpId mismatch");

                var systemAttrToUpdate = _systemAttrGrpService.GetById(id);

                if (systemAttrToUpdate == null)
                    return NotFound($"System Attribute Group with GrpId = {id} not found");

                _systemAttrGrpService.Update(systemAttrGrp);
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
                var systemAttrGrpToDelete = _systemAttrGrpService.GetById(id);

                if (systemAttrGrpToDelete == null)
                    return NotFound($"System Attribute Group with GrpId = {id} not found");

                _systemAttrGrpService.Delete(id);
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

