using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("prod/itemclassattr")]
    [EnableCors("AllowAnyOrigin")]
    public class ItemClassAttrController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemClassAttrService _itemClassAttrService;

        public ItemClassAttrController(IItemClassAttrService itemClassAttrService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ItemClassAttrController));
            _itemClassAttrService = itemClassAttrService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ItemClassAttr>> Get()
        {
            try
            { 
                var itemClassAttrs = _itemClassAttrService.GetAll();
                return Ok(itemClassAttrs);
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
        public ActionResult<ItemClassAttr> Get(int id)
        {
            try
            {
                var itemClassAttr = _itemClassAttrService.GetById(id);
                return Ok(itemClassAttr);

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
        public IActionResult Post([FromBody] ItemClassAttr itemClassAttr)
        {
            try
            {
                if (itemClassAttr == null)
                    return BadRequest();

                itemClassAttr.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemClassAttr.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemClassAttrService.Create(itemClassAttr);
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
        public IActionResult Put(int id, [FromBody] ItemClassAttr itemClassAttr)
        {
            try
            {
                if (!itemClassAttr.RowId.Equals(id))
                    return BadRequest("RowId mismatch");

                var itemClassAttrToUpdate = _itemClassAttrService.GetById(id);

                if (itemClassAttrToUpdate == null)
                    return NotFound($"ItemClassAttr with RowId = {id} not found");

                itemClassAttr.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemClassAttr.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemClassAttrService.Update(itemClassAttr);
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
                var itemClassAttrToDelete = _itemClassAttrService.GetById(id);

                if (itemClassAttrToDelete == null)
                    return NotFound($"ItemClassAttr with RowId = {id} not found");

                _itemClassAttrService.Delete(id);
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

