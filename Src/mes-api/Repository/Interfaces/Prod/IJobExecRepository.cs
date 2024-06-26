﻿//
//  IJobExecRepository.cs
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

using BOL.API.Domain.Models.Prod;

namespace BOL.API.Repository.Interfaces.Prod;

public interface IJobExecRepository : IRepositoryBase<JobExec>
{
    /*
      SETCURLOTDATA
      SETJOBQUEUE
      SETUISCREENTAGVALUES
      STARTSOME
    */

    Task<string> AddProdAsync(int sessionId, string userId, int entId, double qtyProd,
    int? reasCd, string? lotNo, string? sublotNo, int? toEntId, string? itemId, int? byproductBomPos,
    string? extRef, bool applyScalingFactor, string spare1, string spare2, string spare3, string spare4, int jobPos);

    Task<int> AddProdPostExecAsync(int sessionId, string userId, int entId, double qtyProd, string woId, string operId, int seqNo, DateTime shiftStartLocal,
        int shiftId, string? itemId, int? reasCd, string? lotNo, string? sublotNo, int? toEntId, bool? processed, bool? byproduct, string extRef, int? moveStatus,
        string? spare1, string? spare2, string? spare3, string? spare4);

    Task<int> CancelAllJobsAsync(string woId);

    Task<string> ChangeJobStatesAsync(int rowId, int? stateCd, DateTime? reqFinishTimeLocal, int? jobPriority, int? applyToAllJobs);

    Task<int> ChangeWOPriorityAsync(string woId, int newPriority);

    Task<int> ChangeWOReqdFinishTimeAsync(string woId, DateTime reqFinishTimeLocal);

    Task<int> ChangeWOValuesAsync(string woId, int priority, DateTime reqFinishTimeLocal, double qtyReqd, double qtyAtStart);

    Task<int> CloneWoAsync(string userId, string woId, string newWoId, double? reqQty, string? woDesc, DateTime? releaseTimeLocal, DateTime? reqFinishTimeLocal, int? woPriority,
        string? custInfo, string? moId, string? notes);

    Task<int> CreateWoFromProcessAsync(string userId, string woId, string processId, string itemId, double reqQty, double? startQty, int? initWoState,
        string? woDesc, DateTime? releaseTime, DateTime? reqFinishTime, int? woPriority, string? custInfo, string? moId, string? notes, string? bomVerId, bool forFirstOp,
        string? specVerId, bool mayOverrideRoute);

    Task<int> DownloadSpecsAsync(int entId, string woId, string operId, int seqNo, int? stepNo);

    Task<int> EndJobAsync(int entId, string woId, string operId, int seqNo, int jobPos, string? statusNotes, string? userId, int? checkPrivs, int? checkCerts, int clientType,
        int noPropogation, int checkAutoJobStart);

    Task<string> GetAvailJobPosAsync(int entId);

    Task<string> GetAvailLotsAsync(string woId, string operId, int seqNo, int entId);

    Task<string> GetCurrJobPosAsync(int entId, string woId, string operId, int seqNo);

    Task<string> GetJobBOMStepQuantitiesAsync(string woId, string operId, int seqNo, int stepNo);

    Task<string> GetJobQueueAsync(string woId, string itemId);

    Task<string> GetReqdCertSignoffsAsync(string woId, string operId, int stepNo);

    Task<string> GetStepBOMDataAsync(string woId, string operId, int seqNo, int? stepNo);

    Task<int> PauseJobAsync(int entId, string woId, string operId, int seqNo, int pausedJobState, int jobPos, string statusNotes, DateTime? actFinishTimeLocal);

    Task<string> SetJobQueueAsync(string woId, string operId, int seqNo, int? stateCd, int? jobPriority, DateTime? reqFinishTimeLocal, int? targetSchedEntId, int? concurrentLink,
        string statusNotes);

    Task<string> SplitJobAsync(string userId, string woId, string operId, int origSeqNo, double splitQty, int newSeqNo, double? splitStartQty, int? newStateCd, DateTime? reqFinishTime,
        int? targetEntId, string? statusNotes, bool ignoreZeroStartQtyCheck);

    Task<string> StartDataEntryJobAsync(string userId, int entId, string woId, string operId, string itemId, double estProdrate, int prodUom, int? uomId, string? spare1, string? spare2, string? spare3, string? spare4);

    Task<int> StartJobAsync(string userId, int entId, string woId, string operId, int seqNo, int jobPos, string? statusNotes, int? checkPrivs, int? checkCerts);

    Task<string> StartSomeAsync(int sessionId, string userId, string woId, string operId, int seqNo, double qtyAtStart, string? statusNotes, int? checkPrivs, int? checkCerts, int? jobPos, double? qtyReqd);

    Task<string> VerifyProcessAsync(string processId, string? parentItemId, string? woId);

    /*
      {
        "_name": "JOB_EXEC.CREATEJOBSFROMSTDOPS",
        "_value": "SP_I_JOB_EXEC_CRTJOBSFROMSTDOP"
      },
      {
        "_name": "JOB_EXEC.CREATEWOFROMPROCESSQTYS",
        "_value": "SP_I_JOB_EXEC_CWOFP_QTY"
      },
      {
        "_name": "JOB_EXEC.GETITEMSPRODBYDSTRMJOB",
        "_value": "SP_SA_JE_GETITMSPRODBYDSTRMJOB"
      },
      {
        "_name": "JOB_EXEC.GETJOBBOMSTEPQUANTITIES",
        "_value": "SP_SA_JOB_EXEC_GETJBSTEPQUANTS"
      }
    */


}