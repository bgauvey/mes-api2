using System;
namespace BOL.API.Service.Interfaces;

public interface IJobExecService
{

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

    Task<string> CertSignOffAsync(string woId, string operId, int seqNo, int? stepNo, string lotNo, int prodLogId, int consLogId, string processId, int processStatus,
        bool active, string certName, string userId, DateTime? signOffLocal, string? comments, int refRowId);

    Task<int> CertSignoffAllowedAsync(string userId, string processId, string operId, int? stepNo, string? certName);

    Task<string> CertSignoffDoneAsync(string woId, string operId, int seqNo, int? stepNo, string? certName, string? lotNo, int? prodLogId, int? consLogId,
        string? processId, int? processStatus, bool? active);

    Task<string> CertSignoffReqdAsync(string processId, string operId, int? stepNo);

    Task<int> CertStartAllowedAsync(string userId, string? processId, string? operId, int? stepNo, string? itemId);

    Task<string> ChangeJobStatesAsync(int rowId, int? stateCd, DateTime? reqFinishTimeLocal, int? jobPriority, int? applyToAllJobs);

    Task<int> ChangeSpecValueAsync(string userId, int entId, string specId, string newSpecValue, bool updateTemplate, int bomPos, string? bomVerId, string? comments, int jobPos);

    Task<int> ChangeSpecValuesAsync(int sessionId, string userId, int entId, string? newSpecValue, string? newMinValue, string? newMaxValue, bool updateTemplate, int checkPrivs,
        int bomPos, string? bomVerId, string comments, int jobPos);

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

    Task<string> IsSameProducedAsync(string woId, string operId, int? seqNo, string? itemId);

    Task<int> UpdateTemplateSpecValuesAsync(int sessionId, string userId, int entId, int? checkPrivs, int? jobPos);
}

