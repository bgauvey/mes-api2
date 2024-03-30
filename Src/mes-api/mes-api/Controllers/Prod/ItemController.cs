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
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces;
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
        [Authorize]
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
        [Authorize]
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
        public IActionResult Delete(string itemId)
        {
            try
            {
                if (User.Identity == null)
                {
                    throw new Exception("User name not found.");
                }

                _itemService.Delete(itemId);

                return Ok();

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post([FromBody] Item value)
        {
            try
            {
                if (User.Identity == null)
                {
                    throw new Exception("User name not found.");
                }
                value.LastEditBy = User.Identity.Name.Split("\\")[1];

                var i = await _itemService.UpdateAsync(value);

                return Ok(value);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}

