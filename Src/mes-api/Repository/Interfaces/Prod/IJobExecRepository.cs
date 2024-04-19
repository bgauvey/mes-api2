//
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

    Task<string> CertSignoffAsync(string woId, string operId, int seqNo, int? stepNo, string lotNo, int prodLogId, int consLogId, string processId, int processStatus,
        bool active, string certName, string userId, DateTime? signOffLocal, string? comments, int refRowId);

    Task<int> CertSignoffAllowedAsync(string userId, string processId, string operId, int? stepNo, string? certName);

    Task<string> CertSignoffDoneAsync(string woId, string operId, int seqNo, int? stepNo, string? certName, string? lotNo, int? prodLogId, int? consLogId,
        string? processId, int? processStatus, bool? active);

    Task<string> CertSignoffReqdAsync(string processId, string operId, int? stepNo);

    Task<int> CertStartAllowedAsync(string userId, string? processId, string? operId, int? stepNo, string? itemId);

    Task<string> ChangeJobStatesAsync(int rowId, int? stateCd, DateTime? reqFinishTimeLocal, int? jobPriority, int? applyToAllJobs);

    Task<int> ChangeWOPriorityAsync(string woId, int newPriority);

    Task<int> ChangeWOQtysAsync(string userId, string woId, double reqQty, string? processId, string? itemId, double? startQty, DateTime? reqFinishTime, DateTime? releaseTime);

    Task<int> ChangeWOReqdFinishTimeAsync(string woId, DateTime reqFinishTimeLocal);

    Task<int> ChangeWOValuesAsync(string woId, int priority, DateTime reqFinishTimeLocal, double qtyReqd, double qtyAtStart);

    Task<int> CloneJobAsync(string userId, string woId, string operId, int seqNo, string? newWoId, string? newOperId, int? newSeqNo, double? reqQty, double? startQty,
        DateTime? reqFinishTimeLocal);

    Task<int> CloneWoAsync(string userId, string woId, string newWoId, double? reqQty, string? woDesc, DateTime? releaseTimeLocal, DateTime? reqFinishTimeLocal, int? woPriority,
        string? custInfo, string? moId, string? notes);

    Task<int> CreateWoFromProcessAsync(string userId, string woId, string processId, string itemId, double reqQty, double? startQty, int? initWoState,
        string? woDesc, DateTime? releaseTime, DateTime? reqFinishTime, int? woPriority, string? custInfo, string? moId, string? notes, string? bomVerId, bool forFirstOp, string? specVerId, bool mayOverrideRoute);

    Task<int> DownloadSpecsAsync(int entId, string woId, string operId, int seqNo, int? stepNo);

    Task<int> EndJobAsync(int entId, string woId, string operId, int seqNo, int jobPos, string? statusNotes, string? userId, int? checkPrivs, int? checkCerts, int clientType,
        int noPropogation, int checkAutoJobStart);

    Task<string> GetAvailJobPosAsync(int entId);

    Task<string> GetAvailLotsAsync(string woId, string operId, int seqNo, int entId);

    Task<string> GetCurrJobPosAsync(int entId, string woId, string operId, int seqNo);

    Task<string> GetJobBOMStepQuantitiesAsync(string woId, string operId, int seqNo, int stepNo);

    Task<string> GetJobQueueAsync(string woId, string itemId);

    Task<string> GetJobQueueByFilterAsync(string entFilter, string jobFilter);

    Task<string> GetReqdCertSignoffsAsync(string woId, string operId, int stepNo);

    Task<string> GetRunnableEntitiesAsync(int entId);

    Task<string> GetSchedEntsByWindowAsync(string woId, string operId, int windowId);

    Task<string> GetSchedulableEntityAsync(int entId);

    Task<string> GetSchedulableParentsAsync(int entId);

    Task<string> GetStepBOMDataAsync(string woId, string operId, int seqNo, int? stepNo);

    Task<string> LogJobEventAsync(int entId, DateTime eventTimeLocal, int jobPos, int stepNo, string eventType, int bomPos, string lotNo, string sublotNo, string itemId, string certName, string doneByUserId,
        string checkedByUserId, int sourceRowId, string specId, string comments, string value1, string value2, string value3, string value4, string value5, string value6, string value7, string value8, string value9,
        string value10, string lastEditComment);

    Task<int> PauseJobAsync(int entId, string woId, string operId, int seqNo, int pausedJobState, int jobPos, string statusNotes, DateTime? actFinishTimeLocal);

    Task<int> RejectProdAsync(int sessionId, int oldRowId, double splitQtyProd, string newWoId, string newOperId, int? newSeqNo, DateTime? newShiftStartLocal, string newItemId, string newLotNo,
        string newRmLotNo, string newSublotNo, string newRmSublotNo, int? newReasCd, string newUserId, int? newEntId, int? newShiftId, int? newToEntId, double? splitQtyProdErp, bool splitProcessedFlag, bool splitByproductFlag);

    Task<int> SetCurLotDataAsync(int entId, int jobPos, int bomPos, string curItemId, string curLotNo, string curSublotNo, int curReasCd, int curStorageEntId, bool curUpdateInv, bool curBackflush);

    Task<string> SetJobQueueAsync(string woId, string operId, int seqNo, int? stateCd, int? jobPriority, DateTime? reqFinishTimeLocal, int? targetSchedEntId, int? concurrentLink, string statusNotes);


    Task<string> SetUIScreenTagValuesAsync();
    Task<string> SplitJobAsync();
    Task<string> StartDataEntryJobAsync();
    Task<string> StartJobAsync();
    Task<string> StartSomeAsync();
    Task<string> StartStepAsync();
    Task<string> StepLoginAsync();
    Task<string> StepLogoutAsync();
    Task<string> StopStepAsync();

    Task<string> TransQtyToCurJobAsync();
    Task<string> UpdateStepDataAsync();
    Task<string> UpdateTemplateSpecValuesAsync();
    Task<string> VerifyProcessAsync();

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
      },
      {
        "_name": "JOB_EXEC.ISSAMEPRODUCED",
        "_value": "SP_SA_ITEM_PROD_ISSAMEPRODUCED"
      },


      {
        "_name": "JOB_EXEC.SPLITJOB",
        "_value": "SP_I_JOB_EXEC_SPLITJOB"
      },
      {
        "_name": "JOB_EXEC.STARTDATAENTRYJOB",
        "_value": "SP_U_JOB_EXEC_STRTDATAENTRYJOB"
      },
      {
        "_name": "JOB_EXEC.STARTJOB",
        "_value": "SP_U_JOB_EXEC_STARTBATCHJOBS"
      },
      {
        "_name": "JOB_EXEC.STARTSTEP",
        "_value": "SP_U_JOB_STEP_STARTSTEP"
      },
      {
        "_name": "JOB_EXEC.STEPLOGIN",
        "_value": "SP_U_JOB_STEP_STEPLOGIN"
      },
      {
        "_name": "JOB_EXEC.STEPLOGOUT",
        "_value": "SP_U_JOB_STEP_STEPLOGOUT"
      },
      {
        "_name": "JOB_EXEC.STOPSTEP",
        "_value": "SP_U_JOB_STEP_STOPSTEP"
      },
      {
        "_name": "JOB_EXEC.UPDATESTEPDATA",
        "_value": "SP_U_JOB_STEP_UPDATESTEPDATA"
      },
      {
        "_name": "JOB_EXEC.UPDATETEMPLATESPECVALUES",
        "_value": "SP_U_JOB_SPEC_UPDTEMPLSPECVALS"
      },
      {
        "_name": "JOB_EXEC.VERIFYPROCESS",
        "_value": "SP_S_JOB_EXEC_VERIFYPROCESS"
      },
      {
        "_name": "JOB_EXEC_STORAGE_EXEC_LINK.ADD",
        "_value": "SP_I_JOB_EXEC_STORAGE_EXC_LNK"
      },
      {
        "_name": "JOB_EXEC_STORAGE_EXEC_LINK.DELETE",
        "_value": "SP_D_JOB_EXEC_STORAGE_EXEC_LNK"
      },
      {
        "_name": "JOB_EXEC_STORAGE_EXEC_LINK.GETALL",
        "_value": "SP_SA_JOB_EXEC_STORAGE_EXC_LNK"
      },
      {
        "_name": "JOB_EXEC_STORAGE_EXEC_LINK.GETALLBYXML",
        "_value": "SP_SA_JOB_EXEC_STORAGE_EXC_LNK"
      },
      {
        "_name": "JOB_EXEC_STORAGE_EXEC_LINK.GETBYKEY",
        "_value": "SP_S_JOB_EXEC_STORAGE_EXEC_LNK"
      },
      {
        "_name": "JOB_EXEC_STORAGE_EXEC_LINK.UPDATE",
        "_value": "SP_U_JOB_EXEC_STORAGE_EXEC_LNK"
      },
    */


}