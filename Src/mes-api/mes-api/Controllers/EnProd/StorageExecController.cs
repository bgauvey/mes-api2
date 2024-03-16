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
using BOL.API.Domain.Models.EnProd;
using BOL.API.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.APIs
{
    [Route("enprod/storageexec")]
    [EnableCors("AllowAnyOrigin")]
    public class StorageExecController : ControllerBase
	{
        IInventoryService _inventoryService;
        ILogger _logger;
        public StorageExecController(IInventoryService InventoryService, ILoggerFactory loggerFactory)
        {
            _inventoryService = InventoryService;
            _logger = loggerFactory.CreateLogger(nameof(StorageExecController));
        }

        [HttpPost("AddInv")]
        //[Authorize]
        public async Task<IActionResult> AddInv([FromBody] StorageExec value)
        {
            try
            {
                //var i = await _inventoryService.AddInv(value);

                return Ok(value);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, Message = exp.Message });
            }
        }

        [HttpPost("GetInventory")]
        //[Authorize]
        public async Task<IActionResult> GetInventory([FromBody] StorageExec value)
        {
            try
            {

                //var i = await _inventoryService.GetInventory(value);

                return Ok(value);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, Message = exp.Message });
            }
        }


        [HttpPost("GetShortages")]
        //[Authorize]
        public async Task<IActionResult> GetShortages([FromBody] StorageExec value)
        {
            try
            {

                //var i = await _inventoryService.GetShortages(value);

                return Ok(value);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, Message = exp.Message });
            }
        }

        [HttpPost("ReduceInv")]
        //[Authorize]
        public async Task<IActionResult> ReduceInv([FromBody] StorageExec value)
        {
            try
            {
                //var i = await _inventoryService.ReduceInv(value);

                return Ok(value);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, Message = exp.Message });
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
                return BadRequest(new { Status = false, Message = exp.Message });
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
                return BadRequest(new { Status = false, Message = exp.Message });
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
                return BadRequest(new { Status = false, Message = exp.Message });
            }
        }
    }

}

