//
//  StorageExecController.cs
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
using System.Net.Mime;
using BOL.API.Domain.Models.EnProd;
using BOL.API.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.APIs
{
    [Route("enprod/storageexec")]
    [EnableCors("AllowAnyOrigin")]
    public class StorageExecController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly ILogger _logger;
        public StorageExecController(IInventoryService InventoryService, ILoggerFactory loggerFactory)
        {
            _inventoryService = InventoryService;
            _logger = loggerFactory.CreateLogger(nameof(StorageExecController));
        }

        [HttpPost("AddInv")]
        [Authorize]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddInv([FromBody] ItemInv value)
        {
            try
            {
                _inventoryService.AddInv(value.EntId, value.ItemId, value.GradeCd.Value, value.StatusCd.Value, value.QtyLeft, value.LotNo,
                    value.QtyLeftErp, value.DateInLocal, value.ExpiryDate, value.WoId, value.OperId, value.SeqNo, null, true, false);

                return Created();

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("GetInventory")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetInventory([FromBody] int entId)
        {
            try
            {
                object i = _inventoryService.GetInventory(entId, null, null, null);
                return Ok(i);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        [HttpPost("GetShortages")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetShortages([FromBody] int? entId)
        {
            try
            {
                object i = _inventoryService.GetShortages(entId);
                return Ok(i);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("ReduceInv")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ReduceInv([FromBody] int entId, string itemId, int gradeCd, int statusCd, double reduceQty, string? lotNo,
            double? reduceQtyErp, DateTime? dateOut, bool? goodsShipped)
        {
            try
            {
                _inventoryService.ReduceInv(entId, itemId, gradeCd, statusCd, reduceQty, lotNo, reduceQtyErp, dateOut, goodsShipped);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("Split")]
        //[Authorize]
        public async Task<IActionResult> Split([FromBody] StorageExec value)
        {
            try
            {
                //var i = await _inventoryService.Split(value);

                return Ok(value);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        [HttpPost("Transfer")]
        //[Authorize]
        public async Task<IActionResult> Transfer([FromBody] StorageExec value)
        {
            try
            {
                //var i = await _inventoryService.Transfer(value);

                return Ok(value);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        [HttpPost("TransferAndUpdateInv")]
        //[Authorize]
        public async Task<IActionResult> TransferAndUpdateInv([FromBody] StorageExec value)
        {
            try
            {
                //var i = await _inventoryService.TransferAndUpdateInv(value);

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

