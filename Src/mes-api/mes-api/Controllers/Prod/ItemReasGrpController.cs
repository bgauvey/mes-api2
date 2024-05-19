using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("prod/itemreasgrp")]
    [EnableCors("AllowAnyOrigin")]
    public class ItemReasGrpController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemReasGrpService _itemReasGrpService;

        public ItemReasGrpController(IItemReasGrpService itemReasGrpService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ItemReasGrpController));
            _itemReasGrpService = itemReasGrpService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ItemReasGrp>> Get()
        {
            try
            { 
                var itemReasGrps = _itemReasGrpService.GetAll();
                return Ok(itemReasGrps);
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
        public ActionResult<ItemReasGrp> Get(string id)
        {
            try
            {
                var itemReasGrp = _itemReasGrpService.GetById(id);
                return Ok(itemReasGrp);

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
        public IActionResult Post([FromBody] ItemReasGrp itemReasGrp)
        {
            try
            {
                if (itemReasGrp == null)
                    return BadRequest();

                itemReasGrp.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemReasGrp.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemReasGrpService.Create(itemReasGrp);
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
        public IActionResult Put(string id, [FromBody] ItemReasGrp itemReasGrp)
        {
            try
            {
                if (!itemReasGrp.ReasGrpId.Equals(id))
                    return BadRequest("ReasGrpId mismatch");

                var itemReasGrpToUpdate = _itemReasGrpService.GetById(id);

                if (itemReasGrpToUpdate == null)
                    return NotFound($"ItemReasGrp with ReasGrpId = {id} not found");

                itemReasGrp.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemReasGrp.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemReasGrpService.Update(itemReasGrp);
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
                var itemReasGrpToDelete = _itemReasGrpService.GetById(id);

                if (itemReasGrpToDelete == null)
                    return NotFound($"ItemReasGrp with ReasGrpId = {id} not found");

                _itemReasGrpService.Delete(id);
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

