using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("attr")]
    [EnableCors("AllowAnyOrigin")]
    public class AttrController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAttrService _attrService;

        public AttrController(IAttrService attrService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(EntController));
            _attrService = attrService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Attr>> Get()
        {
            try
            { 
                var attrs = _attrService.GetAll();
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
        public ActionResult<Attr> Get(int id)
        {
            try
            {
                var attr = _attrService.GetById(id);
                return Ok(attr);

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
        public IActionResult Post([FromBody] Attr attr)
        {
            try
            {
                if (attr == null)
                    return BadRequest();

                attr.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    attr.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _attrService.Create(attr);
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
        public IActionResult Put(int id, [FromBody] Attr attr)
        {
            try
            {
                if (id != attr.AttrId)
                    return BadRequest("EntId mismatch");

                var attrToUpdate = _attrService.GetById(id);

                if (attrToUpdate == null)
                    return NotFound($"Attribute with AttrId = {id} not found");

                attr.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    attr.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _attrService.Update(attr);
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
                var attrToDelete = _attrService.GetById(id);

                if (attrToDelete == null)
                    return NotFound($"Attribute with AttrId = {id} not found");

                _attrService.Delete(id);
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

