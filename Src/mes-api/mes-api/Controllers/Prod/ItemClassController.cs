using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/itemclass")]
    [EnableCors("AllowAnyOrigin")]
    public class ItemClassController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemClassService _itemClassService;

        public ItemClassController(IItemClassService itemClassService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ItemClassController));
            _itemClassService = itemClassService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ItemClass>> Get()
        {
            try
            { 
                var itemClasss = _itemClassService.GetAll();
                return Ok(itemClasss);
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
        public ActionResult<ItemClass> Get(int id)
        {
            try
            {
                var itemClass = _itemClassService.GetById(id);
                return Ok(itemClass);

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
        public IActionResult Post([FromBody] ItemClass itemClass)
        {
            try
            {
                if (itemClass == null)
                    return BadRequest();

                itemClass.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemClass.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemClassService.Create(itemClass);
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
        public IActionResult Put(string id, [FromBody] ItemClass itemClass)
        {
            try
            {
                if (!itemClass.ItemClassId.Equals(id))
                    return BadRequest("ItemClassId mismatch");

                var itemClassToUpdate = _itemClassService.GetById(id);

                if (itemClassToUpdate == null)
                    return NotFound($"ItemClass with ItemClassId = {id} not found");

                itemClass.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemClass.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemClassService.Update(itemClass);
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
                var itemClassToDelete = _itemClassService.GetById(id);

                if (itemClassToDelete == null)
                    return NotFound($"ItemClass with ItemClassId = {id} not found");

                _itemClassService.Delete(id);
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

