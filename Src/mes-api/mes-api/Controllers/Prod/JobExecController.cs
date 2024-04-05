//
//  JobExecController.cs
//
//  Author:
//       Bill Gauvey <Bill.Gauvey@barretteoutdoorliving.com>
//
//  Copyright (c) 2024 Barrette Outdoor Living
//
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

using System.Security.Claims;
using BOL.API.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Prod
{
    /// <summary>
    /// JobExec API
    /// </summary>
    [Route("prod/jobexec")]
    [EnableCors("AllowAnyOrigin")]
    [Authorize]
    public class JobExecController : Controller
    {
        private readonly IJobExecService _JobExecService;
        private readonly ILogger _logger;

        public JobExecController(IJobExecService jobExecService, ILoggerFactory loggerFactory)
        {
            _JobExecService = jobExecService;
            _logger = loggerFactory.CreateLogger(nameof(JobExecController));
        }

        /// <summary>
        /// To capture consumption data for the RUNNING job on the specified entity.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="jobPos"></param>
        /// <param name="bomPos"></param>
        /// <param name="qtyCons"></param>
        /// <param name="reasCd"></param>
        /// <param name="lotNo"></param>
        /// <param name="fgLotNo"></param>
        /// <param name="sublotNo"></param>
        /// <param name="fgSublotNo"></param>
        /// <param name="fromEntId"></param>
        /// <param name="itemId"></param>
        /// <param name="extRef"></param>
        /// <param name="applyScalingFactor"></param>
        /// <param name="spare1"></param>
        /// <param name="spare2"></param>
        /// <param name="spare3"></param>
        /// <param name="spare4"></param>
        /// <returns></returns>
        [HttpPost("AddCons", Name = "AddCons")]
        [Authorize]
        public async Task<IActionResult> AddCons(int entId, int jobPos, int bomPos, double qtyCons, int? reasCd, string? lotNo, string? fgLotNo, string? sublotNo, string? fgSublotNo,
        int? fromEntId, string? itemId, string extRef, bool applyScalingFactor, string spare1, string spare2, string spare3, string spare4)
        {
            try
            {
                var userId = User.Identity.Name;
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => Convert.ToInt32(c.Value)).SingleOrDefault();
                var result = await _JobExecService.AddConsAsync(sessionId, userId, entId, jobPos, bomPos, qtyCons, reasCd, lotNo, fgLotNo, sublotNo, fgSublotNo,
                 fromEntId, itemId, extRef, applyScalingFactor, spare1, spare2, spare3, spare4);
                return Ok(result);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To record consumption directly to the item_cons table.
        /// </summary>
        /// <param name="fromEntId"></param>
        /// <param name="itemId"></param>
        /// <param name="lotNo"></param>
        /// <param name="sublotNo"></param>
        /// <param name="qtyCons"></param>
        /// <param name="reasCd"></param>
        /// <param name="gradeCd"></param>
        /// <param name="statusCd"></param>
        /// <param name="userId"></param>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="shiftStartLocal"></param>
        /// <param name="fgLotNo"></param>
        /// <param name="fgSublotNo"></param>
        /// <param name="itemScrapped"></param>
        /// <param name="entId"></param>
        /// <param name="shiftId"></param>
        /// <param name="qtyConsErp"></param>
        /// <param name="extRef"></param>
        /// <param name="transactionType"></param>
        /// <param name="spare1"></param>
        /// <param name="spare2"></param>
        /// <param name="spare3"></param>
        /// <param name="spare4"></param>
        /// <returns></returns>
        [HttpPost("AddConsDirect", Name = "AddConsDirect")]
        [Authorize]
        public async Task<IActionResult> AddConsDirect(int fromEntId, string itemId, string lotNo, string sublotNo, double qtyCons, int reasCd, int gradeCd, int statusCd, string userId,
                    string? woId, string? operId, int? seqNo, DateTime? shiftStartLocal, string? fgLotNo, string? fgSublotNo, int itemScrapped,
                    int? entId, int? shiftId, double qtyConsErp, string? extRef, int transactionType, string spare1, string spare2, string spare3, string spare4)
        {
            try
            {
                var userid = User.Identity.Name;
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => c.Value).SingleOrDefault();

                var data = await _JobExecService.AddConsDirectAsync(fromEntId, itemId, lotNo, sublotNo, qtyCons, reasCd, gradeCd, statusCd, userId, woId, operId, seqNo,
                    shiftStartLocal, fgLotNo, fgSublotNo, itemScrapped, entId, shiftId, qtyConsErp, extRef, transactionType, spare1, spare2, spare3, spare4);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To enter consumption data for a given job, shift, production code, lot, and finished-goods lot in the production transaction table AFTER the job has run on an entity.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="bomPos"></param>
        /// <param name="qtyCons"></param>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="shiftStartLocal"></param>
        /// <param name="shiftId"></param>
        /// <param name="itemId"></param>
        /// <param name="reasCd"></param>
        /// <param name="lotNo"></param>
        /// <param name="fgLotNo"></param>
        /// <param name="sublotNo"></param>
        /// <param name="fgSublotNo"></param>
        /// <param name="extRef"></param>
        /// <param name="spare1"></param>
        /// <param name="spare2"></param>
        /// <param name="spare3"></param>
        /// <param name="spare4"></param>
        /// <returns></returns>
        [HttpPost("AddConsPostExec", Name = "AddConsPostExec")]
        [Authorize]
        public async Task<IActionResult> AddConsPostExec(int entId, int? bomPos, double qtyCons, string woId, string operId, int seqNo, DateTime shiftStartLocal,
            int shiftId, string? itemId, int? reasCd, string? lotNo, string? fgLotNo, string? sublotNo, string? fgSublotNo, string? extRef, string spare1, string spare2, string spare3, string spare4)
        {
            try
            {
                var userId = User.Identity.Name;
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => Convert.ToInt32(c.Value)).SingleOrDefault();

                var data = await _JobExecService.AddConsPostExecAsync(sessionId, userId, entId, bomPos, qtyCons, woId, operId, seqNo, shiftStartLocal,
                                shiftId, itemId, reasCd, lotNo, fgLotNo, sublotNo, fgSublotNo, extRef, spare1, spare2, spare3, spare4);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To capture production data for the running job on the specified entity.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="qtyProd"></param>
        /// <param name="reasCd"></param>
        /// <param name="lotNo"></param>
        /// <param name="sublotNo"></param>
        /// <param name="toEntId"></param>
        /// <param name="itemId"></param>
        /// <param name="byproductBomPos"></param>
        /// <param name="extRef"></param>
        /// <param name="applyScalingFactor"></param>
        /// <param name="spare1"></param>
        /// <param name="spare2"></param>
        /// <param name="spare3"></param>
        /// <param name="spare4"></param>
        /// <param name="jobPos"></param>
        /// <returns></returns>
        [HttpPost("AddProd", Name = "AddProd")]
        [Authorize]
        public async Task<IActionResult> AddProd(int entId, double qtyProd,
        int? reasCd, string? lotNo, string? sublotNo, int? toEntId, string? itemId, int? byproductBomPos,
        string? extRef, bool applyScalingFactor, string? spare1, string? spare2, string? spare3, string? spare4, int jobPos)
        {
            try
            {
                var userId = User.Identity.Name;
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => Convert.ToInt32(c.Value)).SingleOrDefault();
                var result = await _JobExecService.AddProdAsync(sessionId, userId, entId, qtyProd, reasCd, lotNo, sublotNo, toEntId, itemId, byproductBomPos,
                    extRef, applyScalingFactor, spare1, spare2, spare3, spare4, jobPos);
                return Ok(result);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To enter production data for a given job, shift, production code, lot and container in the production transaction table AFTER the job has run on an entity.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="qtyProd"></param>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="shiftStartLocal"></param>
        /// <param name="shiftId"></param>
        /// <param name="itemId"></param>
        /// <param name="reasCd"></param>
        /// <param name="lotNo"></param>
        /// <param name="sublotNo"></param>
        /// <param name="toEntId"></param>
        /// <param name="processed"></param>
        /// <param name="byproduct"></param>
        /// <param name="extRef"></param>
        /// <param name="moveStatus"></param>
        /// <param name="spare1"></param>
        /// <param name="spare2"></param>
        /// <param name="spare3"></param>
        /// <param name="spare4"></param>
        /// <returns></returns>
        [HttpPost("AddProdPostExec", Name = "AddProdPostExec")]
        [Authorize]
        public async Task<IActionResult> AddProdPostExec(int entId, double qtyProd, string woId, string operId, int seqNo, DateTime shiftStartLocal,
        int shiftId, string? itemId, int? reasCd, string? lotNo, string? sublotNo, int? toEntId, bool? processed, bool? byproduct, string extRef, int? moveStatus,
        string? spare1, string? spare2, string? spare3, string? spare4)
        {
            try
            {
                var userid = User.Identity.Name;
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => Convert.ToInt32(c.Value)).SingleOrDefault();

                await _JobExecService.AddProdPostExecAsync(sessionId, userid, entId, qtyProd, woId, operId, seqNo, shiftStartLocal, shiftId, itemId, reasCd,
                        lotNo, sublotNo, toEntId, processed, byproduct, extRef, moveStatus, spare1, spare2, spare3, spare4);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To cancel all jobs in a given work order.
        /// </summary>
        /// <param name="woId"></param>
        /// <returns></returns>
        [HttpPost("CancelAllJobs", Name = "CancelAllJobs")]
        [Authorize]
        public IActionResult CancelAllJobs(string woId)
        {
            try
            {
                _JobExecService.CancelAllJobsAsync(woId);

                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return a list of all jobs in a work order
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet("GetJobQueue", Name = "GetJobQueue")]
        public IActionResult GetJobQueue(string woId, string itemId)
        {
            try
            {
                _JobExecService.GetJobQueue(woId, itemId);
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To retrieve the job schedule or job queue available to a specific entity.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="jobState"></param>
        /// <param name="reqdByTime"></param>
        /// <param name="job_Priority"></param>
        /// <param name="maxRows"></param>
        /// <returns></returns>
        [HttpGet("GetQueue", Name = "GetQueue")]
        public IActionResult GetQueue(int entId, int? jobState, DateTime? reqdByTime, int? job_Priority, int? maxRows)
        {
            try
            {
                _JobExecService.GetQueue(entId, jobState, reqdByTime, job_Priority, maxRows);

                return Ok();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}

