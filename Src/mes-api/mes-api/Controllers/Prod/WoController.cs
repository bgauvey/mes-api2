using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("prod/wo")]
    [EnableCors("AllowAnyOrigin")]
    public class WoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IWoService _woService;

        public WoController(IWoService woService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(WoController));
            _woService = woService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Wo>> Get()
        {
            try
            { 
                var wos = _woService.GetAll();
                return Ok(wos);
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
        public ActionResult<Wo> Get(string id)
        {
            try
            {
                var wo = _woService.GetById(id);
                return Ok(wo);

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
        public IActionResult Post([FromBody] Wo wo)
        {
            try
            {
                if (wo == null)
                    return BadRequest();

                wo.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    wo.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _woService.Create(wo);
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
        public IActionResult Put(string id, [FromBody] Wo wo)
        {
            try
            {
                if (!wo.RowId.Equals(id))
                    return BadRequest("WoId mismatch");

                var woToUpdate = _woService.GetById(id);

                if (woToUpdate == null)
                    return NotFound($"Wo with WoId = {id} not found");

                wo.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    wo.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _woService.Update(wo);
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
        public IActionResult Delete(string id)
        {
            try
            {
                var woToDelete = _woService.GetById(id);

                if (woToDelete == null)
                    return NotFound($"Wo with WoId = {id} not found");

                _woService.Delete(id);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// Return the next available work order ID, formatted according to the system attribute.
        /// </summary>
        /// <param name="nextWoId"></param>
        /// <returns></returns>
        [HttpPut("GetNextWoId", Name = "GetNextWoId")]
        [Authorize]
        public async Task<IActionResult> GetNextWoIdAsync(string nextWoId)
        {
            try
            {
                var data = await _woService.GetNextWoIdAsync(nextWoId);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}

