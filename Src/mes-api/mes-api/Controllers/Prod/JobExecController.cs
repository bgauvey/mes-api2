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
using api.Models;
using BOL.API.Service.Interfaces;
using BOL.API.Service.Models;
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
    //[Authorize]
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
        public async Task<IActionResult>  CancelAllJobs(string woId)
        {
            try
            {
                await _JobExecService.CancelAllJobsAsync(woId);

                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To allow a user to sign off on a job, a job step, production, or consumption that requires a certification sign off, or to change the status of a process if such
        /// changes require signoffs.
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="stepNo"></param>
        /// <param name="lotNo"></param>
        /// <param name="prodLogId"></param>
        /// <param name="consLogId"></param>
        /// <param name="processId"></param>
        /// <param name="processStatus"></param>
        /// <param name="active"></param>
        /// <param name="certName"></param>
        /// <param name="signOffLocal"></param>
        /// <param name="comments"></param>
        /// <param name="refRowId"></param>
        /// <returns></returns>
        [HttpPost("CertSignOff", Name = "CertSignOff")]
        [Authorize]
        public async Task< IActionResult> CertSignOffAsync(string woId, string operId, int seqNo, int? stepNo, string lotNo, int prodLogId, int consLogId, string processId, int processStatus,
        bool active, string certName, DateTime? signOffLocal, string? comments, int refRowId)
        {
            try
            {
                var userId = User.Identity.Name;

                var data = await _JobExecService.CertSignOffAsync(woId, operId, seqNo, stepNo, lotNo, prodLogId, consLogId, processId, processStatus, active, certName, userId,
                    signOffLocal, comments, refRowId);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To find out whether a job or a job step may be signed off by a specific user based on the user’s certifications and any of the required certification(s) linked
        /// to either the operation or the step.
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="operId"></param>
        /// <param name="stepNo"></param>
        /// <param name="certName"></param>
        /// <returns></returns>
        [HttpPost("CertSignOffAllowed", Name = "CertSignOffAllowed")]
        [Authorize]
        public async Task<IActionResult> CertSignoffAllowedAsync(string processId, string operId, int? stepNo, string? certName)
        {
            try
            {
                var userId = User.Identity.Name;

                var rc = await _JobExecService.CertSignoffAllowedAsync(userId, processId, operId, stepNo, certName);

                return Ok(rc);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To find out whether a job or a job step that requires one or more audit-type certification(s) has been signed off or not.
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="stepNo"></param>
        /// <param name="certName"></param>
        /// <param name="lotNo"></param>
        /// <param name="prodLogId"></param>
        /// <param name="consLogId"></param>
        /// <param name="processId"></param>
        /// <param name="processStatus"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        [HttpPost("CertSignOffDone", Name = "CertSignOffDone")]
        [Authorize]
        public async Task<IActionResult> CertSignoffDoneAsync(string woId, string operId, int seqNo, int? stepNo, string? certName, string? lotNo, int? prodLogId, int? consLogId,
            string? processId, int? processStatus, bool? active)
        {
            try
            {
                var data = await _JobExecService.CertSignoffDoneAsync(woId, operId, seqNo, stepNo, certName, lotNo, prodLogId, consLogId, processId, processStatus, active);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To find out whether a job or a job step requires a certification sign off by a certified user.
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="operId"></param>
        /// <param name="stepNo"></param>
        /// <returns></returns>
        [HttpPost("CertSignOffReqd", Name = "CertSignOffReqd")]
        [Authorize]
        public async Task<IActionResult> CertSignoffReqdAsync(string processId, string operId, int? stepNo)
        {
            try
            {
                var data = await _JobExecService.CertSignoffReqdAsync(processId, operId, stepNo);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To find out whether a job or a job step may be started by a specific user based on the user’s certifications and any of the required certification(s)
        /// linked to either the operation, step or item.
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="operId"></param>
        /// <param name="stepNo"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpPost("CertStartAllowed", Name = "CertStartAllowed")]
        [Authorize]
        public async Task<IActionResult> CertStartAllowedAsync(string? processId, string? operId, int? stepNo, string? itemId)
        {
            try
            {
                var userId = User.Identity.Name;
                var rc = await _JobExecService.CertStartAllowedAsync(userId, processId, operId, stepNo, itemId);

                return Ok(rc);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To change the state, required finish time, and/or job priority of a list of jobs.
        /// </summary>
        /// <param name="rowId"></param>
        /// <param name="stateCd"></param>
        /// <param name="reqFinishTimeLocal"></param>
        /// <param name="jobPriority"></param>
        /// <param name="applyToAllJobs"></param>
        /// <returns></returns>
        [HttpPost("ChangeJobStates", Name = "ChangeJobStates")]
        [Authorize]
        public async Task<IActionResult> ChangeJobStatesAsync(int rowId, int? stateCd, DateTime? reqFinishTimeLocal, int? jobPriority, int? applyToAllJobs)
        {
            try
            {
                var rc = await _JobExecService.ChangeJobStatesAsync(rowId, stateCd, reqFinishTimeLocal, jobPriority, applyToAllJobs);

                return Ok(rc);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To change a specific spec parameter’s value for the current running job and optionally the operation from which this job was created (if defined).
        /// This allows for runtime changing of spec values by users with appropriate privileges based on the job currently running on an entity.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="specId"></param>
        /// <param name="newSpecValue"></param>
        /// <param name="updateTemplate"></param>
        /// <param name="bomPos"></param>
        /// <param name="bomVerId"></param>
        /// <param name="comments"></param>
        /// <param name="jobPos"></param>
        /// <returns></returns>
        [HttpPost("ChangeSpecValue", Name = "ChangeSpecValue")]
        [Authorize]
        public async Task<IActionResult> ChangeSpecValueAsync(int entId, string specId, string newSpecValue, bool updateTemplate, int bomPos = 0, string? bomVerId = null, string? comments = null, int jobPos = 0)
        {
            try
            {
                var userId = User.Identity.Name;

                var rc = await _JobExecService.ChangeSpecValueAsync(userId, entId, specId, newSpecValue, updateTemplate, bomPos, bomVerId, comments, jobPos);

                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To change a specific spec parameter’s value for the current running job and optionally the Operation from which this job was created (if defined).
        /// This allows for runtime changing of spec values by users with appropriate privileges based on the job currently running on an entity.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="newSpecValue"></param>
        /// <param name="newMinValue"></param>
        /// <param name="newMaxValue"></param>
        /// <param name="updateTemplate"></param>
        /// <param name="checkPrivs"></param>
        /// <param name="bomPos"></param>
        /// <param name="bomVerId"></param>
        /// <param name="comments"></param>
        /// <param name="jobPos"></param>
        /// <returns></returns>
        [HttpPost("ChangeSpecValues", Name = "ChangeSpecValues")]
        [Authorize]
        public async Task<IActionResult> ChangeSpecValuesAsync(int entId, string? newSpecValue, string? newMinValue, string? newMaxValue, bool updateTemplate = false, int checkPrivs = 0,
        int bomPos = 0, string? bomVerId = null, string comments = "", int jobPos = 0)
        {
            try
            {
                var userId = User.Identity.Name;
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => Convert.ToInt32(c.Value)).SingleOrDefault();

                var rc = await _JobExecService.ChangeSpecValuesAsync(sessionId, userId, entId, newSpecValue, newMinValue, newMaxValue, updateTemplate, checkPrivs, bomPos, bomVerId, comments, jobPos);

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

