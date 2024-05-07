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
    public class FileDescController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IFileDescService _fileDescService;

        public FileDescController(IFileDescService fileDescService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(FileDescController));
            _fileDescService = fileDescService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<FileDesc>> Get()
        {
            try
            { 
                var fileDescs = _fileDescService.GetAll();
                return Ok(fileDescs);
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
        public ActionResult<FileDesc> Get(int id)
        {
            try
            {
                var fileDesc = _fileDescService.GetById(id);
                return Ok(fileDesc);

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
        public IActionResult Post([FromBody] FileDesc fileDesc)
        {
            try
            {
                if (fileDesc == null)
                    return BadRequest();

                fileDesc.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    fileDesc.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _fileDescService.Create(fileDesc);
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
        public IActionResult Put(int id, [FromBody] FileDesc fileDesc)
        {
            try
            {
                if (id != fileDesc.RowId)
                    return BadRequest("RowId mismatch");

                var fileDescToUpdate = _fileDescService.GetById(id);

                if (fileDescToUpdate == null)
                    return NotFound($"FileDesc with RowId = {id} not found");

                fileDesc.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    fileDesc.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _fileDescService.Update(fileDesc);
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
                var fileDescToDelete = _fileDescService.GetById(id);

                if (fileDescToDelete == null)
                    return NotFound($"FileDesc with RowId = {id} not found");

                _fileDescService.Delete(id);
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

