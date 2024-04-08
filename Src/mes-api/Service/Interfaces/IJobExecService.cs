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
    int noPropogation, int checkAutoJobStart, DateTime? actFinishTimeLocal);










    List<object> GetJobQueue(string woId, string itemId);

    List<object> GetQueue(int entId, int? jobState, DateTime? reqdByTime, int? job_Priority, int? maxRows);
}

