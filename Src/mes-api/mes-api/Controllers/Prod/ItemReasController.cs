using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("prod/itemreas")]
    [EnableCors("AllowAnyOrigin")]
    public class ItemReasController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemReasService _itemReasService;

        public ItemReasController(IItemReasService itemReasService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ItemReasController));
            _itemReasService = itemReasService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ItemReas>> Get()
        {
            try
            { 
                var itemReass = _itemReasService.GetAll();
                return Ok(itemReass);
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
        public ActionResult<ItemReas> Get(string id)
        {
            try
            {
                var itemReas = _itemReasService.GetById(id);
                return Ok(itemReas);

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
        public IActionResult Post([FromBody] ItemReas itemReas)
        {
            try
            {
                if (itemReas == null)
                    return BadRequest();

                itemReas.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemReas.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemReasService.Create(itemReas);
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
        public IActionResult Put(string id, [FromBody] ItemReas itemReas)
        {
            try
            {
                if (!itemReas.ReasCd.Equals(id))
                    return BadRequest("ReasCd mismatch");

                var itemReasToUpdate = _itemReasService.GetById(id);

                if (itemReasToUpdate == null)
                    return NotFound($"ItemReas with ReasCd = {id} not found");

                itemReas.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemReas.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemReasService.Update(itemReas);
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
                var itemReasToDelete = _itemReasService.GetById(id);

                if (itemReasToDelete == null)
                    return NotFound($"ItemReas with ReasCd = {id} not found");

                _itemReasService.Delete(id);
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

