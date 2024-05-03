using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Security;
using BOL.API.Service.Interfaces.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("security/grpentlink")]
    [EnableCors("AllowAnyOrigin")]
    public class GrpEntLinkController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IGrpEntLinkService _grpEntLinkService;

        public GrpEntLinkController(IGrpEntLinkService grpEntLinkService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(GrpEntLinkController));
            _grpEntLinkService = grpEntLinkService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<GrpEntLink>> Get()
        {
            try
            { 
                var grpEntLinks = _grpEntLinkService.GetAll();
                return Ok(grpEntLinks);
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
        public ActionResult<GrpEntLink> Get(int id)
        {
            try
            {
                var grpEntLink = _grpEntLinkService.GetById(id);
                return Ok(grpEntLink);

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
        public IActionResult Post([FromBody] GrpEntLink grpEntLink)
        {
            try
            {
                if (grpEntLink == null)
                    return BadRequest();

                grpEntLink.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    grpEntLink.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _grpEntLinkService.Create(grpEntLink);
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
        public IActionResult Put(int id, [FromBody] GrpEntLink grpEntLink)
        {
            try
            {
                if (id != grpEntLink.RowId)
                    return BadRequest("RowId mismatch");

                var grpEntLinkToUpdate = _grpEntLinkService.GetById(id);

                if (grpEntLinkToUpdate == null)
                    return NotFound($"GrpEntLink with RowId = {id} not found");

                grpEntLink.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    grpEntLink.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _grpEntLinkService.Update(grpEntLink);
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
                var grpEntLinkToDelete = _grpEntLinkService.GetById(id);

                if (grpEntLinkToDelete == null)
                    return NotFound($"GrpEntLink with RowId = {id} not found");

                _grpEntLinkService.Delete(id);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To find out whether a given user group has access rights to a given entity.
        /// </summary>
        /// <param name="grpId"></param>
        /// <param name="entId"></param>
        /// <returns></returns>
        [HttpGet("CanAccess", Name = "CanAccess")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GrpEntLink>> CanAccessAsync(int grpId, int entId)
        {
            try
            {
                var grpEntLink = await _grpEntLinkService.CanAccessAsync(grpId, entId);
                return Ok(grpEntLink);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return all entities and whether a given user has access privileges to them or not. 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("GetEntAccessByUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GrpEntLink>> GetEntAccessByUserAsync(string userId)
        {
            try
            {
                var grpEntLink = await _grpEntLinkService.GetEntAccessByUserAsync(userId);
                return Ok(grpEntLink);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return all defined user groups’ access privileges to the specified entity.
        /// </summary>
        /// <param name="entId"></param>
        /// <returns></returns>
        [HttpGet("GetGrpAccessByEnt/{entId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GrpEntLink>> GetGrpAccessByEntAsync(int entId)
        {
            try
            {
                var grpEntLink = await _grpEntLinkService.GetGrpAccessByEntAsync(entId);
                return Ok(grpEntLink);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return all defined users’ access privileges to the specified entity.
        /// </summary>
        /// <param name="entId"></param>
        /// <returns></returns>
        [HttpGet("GetUserAccessByEnt/{entId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GrpEntLink>> GetUserAccessByEntAsync(int entId)
        {
            try
            {
                var grpEntLink = await _grpEntLinkService.GetUserAccessByEntAsync(entId);
                return Ok(grpEntLink);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}

