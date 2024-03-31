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
using BOL.API.Service.Interfaces.Utilization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Util
{
    [Route("util/utilexec")]
    [EnableCors("AllowAnyOrigin")]
    public class UtilExecController : ControllerBase
    {
        private readonly IUtilExecService _utilizationService;
        private readonly ILogger _logger;
        public UtilExecController(IUtilExecService utilizationService, ILoggerFactory loggerFactory)
        {
            _utilizationService = utilizationService;
            _logger = loggerFactory.CreateLogger(nameof(UtilExecController));
        }

        [HttpGet("GetAvailableReasons")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetPendingReason(int entId, int finalReasCode, int logId, int periodAffected, int oldReasCode, string comments)
        {
            try
            {
                var i = await _utilizationService.SetPendingReasonAsync(entId, finalReasCode, logId, periodAffected, oldReasCode, comments);

                return NoContent();

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        [HttpPost("SetRawReas")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetRawReas(int entId, int rawReasCode, DateTime newReasStart, string comments)
        {
            try
            {
                var i = await _utilizationService.SetRawReasAsync(entId, rawReasCode, newReasStart, comments);

                return NoContent();

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        [HttpPost("SetReason")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetReason(int entId, int newReasCode, DateTime newReasStartLocal, bool reasPending, string comments)
        {
            try
            {

                var i = await _utilizationService.SetReasonAsync(entId, newReasCode, newReasStartLocal, reasPending, comments);

                return NoContent();

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }


        [HttpPost("UpdateDurations")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateDurations(int entId)
        {
            try
            {
                var i = await _utilizationService.UpdateDurationsAsync(entId);

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
