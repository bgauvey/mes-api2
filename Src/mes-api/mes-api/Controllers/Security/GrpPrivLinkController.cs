using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Security;
using BOL.API.Service.Interfaces.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("security/grpprivlink")]
    [EnableCors("AllowAnyOrigin")]
    public class GrpPrivLinkController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IGrpPrivLinkService _grpPrivLinkService;

        public GrpPrivLinkController(IGrpPrivLinkService grpPrivLinkService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(GrpPrivLinkController));
            _grpPrivLinkService = grpPrivLinkService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<GrpPrivLink>> Get()
        {
            try
            { 
                var grpPrivLinks = _grpPrivLinkService.GetAll();
                return Ok(grpPrivLinks);
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
        public ActionResult<GrpPrivLink> Get(int id)
        {
            try
            {
                var grpPrivLink = _grpPrivLinkService.GetById(id);
                return Ok(grpPrivLink);

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
        public IActionResult Post([FromBody] GrpPrivLink grpPrivLink)
        {
            try
            {
                if (grpPrivLink == null)
                    return BadRequest();

                grpPrivLink.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    grpPrivLink.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _grpPrivLinkService.Create(grpPrivLink);
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
        public IActionResult Put(int id, [FromBody] GrpPrivLink grpPrivLink)
        {
            try
            {
                if (id != grpPrivLink.RowId)
                    return BadRequest("RowId mismatch");

                var grpPrivLinkToUpdate = _grpPrivLinkService.GetById(id);

                if (grpPrivLinkToUpdate == null)
                    return NotFound($"GrpPrivLink with RowId = {id} not found");

                grpPrivLink.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    grpPrivLink.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _grpPrivLinkService.Update(grpPrivLink);
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
                var grpPrivLinkToDelete = _grpPrivLinkService.GetById(id);

                if (grpPrivLinkToDelete == null)
                    return NotFound($"GrpPrivLink with RowId = {id} not found");

                _grpPrivLinkService.Delete(id);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        /// <summary>
        /// To return a specific privilege access levels for a given user. 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="privId"></param>
        /// <returns></returns>
        [HttpGet("GetPriv", Name = "GetPriv")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GrpPrivLink> GetPrivAsync(string userId, int privId)
        {
            try
            {
                var grpPrivLink = _grpPrivLinkService.GetPrivAsync(userId, privId);
                return Ok(grpPrivLink);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return all defined privilege access levels for a given user. 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("GetPrivilegesByUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GrpPrivLink> GetPrivilegesByUserAsync(string userId)
        {
            try
            {
                var grpPrivLink = _grpPrivLinkService.GetPrivilegesByUserAsync(userId);
                return Ok(grpPrivLink);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return all defined user’s access levels for a given privilege. 
        /// </summary>
        /// <param name="privId"></param>
        /// <returns></returns>
        [HttpGet("GetUsersByPrivilege/{privId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GrpPrivLink> GetUsersByPrivilegeAsync(int privId)
        {
            try
            {
                var grpPrivLink = _grpPrivLinkService.GetUsersByPrivilegeAsync(privId);
                return Ok(grpPrivLink);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}

