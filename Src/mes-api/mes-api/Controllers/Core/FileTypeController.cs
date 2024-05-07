using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/filetype")]
    [EnableCors("AllowAnyOrigin")]
    public class FileTypeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IFileTypeService _fileTypeService;

        public FileTypeController(IFileTypeService fileTypeService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(FileTypeController));
            _fileTypeService = fileTypeService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<FileType>> Get()
        {
            try
            { 
                var fileTypes = _fileTypeService.GetAll();
                return Ok(fileTypes);
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
        public ActionResult<FileType> Get(int id)
        {
            try
            {
                var fileType = _fileTypeService.GetById(id);
                return Ok(fileType);

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
        public IActionResult Post([FromBody] FileType fileType)
        {
            try
            {
                if (fileType == null)
                    return BadRequest();

                fileType.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    fileType.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _fileTypeService.Create(fileType);
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
        public IActionResult Put(int id, [FromBody] FileType fileType)
        {
            try
            {
                if (id != fileType.RowId)
                    return BadRequest("RowId mismatch");

                var fileTypeToUpdate = _fileTypeService.GetById(id);

                if (fileTypeToUpdate == null)
                    return NotFound($"FileType with RowId = {id} not found");

                fileType.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    fileType.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _fileTypeService.Update(fileType);
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
                var fileTypeToDelete = _fileTypeService.GetById(id);

                if (fileTypeToDelete == null)
                    return NotFound($"FileType with RowId = {id} not found");

                _fileTypeService.Delete(id);
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

