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
      STARTNEXTJOBVIAFC
      STARTSOME
    */

    Task<string> AddConsAsync(int sessionId, string userId, int entId, int jobPos, int bomPos, double qtyCons, int? reasCd, string? lotNo, string? fgLotNo, string? sublotNo, string? fgSublotNo,
        int? fromEntId, string? itemId, string extRef, bool applyScalingFactor, string spare1, string spare2, string spare3, string spare4);

    Task<string> AddConsDirectAsync(int fromEntId, string itemId, string lotNo, string sublotNo, double qtyCons, int reasCd, int gradeCd, int statusCd, string userId,
        string? woId, string? operId, int? seqNo, DateTime? shiftStartLocal, string? fgLotNo, string? fgSublotNo, int itemScrapped,
        int? entId, int? shiftId, double qtyConsErp, string? extRef, int transactionType, string spare1, string spare2, string spare3, string spare4);

    Task<string> AddConsPostExecAsync(int sessionId, string userId, int entId, int? bomPos, double qtyCons, string woId, string operId, int seqNo, DateTime shiftStartLocal,
        int shiftId, string? itemId, int? reasCd, string? lotNo, string? fgLotNo, string? sublotNo, string? fgSublotNo, string? extRef, string spare1, string spare2, string spare3, string spare4);

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



    Task<string> ChangeJobStatesAsync();
    Task<string> ChangeSpecValueAsync();
    Task<string> ChangeSpecValuesAsync();
    Task<string> ChangeWOPriorityAsync();
    Task<string> ChangeWOQtysAsync();
    Task<string> ChangeWOReqdFinishTimeAsync();
    Task<string> ChangeWOValuesAsync();
    Task<string> CloneJobAsync();
    Task<string> CloneWOAsync();
    Task<string> CreateWOFromProcessAsync();
    Task<string> DownloadSpecsAsync();
    Task<string> EndJobAsync();
    Task<string> GetAvailJobPosAsync();
    Task<string> GetAvailLotsAsync();
    Task<string> GetCurrJobPosAsync();
    Task<string> GetJobBOMStepQuantitiesAsync();
    Task<string> GetJobQueueAsync(string woId, string itemId);
    Task<string> GetQueueAsync(int entId, int? jobState, DateTime? reqdByTime, int? job_Priority, int? maxRows);
    Task<string> GetReqdCertSignoffsAsync();
    Task<string> GetRunnableEntitiesAsync();
    Task<string> GetSchedEntsByWindowAsync();
    Task<string> GetSchedulableEntitiesAsync();
    Task<string> GetSchedulableEntityAsync();
    Task<string> GetSchedulableParentsAsync();
    Task<string> GetStepBOMDataAsync();
    Task<string> InsertProdViaFCAsync();
    Task<string> LogJobEventAsync();
    Task<string> PauseJobAsync();
    Task<string> RejectProdAsync();
    Task<string> SetActualSpecValueAsync();
    Task<string> SetAttrAsync();
    Task<string> SetCurLotDataAsync();
    Task<string> SetJobQueueAsync();
    Task<string> SetUIScreenTagValuesAsync();
    Task<string> SplitJobAsync();
    Task<string> StartDataEntryJobAsync();
    Task<string> StartJobAsync();
    Task<string> StartNextJobViaFCAsync();
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
        "_name": "JOB_EXEC.CHANGESPECVALUE",
        "_value": "SP_U_JOB_SPEC_CHANGESPECVALUE"
      },
      {
        "_name": "JOB_EXEC.CHANGESPECVALUES",
        "_value": "SP_U_JOB_SPEC_CHANGESPECVALUES"
      },
      {
        "_name": "JOB_EXEC.CHANGEWOQTYS",
        "_value": "SP_ALLOC_JOB_QTY"
      },
      {
        "_name": "JOB_EXEC.CHANGEWOREQFINISHTIME",
        "_value": "SP_U_JOB_EXEC_CHWOREQFINTIME"
      },
      {
        "_name": "JOB_EXEC.CLONEJOB",
        "_value": "SP_I_JOB_EXEC_CLONEJOB"
      },
      {
        "_name": "JOB_EXEC.CLONEWO",
        "_value": "SP_I_JOB_EXEC_CLONEWO"
      },
      {
        "_name": "JOB_EXEC.CREATEJOBSFROMSTDOPS",
        "_value": "SP_I_JOB_EXEC_CRTJOBSFROMSTDOP"
      },
      {
        "_name": "JOB_EXEC.CREATEWOFROMPROCESS",
        "_value": "SP_I_JOB_EXEC_CWOFP_STACK"
      },
      {
        "_name": "JOB_EXEC.CREATEWOFROMPROCESSQTYS",
        "_value": "SP_I_JOB_EXEC_CWOFP_QTY"
      },
      {
        "_name": "JOB_EXEC.ENDJOB",
        "_value": "SP_U_JOB_EXEC_ENDBATCHJOBS"
      },
      {
        "_name": "JOB_EXEC.GETAVAILJOBPOS",
        "_value": "SP_SA_JOB_EXEC_GETAVAILJOBPOS"
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
        "_name": "JOB_EXEC.GETREQDCERTSIGNOFFS",
        "_value": "SP_SA_JOB_EXEC_GETREQDSIGNOFFS"
      },
      {
        "_name": "JOB_EXEC.GETRUNNABLEENTITIES",
        "_value": "SP_SA_ENT_GETRUNNABLEENTITIES"
      },
      {
        "_name": "JOB_EXEC.GETSCHEDENTSBYWINDOW",
        "_value": "SP_SA_JOB_EXEC_GETSCHEDENTS"
      },
      {
        "_name": "JOB_EXEC.GETSCHEDULABLEENTITIES",
        "_value": "SP_SA_JOB_EXEC_GETSCHEDENTS"
      },
      {
        "_name": "JOB_EXEC.GETSCHEDULABLEENTITY",
        "_value": "SP_SA_ENT_GETSCHEDULABLEENTITY"
      },
      {
        "_name": "JOB_EXEC.GETSCHEDULABLEPARENTS",
        "_value": "SP_SA_ENT_GETSCHEDPARENTS"
      },
      {
        "_name": "JOB_EXEC.INSERTPRODVIAFC",
        "_value": "SP_I_ITEM_PROD_INSERTPRODVIAFC"
      },
      {
        "_name": "JOB_EXEC.ISSAMEPRODUCED",
        "_value": "SP_SA_ITEM_PROD_ISSAMEPRODUCED"
      },
      {
        "_name": "JOB_EXEC.LOGJOBEVENT",
        "_value": "SP_I_JOB_EVENT"
      },
      {
        "_name": "JOB_EXEC.PAUSEJOB",
        "_value": "SP_U_JOB_EXEC_PAUSEBATCHJOBS"
      },
      {
        "_name": "JOB_EXEC.REJECTPROD",
        "_value": "SP_I_ITEM_PROD_SPLIT"
      },
      {
        "_name": "JOB_EXEC.SETACTUALSPECVALUE",
        "_value": "SP_U_JOB_SPEC_SETACTSPECVALUE"
      },
      {
        "_name": "JOB_EXEC.SETATTR",
        "_value": "SP_U_JOB_ATTR_SETATTR"
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