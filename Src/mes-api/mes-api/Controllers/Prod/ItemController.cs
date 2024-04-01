//
//  ItemController.cs
//
//  Author:
//       Bill Gauvey <Bill.Gauvey@barretteoutdoorliving.com>
//
//  Copyright (c) 2024 Barrette Outdoor Living
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using BOL.API.Domain.Models.Core;
using BOL.API.Domain.Models.Prod;
using BOL.API.Domain.Models.Util;
using BOL.API.Service.Interfaces;
using BOL.API.Service.Models;
using BOL.API.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Prod
{
    [Route("prod/item")]
    [EnableCors("AllowAnyOrigin")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILogger _logger;
        public ItemController(IItemService ItemService, ILoggerFactory loggerFactory)
        {
            _itemService = ItemService;
            _logger = loggerFactory.CreateLogger(nameof(ItemController));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get()
        {
            try
            {
                var items = await _itemService.GetItemsAsync();
                return Ok(items);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get(string itemId)
        {
            try
            {
                var item = await _itemService.GetItemAsync(itemId);
                return Ok(item);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] Item value)
        {
            try
            {
                if (User.Identity == null)
                {
                    throw new Exception("User name not found.");
                }
                value.LastEditBy = User.Identity.Name;

                var itemId = await _itemService.CreateAsync(value);

                // Return 201
                return new ObjectResult(itemId) { StatusCode = StatusCodes.Status201Created };


            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(string itemId)
        {
            try
            {
                var itemToDelete = _itemService.GetItemAsync(itemId);

                if (itemToDelete == null)
                    return NotFound($"Item with ItemId {itemId} not found");

                _itemService.DeleteAsync(itemId);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        [HttpPost("{itemId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(string itemId, [FromBody] Item value)
        {
            try
            {
                if (!itemId.Equals(value.ItemId))
                    return BadRequest("StateCd mismatch");

                var itemToUpdate = await _itemService.GetItemAsync(itemId);

                if (itemToUpdate == null)
                    return NotFound($"Item with ItemId {itemId} not found");


                if (User.Identity == null)
                {
                    throw new Exception("User name not found.");
                }
                value.LastEditBy = User.Identity.Name;

                var i = await _itemService.UpdateAsync(value);

                return Ok(value);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("attrs/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<EntityAttribute>>> GetAttrs(string itemId)
        {
            try
            {
                var item = _itemService.GetItemAsync(itemId);

                if (item == null)
                    return NotFound($"Item with ItemId {itemId} not found");

                var attrs = await _itemService.GetAttrsAsync(itemId);
                return Ok(attrs);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("files/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ItemFile>>> GetFiles(string itemId)
        {
            try
            {
                var ent = await _itemService.GetItemAsync(itemId);

                if (ent == null)
                    return NotFound($"Item with ItemId {itemId} not found");

                var files = _itemService.GetFiles(itemId);
                return Ok(files);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

    }
}

