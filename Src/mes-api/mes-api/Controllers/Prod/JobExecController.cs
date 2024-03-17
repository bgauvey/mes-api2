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

namespace api.APIs
{
    /// <summary>
    /// JobExec API
    /// </summary>
    [Route("prod/jobexec")]
    [EnableCors("AllowAnyOrigin")]
    [Authorize]
    public class JobExecController : Controller
    {
        IJobExecService _JobExecService;
        ILogger _logger;

        public JobExecController(IJobExecService jobExecService, ILoggerFactory loggerFactory)
        {
            _JobExecService = jobExecService;
            _logger = loggerFactory.CreateLogger(nameof(JobExecController));
        }

        /// <summary>
        /// To capture production data for the running job on the specified entity.
        /// </summary>
        /// <param name="entId">Required. An int to identify the entity</param>
        /// <param name="qtyProd">Required. A double specifying the production quantity to be added</param>
        /// <param name="reasCd"></param>
        /// <param name="lotNo"></param>
        /// <param name="rmLotNo"></param>
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
        /// <returns>0 if successful, else -1</returns>
        /// <remarks>
        /// <para>There must be a job running on the specified entity or an error will be returned.  Use the AddProdPostExec() method to enter production after a job has finished running on an entity.</para>
        /// <para>The current shift and job details default to the current values for the entity.</para>
        /// <para>If any of the lot, reason code or entity values are specified then these values are used for this transaction in place of the default ones stored in the job_bom table.These changes are NOT saved to the job_bom table to be used as the defaults for future transactions.
        /// If you wish to change the defaults then use the SetCurLotData() method.</para>
        /// <para>The low number of required parameters are designed to facilitate capturing production data from the I/O system via tags as simply as possible.</para>
        /// <para>If a row already exists for the primary key values supplied (or defaulted) then this quantity will be added to the existing row.  In this case the other specified dependent fields (to_ent_id, ext_ref, spare values etc) are also updated for this row(i.e.including previous quantities).
        /// For any optional parameters that are not specified the existing values are left unchanged.</para>
        /// <para>If a positive amount of good production is being added, it also checks to see whether there is now enough good product available to ready the next job(s) downstream if its state is currently NEW.  This check will eventually encompass all materials, whether produced or merely in inventory.For now, it only checks on materials produced this the same WO.This means finding each next job downstream via the job_route table, and getting its job_bom records excluding those for byproducts (i.e.get those which have a bom_pos greater than or equal to zero).  For every item with a non-zero reqd_start_val, a check is made of the item_prod table for the jobs feeding this one, to see whether they have produced enough for this work order to meet this requirement.If all requirements are met, the job’s state is changed to READY.In deciding whether there has been sufficient production, if reqd_start_val_is_pct is true, the effective required quantity for a particular bom_pos is found by multiplying
        /// reqd_start_val by qty_per_parent_item and multiplying the result by the job’s qty_at_start.
        /// If reqd_start_val_is_pct is false, the effective required quantity is the reqd_start_val.
        /// All requirements for a given item_id are then totaled across all bom_pos values.
        /// The production to count against this item’s requirement is found by adding up all production for any job feeding the downsteam one (which will include the job for which production was initially entered), and multiplying it by job_route.input_pct (expressed as a fraction), which is the portion of the upstream job’s production that goes to the downstream job.
        /// Then the resulting effective production is added for all jobs producing the same item, and compared to each item requirement.
        /// If all item productions are equal to or greater than all item requirements, the job’s state is changed to 2 (READY).
        /// If the update_inv flag is set for this produced item then the qty_left field in the item_inv table will be increased by the produced qty_prod.</para>
        /// <para>If a negative amount of good production is added, a check must be made to see whether there is still enough good product available to ready the next job(s) downstream if its state is currently other than NEW or CANCELLED.  This check need only consider the material produced in the current job.As with the check to ready a job, this will mean finding each next job downstream via the job_route table, and getting its job_bom records for this item, then checking the item_prod table for the jobs feeding this one, to see whether they have produced enough for this work order to meet this requirement.If this requirement is no longer met, the downstream job’s state is changed back to NEW if it is currently READY.  Otherwise a warning is returned saying that because the job was already started it could not be un-readied.If the backflush flag is set for any of the BOM items for this job then consumption transactions will be generated to consume the materials at standard rates.  Similarly, if the update_inv flag is set for any of these BOM items then inventory adjustment transactions will also be applied automatically.</para>
        /// </remarks>
        [HttpPost("AddProd", Name = "AddProd")]
        public IActionResult AddProd(int entId, double qtyProd,
        int? reasCd, string? lotNo, string? rmLotNo, int? toEntId, string? itemId, int? byproductBomPos,
        string? extRef, bool? applyScalingFactor, string? spare1, string? spare2, string? spare3, string? spare4, int? jobPos)
        {
            try
            {
                if (User.Identity == null)
                {
                    throw new Exception("User name not found.");
                }

                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => c.Value).SingleOrDefault();
                _JobExecService.AddProd(entId, qtyProd,reasCd, lotNo, rmLotNo, toEntId, itemId, byproductBomPos, extRef, applyScalingFactor, spare1, spare2, spare3, spare4, jobPos);
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, Message = exp.Message });
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
        /// <param name="shiftStart"></param>
        /// <param name="shiftId"></param>
        /// <param name="itemId"></param>
        /// <param name="reasCd"></param>
        /// <param name="lotNo"></param>
        /// <param name="rmLotNo"></param>
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
        /// <remarks>
        ///<para>The shift and job values are required parameters as the data is being entered after the fact.</para>
        ///<para>The optional parameters are detailed as specified above if they are not specifically included.</para>
        ///<para>If a row already exists for the primary key values supplied (or defaulted) then this quantity will be added to the existing row. In this case the other non-defaulted dependent fields (to_ent_id, processed flag etc) for the ENTIRE row (i.e. including previous quantities) will be changed to those specified by this call.</para>
        ///<para>If the update_inv flag is set for this produced item in the job_bom table then the qty_left field in the item_inv table will be increased by the produced qty_prod.</para>
        ///<para>If the backflush flag is set for any of the BOM items in the job_bom table for this job then consumption transactions will be generated to consume the materials at standard rates.  Similarly, if the update_inv flag is set for any of these BOM items then inventory adjustment transactions will also be applied automatically.</para>
        /// </remarks>
        [HttpPost("AddProdPostExec", Name = "AddProdPostExec")]
        public IActionResult AddProdPostExec(int entId, double qtyProd,
        string woId, string operId, int seqNo, DateTime shiftStart, int shiftId, string? itemId, int? reasCd,
        string? lotNo, string? rmLotNo, int? toEntId, bool? processed, bool? byproduct, string extRef,
        int? moveStatus, string? spare1, string? spare2, string? spare3, string? spare4)
        {
            try
            {
                if (User.Identity == null)
                {
                    throw new Exception("User name not found.");
                }
                var userid = User.Identity.Name;
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => c.Value).SingleOrDefault();

                _JobExecService.AddProdPostExec(entId, qtyProd,
        woId, operId, seqNo, shiftStart, shiftId, itemId, reasCd,
        lotNo, rmLotNo, toEntId, processed, byproduct, extRef,
        moveStatus, spare1, spare2, spare3, spare4);
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, Message = exp.Message });
            }
        }

        /// <summary>
        /// To cancel all jobs in a given work order.
        /// </summary>
        /// <param name="woId"></param>
        /// <returns></returns>
        [HttpPost("CancelAllJobs", Name = "CancelAllJobs")]
        public IActionResult CancelAllJobs(string woId)
        {
            try
            {
                if (User.Identity == null)
                {
                    throw new Exception("User name not found.");
                }
                var sessionId = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                           .Select(c => c.Value).SingleOrDefault();

                _JobExecService.CancelAllJobs(woId);

                return Ok();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, Message = exp.Message });
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
                return BadRequest(new { Status = false, Message = exp.Message });
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
                return BadRequest(new { Status = false, Message = exp.Message });
            }
        }
    }
}

