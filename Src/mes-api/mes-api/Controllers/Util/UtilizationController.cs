//
//  UtilExecController.cs
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
using System.Dynamic;
using BOL.API.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.APIs
{
    [Route("util/utilization")]
    [EnableCors("AllowAnyOrigin")]
    public class UtilizationController : ControllerBase
    {
        private readonly IUtilizationService _utilizationService;
        private readonly ILogger _logger;
        public UtilizationController(IUtilizationService utilizationService, ILoggerFactory loggerFactory)
        {
            _utilizationService = utilizationService;
            _logger = loggerFactory.CreateLogger(nameof(UtilizationController));
        }


        [HttpGet("GetAvailableReasons")]
        //[Authorize]
        public async Task<IActionResult> GetAvailableReasons(int inEntId, int inRawReasCode)
        {
            try
            {
                var data = await _utilizationService.GetAvailableReasonsAsync(inEntId, inRawReasCode);

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("GetOldAvailableReasons")]
        //[Authorize]
        public async Task<IActionResult> GetOldAvailableReasons(int entId, int reasCode)
        {
            try
            {
                var data = await _utilizationService.GetOldAvailableReasonsAsync(entId, reasCode);

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("SetPendingReason")]
        //[Authorize]
        public async Task<IActionResult> SetPendingReason([FromBody] object value)
        {
            try
            {
                //var i = await _utilizationService.SetPendingReasonAsync();

                return Ok(value);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        [HttpPost("SetRawReas")]
        //[Authorize]
        public async Task<IActionResult> SetRawReas([FromBody] object value)
        {
            try
            {
                //var i = await _utilizationService.SetRawReasAsync();

                return Ok(value);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        [HttpPost("SetReason")]
        //[Authorize]
        public async Task<IActionResult> SetReason([FromBody] object value)
        {
            try
            {

                //var i = await _utilizationService.SetReasonAsync();

                return Ok(value);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        [HttpPost("UpdateDurations")]
        //[Authorize]
        public async Task<IActionResult> UpdateDurations([FromBody] object value)
        {
            try
            {
                //var i = await _utilizationService.UpdateDurationsAsync();

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
