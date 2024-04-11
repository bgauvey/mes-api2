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

using System.Diagnostics;
using System.Security.Claims;
using api.Models;
using BOL.API.Domain.Models.Core;
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
        [HttpPut("AddCons", Name = "AddCons")]
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
        [HttpPut("AddConsDirect", Name = "AddConsDirect")]
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
        [HttpPut("AddConsPostExec", Name = "AddConsPostExec")]
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
        [HttpPut("AddProd", Name = "AddProd")]
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
        [HttpPut("AddProdPostExec", Name = "AddProdPostExec")]
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
        [HttpPut("CancelAllJobs", Name = "CancelAllJobs")]
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
        [HttpPut("CertSignOff", Name = "CertSignOff")]
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
        [HttpPut("CertSignOffAllowed", Name = "CertSignOffAllowed")]
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
        [HttpPut("CertSignOffDone", Name = "CertSignOffDone")]
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
        [HttpPut("CertSignOffReqd", Name = "CertSignOffReqd")]
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
        [HttpPut("CertStartAllowed", Name = "CertStartAllowed")]
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
        [HttpPut("ChangeJobStates", Name = "ChangeJobStates")]
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
        [HttpPut("ChangeSpecValue", Name = "ChangeSpecValue")]
        [Authorize]
        public async Task<IActionResult> ChangeSpecValueAsync(int entId, string specId, string newSpecValue, bool updateTemplate, int bomPos = 0, string? bomVerId = null, string? comments = null, int jobPos = 0)
        {
            try
            {
                var userId = User.Identity.Name;

                await _JobExecService.ChangeSpecValueAsync(userId, entId, specId, newSpecValue, updateTemplate, bomPos, bomVerId, comments, jobPos);

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
        [HttpPut("ChangeSpecValues", Name = "ChangeSpecValues")]
        [Authorize]
        public async Task<IActionResult> ChangeSpecValuesAsync(int entId, string? newSpecValue, string? newMinValue, string? newMaxValue, bool updateTemplate = false, int checkPrivs = 0,
        int bomPos = 0, string? bomVerId = null, string comments = "", int jobPos = 0)
        {
            try
            {
                var userId = User.Identity.Name;
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => Convert.ToInt32(c.Value)).SingleOrDefault();

                await _JobExecService.ChangeSpecValuesAsync(sessionId, userId, entId, newSpecValue, newMinValue, newMaxValue, updateTemplate, checkPrivs, bomPos, bomVerId, comments, jobPos);

                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// Change priority for all the jobs in a work order.
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="newPriority"></param>
        /// <returns></returns>
        [HttpPut("ChangeWOPriority", Name = "ChangeWOPriority")]
        [Authorize]
        public async Task<IActionResult> ChangeWOPriorityAsync(string woId, int newPriority)
        {
            try
            {
                await _JobExecService.ChangeWOPriorityAsync(woId, newPriority);

                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// Change starting and required quantities for a work order.
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="reqQty"></param>
        /// <param name="processId"></param>
        /// <param name="itemId"></param>
        /// <param name="startQty"></param>
        /// <param name="reqFinishTime"></param>
        /// <param name="releaseTime"></param>
        /// <returns></returns>
        [HttpPut("ChangeWOQtys", Name = "ChangeWOQtys")]
        [Authorize]
        public async Task<IActionResult> ChangeWOQtysAsync(string woId, double reqQty, string? processId = null, string? itemId = null, double? startQty = null, DateTime? reqFinishTime = null, DateTime? releaseTime = null)
        {
            try
            {
                var userId = User.Identity.Name;

                await _JobExecService.ChangeWOQtysAsync(userId, woId, reqQty, processId, itemId, startQty, reqFinishTime, releaseTime);

                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// Changes the required finish time for all the jobs in a Work Order. 
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="reqFinishTimeLocal"></param>
        /// <returns></returns>
        [HttpPut("ChangeWOReqdFinishTime", Name = "ChangeWOReqdFinishTime")]
        [Authorize]
        public async Task<IActionResult> ChangeWOReqdFinishTimeAsync(string woId, DateTime reqFinishTimeLocal)
        {
            try
            {
                await _JobExecService.ChangeWOReqdFinishTimeAsync(woId, reqFinishTimeLocal);

                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// The same as ChangeWOPriority, ChangeWOQtys, and ChangeWOReqdFinishTime, all together in a single transaction. 
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="priority"></param>
        /// <param name="reqFinishTimeLocal"></param>
        /// <param name="qtyReqd"></param>
        /// <param name="qtyAtStart"></param>
        /// <returns></returns>
        [HttpPut("ChangeWOValues", Name = "ChangeWOValues")]
        [Authorize]
        public async Task<IActionResult> ChangeWOValuesAsync(string woId, int priority, DateTime reqFinishTimeLocal, double qtyReqd, double qtyAtStart)
        {
            try
            {
                await _JobExecService.ChangeWOValuesAsync(woId, priority, reqFinishTimeLocal, qtyReqd, qtyAtStart);

                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To clone a job and all of its dependent data. 
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="newWoId"></param>
        /// <param name="newOperId"></param>
        /// <param name="newSeqNo"></param>
        /// <param name="reqQty"></param>
        /// <param name="startQty"></param>
        /// <param name="reqFinishTimeLocal"></param>
        /// <returns></returns>
        [HttpPut("CloneJob", Name = "CloneJob")]
        [Authorize]
        public async Task<IActionResult> CloneJobAsync(string woId, string operId, int seqNo, string? newWoId, string? newOperId, int? newSeqNo, double? reqQty, double? startQty, DateTime? reqFinishTimeLocal)
        {
            try
            {
                var userId = User.Identity.Name;

                var result = await _JobExecService.CloneJobAsync(userId, woId, operId, seqNo, newWoId, newOperId, newSeqNo, reqQty, startQty, reqFinishTimeLocal);

                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To clone a work order and all its instance specific data based on an existing work order. 
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="newWoId"></param>
        /// <param name="reqQty"></param>
        /// <param name="woDesc"></param>
        /// <param name="releaseTimeLocal"></param>
        /// <param name="reqFinishTimeLocal"></param>
        /// <param name="woPriority"></param>
        /// <param name="custInfo"></param>
        /// <param name="moId"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        [HttpPut("CloneWo", Name = "CloneWo")]
        [Authorize]
        public async Task<IActionResult> CloneWoAsync(string woId, string newWoId, double? reqQty, string? woDesc, DateTime? releaseTimeLocal, DateTime? reqFinishTimeLocal, int? woPriority, string? custInfo, string? moId, string? notes)
        {
            try
            {
                var userId = User.Identity.Name;

                var result = await _JobExecService.CloneWoAsync(userId, woId, newWoId, reqQty, woDesc, releaseTimeLocal, reqFinishTimeLocal, woPriority, custInfo, moId, notes);

                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To create instance data for a work order based on a given process_id and other work order instance specific data. 
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="processId"></param>
        /// <param name="itemId"></param>
        /// <param name="reqQty"></param>
        /// <param name="startQty"></param>
        /// <param name="initWoState"></param>
        /// <param name="woDesc"></param>
        /// <param name="releaseTime"></param>
        /// <param name="reqFinishTime"></param>
        /// <param name="woPriority"></param>
        /// <param name="custInfo"></param>
        /// <param name="moId"></param>
        /// <param name="notes"></param>
        /// <param name="bomVerId"></param>
        /// <param name="forFirstOp"></param>
        /// <param name="specVerId"></param>
        /// <param name="mayOverrideRoute"></param>
        /// <returns></returns>
        [HttpPost("CreateWoFromProcess", Name = "CreateWoFromProcess")]
        [Authorize]
        public async Task<IActionResult> CreateWoFromProcessAsync(string woId, string processId, string itemId, double reqQty, double? startQty = null, int? initWoState = 1,
        string? woDesc = null, DateTime? releaseTime = null, DateTime? reqFinishTime = null, int? woPriority = 1, string? custInfo = null, string? moId = null, string? notes = "",
        string? bomVerId = null, bool forFirstOp = false, string? specVerId = null, bool mayOverrideRoute = false)
        {
            try
            {
                var userId = User.Identity.Name;

                var result = await _JobExecService.CreateWoFromProcessAsync(userId, woId, processId, itemId, reqQty, startQty, initWoState, woDesc, releaseTime, reqFinishTime, woPriority,
                                    custInfo, moId, notes, bomVerId, forFirstOp, specVerId, mayOverrideRoute);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To allow the downloading of specifications to the process via the Factory Connector on demand.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="stepNo"></param>
        /// <returns></returns>
        [HttpPut("DownloadSpecs", Name = "DownloadSpecs")]
        [Authorize]
        public async Task<IActionResult> DownloadSpecsAsync(int entId, string woId, string operId, int seqNo, int? stepNo)
        {
            try
            {
                var result = await _JobExecService.DownloadSpecsAsync(entId, woId, operId, seqNo, stepNo);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To end a job on an entity.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="jobPos"></param>
        /// <param name="statusNotes"></param>
        /// <param name="userId"></param>
        /// <param name="checkPrivs"></param>
        /// <param name="checkCerts"></param>
        /// <param name="clientType"></param>
        /// <param name="noPropogation"></param>
        /// <param name="checkAutoJobStart"></param>
        /// <returns></returns>
        [HttpPut("EndJob", Name = "EndJob")]
        [Authorize]
        public async Task<IActionResult> EndJobAsync(int entId, string woId, string operId, int seqNo, int jobPos = 0, string? statusNotes = null, string? userId = null, int? checkPrivs = null,
        int? checkCerts = null, int clientType = 37, int noPropogation = 0, int checkAutoJobStart = 1)
        {
            try
            {
                var result = await _JobExecService.EndJobAsync(entId, woId, operId, seqNo, jobPos, statusNotes, userId, checkPrivs, checkCerts, clientType, noPropogation, checkAutoJobStart);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To find the first unused job position on an entity that can run multiple jobs.
        /// </summary>
        /// <param name="entId"></param>
        /// <returns></returns>
        [HttpGet("GetAvailJobPos", Name = "GetAvailJobPos")]
        [Authorize]
        public async Task<IActionResult> GetAvailJobPosAsync(int entId)
        {
            try
            {
                var data = await _JobExecService.GetAvailJobPosAsync(entId);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To get all the eligible values for production lot numbers for a running job.
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="entId"></param>
        /// <returns></returns>
        [HttpGet("GetAvailLots", Name = "GetAvailLots")]
        public async Task<IActionResult> GetAvailLotsAsync(string woId, string operId, int seqNo, int entId)
        {
            try
            {
                var data = await _JobExecService.GetAvailLotsAsync(woId, operId, seqNo, entId);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To determine which job position a running job occupies on an entity.
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="entId"></param>
        /// <returns></returns>
        [HttpGet("GetCurrJobPos", Name = "GetCurrJobPos")]
        public async Task<IActionResult> GetCurrJobPosAsync(string woId, string operId, int seqNo, int entId)
        {
            try
            {
                var data = await _JobExecService.GetCurrJobPosAsync(entId, woId, operId, seqNo);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return a single recordset containing details of quantities related to the step for a given job, including BOM data IF a BOM item is linked to this step. 
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="stepNo"></param>
        /// <returns></returns>
        [HttpGet("GetJobBOMStepQuantities", Name = "GetJobBOMStepQuantities")]
        public async Task<IActionResult> GetJobBOMStepQuantitiesAsync(string woId, string operId, int seqNo, int stepNo)
        {
            try
            {
                var data = await _JobExecService.GetJobBOMStepQuantitiesAsync(woId, operId, seqNo, stepNo);
                return Ok(data);
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
        public async Task<IActionResult> GetJobQueue(string woId, string itemId)
        {
            try
            {
                var data = await _JobExecService.GetJobQueueAsync(woId, itemId);
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return a list of all jobs as applied by filters
        /// </summary>
        /// <param name="entFilter"></param>
        /// <param name="jobFilter"></param>
        /// <returns></returns>
        [HttpGet("GetJobQueueByFilter", Name = "GetJobQueueByFilter")]
        public async Task<IActionResult> GetJobQueueByFilterAsync(string entFilter, string jobFilter)
        {
            try
            {
                var data = await _JobExecService.GetJobQueueByFilterAsync(entFilter, jobFilter);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return a recordset containing details of all certifications that require signoff for a given job and / or step. 
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="stepNo"></param>
        /// <returns></returns>
        [HttpGet("GetReqdCertSignoffs", Name = "GetReqdCertSignoffs")]
        public async Task<IActionResult> GetReqdCertSignoffsAsync(string woId, string operId, int stepNo)
        {
            try
            {
                var data = await _JobExecService.GetReqdCertSignoffsAsync(woId, operId, stepNo);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }

        }

        /// <summary>
        /// To return an entity and a list of all descendent entities that can run jobs.
        /// </summary>
        /// <param name="entId"></param>
        /// <returns></returns>
        [HttpGet("GetRunnableEntities", Name = "GetRunnableEntities")]
        public async Task<IActionResult> GetRunnableEntitiesAsync(int entId)
        {
            try
            {
                var data = await _JobExecService.GetRunnableEntitiesAsync(entId);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return all the schedulable entities for a job.
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="windowId"></param>
        /// <returns></returns>
        [HttpGet("GetSchedEntsByWindow", Name = "GetSchedEntsByWindow")]
        public async Task<IActionResult> GetSchedEntsByWindowAsync(string woId = null, string operId = null, int windowId = 0)
        {
            try
            {
                var data = await _JobExecService.GetSchedEntsByWindowAsync(woId, operId, windowId);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return an entity that can schedule a job.
        /// </summary>
        /// <param name="entId"></param>
        /// <returns></returns>
        [HttpGet("GetSchedulableEntity", Name = "GetSchedulableEntity")]
        public async Task<IActionResult> GetSchedulableEntityAsync(int entId)
        {
            try
            {
                var data = await _JobExecService.GetSchedulableEntityAsync(entId);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return a list of all parent entities from an entity that can schedule jobs.
        /// </summary>
        /// <param name="entId"></param>
        /// <returns></returns>
        [HttpGet("GetSchedulableParents", Name = "GetSchedulableParents")]
        public async Task<IActionResult> GetSchedulableParentsAsync(int entId)
        {
            try
            {
                var data = await _JobExecService.GetSchedulableParentsAsync(entId);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To return a single recordset containing details of all step data for a given job, including any BOM data IF a BOM item is linked to this step. 
        /// </summary>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="stepNo"></param>
        /// <returns></returns>
        [HttpGet("GetStepBOMData", Name = "GetStepBOMData")]
        public async Task<IActionResult> GetStepBOMDataAsync(string woId, string operId, int seqNo, int? stepNo = null)
        {
            try
            {
                var data = await _JobExecService.GetStepBOMDataAsync(woId, operId, seqNo, stepNo);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To add a new row to the job_event table.  This allows multiple events to be logged for a given job or step.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="eventTimeLocal"></param>
        /// <param name="jobPos"></param>
        /// <param name="stepNo"></param>
        /// <param name="eventType"></param>
        /// <param name="bomPos"></param>
        /// <param name="lotNo"></param>
        /// <param name="sublotNo"></param>
        /// <param name="itemId"></param>
        /// <param name="certName"></param>
        /// <param name="doneByUserId"></param>
        /// <param name="checkedByUserId"></param>
        /// <param name="sourceRowId"></param>
        /// <param name="specId"></param>
        /// <param name="comments"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        /// <param name="value6"></param>
        /// <param name="value7"></param>
        /// <param name="value8"></param>
        /// <param name="value9"></param>
        /// <param name="value10"></param>
        /// <param name="lastEditComment"></param>
        /// <returns></returns>
        [HttpPost("LogJobEvent", Name = "LogJobEvent")]
        [Authorize]
        public async Task<IActionResult> LogJobEventAsync(int entId, DateTime eventTimeLocal, int jobPos, int stepNo, string eventType, int bomPos, string lotNo, string sublotNo, string itemId, string certName, string doneByUserId,
        string checkedByUserId, int sourceRowId, string specId, string comments, string value1, string value2, string value3, string value4, string value5, string value6, string value7, string value8, string value9,
        string value10, string lastEditComment)
        {
            try
            {
                var data = await _JobExecService.LogJobEventAsync(entId, eventTimeLocal, jobPos, stepNo, eventType, bomPos, lotNo, sublotNo, itemId, certName, doneByUserId,
                    checkedByUserId, sourceRowId, specId, comments, value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, lastEditComment);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To Stop a RUNNING job on an entity. Used to Suspend, Put on Hold or return a Running job to the READY or NEW state.
        /// </summary>
        /// <param name="entId"></param>
        /// <param name="woId"></param>
        /// <param name="operId"></param>
        /// <param name="seqNo"></param>
        /// <param name="pausedJobState"></param>
        /// <param name="jobPos"></param>
        /// <param name="statusNotes"></param>
        /// <param name="actFinishTimeLocal"></param>
        /// <returns></returns>
        [HttpPut("PauseJob", Name = "PauseJob")]
        [Authorize]
        public async Task<IActionResult> PauseJobAsync(int entId, string woId, string operId, int seqNo, int pausedJobState, int jobPos = 0, string statusNotes = null, DateTime? actFinishTimeLocal = null)
        {
            try
            {
                var data = await _JobExecService.PauseJobAsync(entId, woId, operId, seqNo, pausedJobState, jobPos, statusNotes, actFinishTimeLocal);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        /// <summary>
        /// To reject all or part of an existing row in the production transaction table (item_prod) for a specified reject reason.
        /// The quantity that is rejected may result in a new row or it may simply add to another existing row if the primary key fields matches.
        /// </summary>
        /// <param name="oldRowId"></param>
        /// <param name="splitQtyProd"></param>
        /// <param name="newWoId"></param>
        /// <param name="newOperId"></param>
        /// <param name="newSeqNo"></param>
        /// <param name="newShiftStartLocal"></param>
        /// <param name="newItemId"></param>
        /// <param name="newLotNo"></param>
        /// <param name="newRmLotNo"></param>
        /// <param name="newSublotNo"></param>
        /// <param name="newRmSublotNo"></param>
        /// <param name="newReasCd"></param>
        /// <param name="newEntId"></param>
        /// <param name="newShiftId"></param>
        /// <param name="newToEntId"></param>
        /// <param name="splitQtyProdErp"></param>
        /// <param name="splitProcessedFlag"></param>
        /// <param name="splitByproductFlag"></param>
        /// <returns></returns>
        [HttpPost("RejectProd", Name = "RejectProd")]
        [Authorize]
        public async Task<IActionResult> RejectProdAsync(int oldRowId, double splitQtyProd, string newWoId = null, string newOperId = null, int? newSeqNo = null, DateTime? newShiftStartLocal = null,
                    string newItemId = null, string newLotNo = null, string newRmLotNo = null, string newSublotNo = null, string newRmSublotNo = null, int? newReasCd = null, int? newEntId = null,
                    int? newShiftId = null, int? newToEntId = null, double? splitQtyProdErp = null, bool splitProcessedFlag = false, bool splitByproductFlag = false)
        {
            try
            {
                var newUserId = User.Identity.Name;
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                         .Select(c => Convert.ToInt32(c.Value)).SingleOrDefault();

                var data = await _JobExecService.RejectProdAsync(sessionId, oldRowId, splitQtyProd, newWoId, newOperId, newSeqNo, newShiftStartLocal, newItemId, newLotNo, newRmLotNo,
                    newSublotNo, newRmSublotNo, newReasCd, newUserId, newEntId, newShiftId, newToEntId, splitQtyProdErp, splitProcessedFlag, splitByproductFlag);

                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}

