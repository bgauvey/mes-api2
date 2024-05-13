using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/itemstate")]
    [EnableCors("AllowAnyOrigin")]
    public class ItemStateController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemStateService _itemStateService;

        public ItemStateController(IItemStateService itemStateService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ItemStateController));
            _itemStateService = itemStateService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ItemState>> Get()
        {
            try
            { 
                var itemStates = _itemStateService.GetAll();
                return Ok(itemStates);
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
        public ActionResult<ItemState> Get(int id)
        {
            try
            {
                var itemState = _itemStateService.GetById(id);
                return Ok(itemState);

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
        public IActionResult Post([FromBody] ItemState itemState)
        {
            try
            {
                if (itemState == null)
                    return BadRequest();

                itemState.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemState.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemStateService.Create(itemState);
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
        public IActionResult Put(int id, [FromBody] ItemState itemState)
        {
            try
            {
                if (id != itemState.ItemStatusCd)
                    return BadRequest("ItemStatusCd mismatch");

                var itemStateToUpdate = _itemStateService.GetById(id);

                if (itemStateToUpdate == null)
                    return NotFound($"ItemState with ItemStatusCd = {id} not found");

                itemState.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemState.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemStateService.Update(itemState);
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
                var itemStateToDelete = _itemStateService.GetById(id);

                if (itemStateToDelete == null)
                    return NotFound($"ItemState with ItemStatusCd = {id} not found");

                _itemStateService.Delete(id);
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

