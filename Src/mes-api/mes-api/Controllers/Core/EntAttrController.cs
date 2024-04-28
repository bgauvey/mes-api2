using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/entattr")]
    [EnableCors("AllowAnyOrigin")]
    public class EntAttrController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IEntAttrService _entAttrService;

        public EntAttrController(IEntAttrService entAttrService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(EntController));
            _entAttrService = entAttrService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<EntAttr>> Get()
        {
            try
            { 
                var attrs = _entAttrService.GetAll();
                return Ok(attrs);
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
        public ActionResult<EntAttr> Get(int id)
        {
            try
            {
                var entAttr = _entAttrService.GetById(id);
                return Ok(entAttr);

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
        public IActionResult Post([FromBody] EntAttr entAttr)
        {
            try
            {
                if (entAttr == null)
                    return BadRequest();

                entAttr.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    entAttr.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _entAttrService.Create(entAttr);
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
        public IActionResult Put(int id, [FromBody] EntAttr entAttr)
        {
            try
            {
                if (id != entAttr.RowId)
                    return BadRequest("RowId mismatch");

                var entAttrToUpdate = _entAttrService.GetById(id);

                if (entAttrToUpdate == null)
                    return NotFound($"Entity Attribute with EowId = {id} not found");

                entAttr.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    entAttr.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _entAttrService.Update(entAttr);
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
                var entAttrToDelete = _entAttrService.GetById(id);

                if (entAttrToDelete == null)
                    return NotFound($"Entity Attribute with RowId = {id} not found");

                _entAttrService.Delete(id);
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

