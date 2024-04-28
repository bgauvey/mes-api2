using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/systemattr")]
    [EnableCors("AllowAnyOrigin")]
    public class SystemAttrController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISystemAttrService _systemAttrService;

        public SystemAttrController(ISystemAttrService systemAttrService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(EntController));
            _systemAttrService = systemAttrService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<SystemAttr>> Get()
        {
            try
            { 
                var systemAttrs = _systemAttrService.GetAll();
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
                var systemAttr = _systemAttrService.GetById(id);
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
        public IActionResult Post([FromBody] SystemAttr systemAttr)
        {
            try
            {
                if (systemAttr == null)
                    return BadRequest();

                systemAttr.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    systemAttr.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _systemAttrService.Create(systemAttr);
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
        public IActionResult Put(int id, [FromBody] SystemAttr systemAttr)
        {
            try
            {
                if (id != systemAttr.AttrId)
                    return BadRequest("AttrId mismatch");

                var systemAttrToUpdate = _systemAttrService.GetById(id);

                if (systemAttrToUpdate == null)
                    return NotFound($"System Attribute with AttrId = {id} not found");

                systemAttr.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    systemAttr.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _systemAttrService.Update(systemAttr);
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
                var systemAttrToDelete = _systemAttrService.GetById(id);

                if (systemAttrToDelete == null)
                    return NotFound($"System Attribute with AttrId = {id} not found");

                _systemAttrService.Delete(id);
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

