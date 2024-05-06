using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/doctype")]
    [EnableCors("AllowAnyOrigin")]
    public class DocTypeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IDocTypeService _docTypeService;

        public DocTypeController(IDocTypeService docTypeService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(DocTypeController));
            _docTypeService = docTypeService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<DocType>> Get()
        {
            try
            { 
                var docTypes = _docTypeService.GetAll();
                return Ok(docTypes);
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
        public ActionResult<DocType> Get(int id)
        {
            try
            {
                var docType = _docTypeService.GetById(id);
                return Ok(docType);

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
        public IActionResult Post([FromBody] DocType docType)
        {
            try
            {
                if (docType == null)
                    return BadRequest();

                docType.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    docType.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _docTypeService.Create(docType);
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
        public IActionResult Put(int id, [FromBody] DocType docType)
        {
            try
            {
                if (id != docType.RowId)
                    return BadRequest("RowId mismatch");

                var docTypeToUpdate = _docTypeService.GetById(id);

                if (docTypeToUpdate == null)
                    return NotFound($"DocType with RowId = {id} not found");

                docType.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    docType.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _docTypeService.Update(docType);
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
                var docTypeToDelete = _docTypeService.GetById(id);

                if (docTypeToDelete == null)
                    return NotFound($"DocType with RowId = {id} not found");

                _docTypeService.Delete(id);
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

