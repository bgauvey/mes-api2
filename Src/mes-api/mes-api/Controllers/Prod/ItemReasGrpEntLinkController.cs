using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using BOL.API.Service.Services.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("prod/itemreasGrpEntLink")]
    [EnableCors("AllowAnyOrigin")]
    public class ItemReasGrpEntLinkController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemReasGrpEntLinkService _itemReasGrpEntLinkService;

        public ItemReasGrpEntLinkController(IItemReasGrpEntLinkService itemReasGrpEntLinkService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ItemReasGrpEntLinkController));
            _itemReasGrpEntLinkService = itemReasGrpEntLinkService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ItemReasGrpEntLink>> Get()
        {
            try
            { 
                var itemReasGrpEntLinks = _itemReasGrpEntLinkService.GetAll();
                return Ok(itemReasGrpEntLinks);
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
        public ActionResult<ItemReasGrpEntLink> Get(string id)
        {
            try
            {
                var itemReasGrpEntLink = _itemReasGrpEntLinkService.GetById(id);
                return Ok(itemReasGrpEntLink);

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
        public IActionResult Post([FromBody] ItemReasGrpEntLink itemReasGrpEntLink)
        {
            try
            {
                if (itemReasGrpEntLink == null)
                    return BadRequest();

                itemReasGrpEntLink.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemReasGrpEntLink.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemReasGrpEntLinkService.Create(itemReasGrpEntLink);
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
        public IActionResult Put(string id, [FromBody] ItemReasGrpEntLink itemReasGrpEntLink)
        {
            try
            {
                if (!itemReasGrpEntLink.RowId.Equals(id))
                    return BadRequest("RowId mismatch");

                var itemReasGrpEntLinkToUpdate = _itemReasGrpEntLinkService.GetById(id);

                if (itemReasGrpEntLinkToUpdate == null)
                    return NotFound($"ItemReasGrpEntLink with RowId = {id} not found");

                itemReasGrpEntLink.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemReasGrpEntLink.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemReasGrpEntLinkService.Update(itemReasGrpEntLink);
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
                var itemReasGrpEntLinkToDelete = _itemReasGrpEntLinkService.GetById(id);

                if (itemReasGrpEntLinkToDelete == null)
                    return NotFound($"ItemReasGrpEntLink with RowId = {id} not found");

                _itemReasGrpEntLinkService.Delete(id);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return all the possible reject / waste reason groups and reasons defined for an entity. Reasons linked to an item class may also be optionally included.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="itemClassId"></param>
        /// <param name="reasGrpType"></param>
        /// <returns></returns>
        [HttpPut("GetReasons", Name = "GetReasons")]
        [Authorize]
        public async Task<IActionResult> GetReasonsAsync(int entId, string itemClassId, int reasGrpType)
        {
            try
            {

                var result = await _itemReasGrpEntLinkService.GetReasonsAsync(entId, itemClassId, reasGrpType);
                return Ok(result);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}

