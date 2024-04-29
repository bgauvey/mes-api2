using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/attrset")]
    [EnableCors("AllowAnyOrigin")]
    public class AttrSetController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAttrSetService _attrSetService;

        public AttrSetController(IAttrSetService attrSetService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(AttrSetController));
            _attrSetService = attrSetService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<AttrSet>> Get()
        {
            try
            { 
                var attrSets = _attrSetService.GetAll();
                return Ok(attrSets);
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
        public ActionResult<AttrSet> Get(int id)
        {
            try
            {
                var attrSet = _attrSetService.GetById(id);
                return Ok(attrSet);

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
        public IActionResult Post([FromBody] AttrSet attrSet)
        {
            try
            {
                if (attrSet == null)
                    return BadRequest();

                attrSet.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    attrSet.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _attrSetService.Create(attrSet);
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
        public IActionResult Put(int id, [FromBody] AttrSet attrSet)
        {
            try
            {
                if (id != attrSet.RowId)
                    return BadRequest("RowId mismatch");

                var attrSetToUpdate = _attrSetService.GetById(id);

                if (attrSetToUpdate == null)
                    return NotFound($"AttrSet with RowId = {id} not found");

                attrSet.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    attrSet.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _attrSetService.Update(attrSet);
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
                var attrSetToDelete = _attrSetService.GetById(id);

                if (attrSetToDelete == null)
                    return NotFound($"AttrSetibute with RowId = {id} not found");

                _attrSetService.Delete(id);
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

