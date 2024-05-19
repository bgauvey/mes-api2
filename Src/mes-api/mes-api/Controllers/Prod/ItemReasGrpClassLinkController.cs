using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("prod/itemreasGrpClassLink")]
    [EnableCors("AllowAnyOrigin")]
    public class ItemReasGrpClassLinkController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemReasGrpClassLinkService _itemReasGrpClassLinkService;

        public ItemReasGrpClassLinkController(IItemReasGrpClassLinkService itemReasGrpClassLinkService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ItemReasGrpClassLinkController));
            _itemReasGrpClassLinkService = itemReasGrpClassLinkService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ItemReasGrpClassLink>> Get()
        {
            try
            { 
                var itemReasGrpClassLinks = _itemReasGrpClassLinkService.GetAll();
                return Ok(itemReasGrpClassLinks);
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
        public ActionResult<ItemReasGrpClassLink> Get(string id)
        {
            try
            {
                var itemReasGrpClassLink = _itemReasGrpClassLinkService.GetById(id);
                return Ok(itemReasGrpClassLink);

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
        public IActionResult Post([FromBody] ItemReasGrpClassLink itemReasGrpClassLink)
        {
            try
            {
                if (itemReasGrpClassLink == null)
                    return BadRequest();

                itemReasGrpClassLink.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemReasGrpClassLink.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemReasGrpClassLinkService.Create(itemReasGrpClassLink);
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
        public IActionResult Put(string id, [FromBody] ItemReasGrpClassLink itemReasGrpClassLink)
        {
            try
            {
                if (!itemReasGrpClassLink.RowId.Equals(id))
                    return BadRequest("RowId mismatch");

                var itemReasGrpClassLinkToUpdate = _itemReasGrpClassLinkService.GetById(id);

                if (itemReasGrpClassLinkToUpdate == null)
                    return NotFound($"ItemReasGrpClassLink with RowId = {id} not found");

                itemReasGrpClassLink.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemReasGrpClassLink.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemReasGrpClassLinkService.Update(itemReasGrpClassLink);
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
                var itemReasGrpClassLinkToDelete = _itemReasGrpClassLinkService.GetById(id);

                if (itemReasGrpClassLinkToDelete == null)
                    return NotFound($"ItemReasGrpClassLink with RowId = {id} not found");

                _itemReasGrpClassLinkService.Delete(id);
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

