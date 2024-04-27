using BOL.API.Repository.Interfaces.Cert;
using BOL.API.Repository.Interfaces.Core;
using BOL.API.Repository.Interfaces.EnProd;
using BOL.API.Repository.Interfaces.Prod;
using BOL.API.Service.Interfaces;

namespace BOL.API.Service.Services;

public class JobExecService : IJobExecService
{
    private readonly ICertRepository _certRepository;
    private readonly IEntRepository _entRepository;
    private readonly IJobRepository _jobRepository;
    private readonly IJobEventRepository _jobEventRepository;
    private readonly IJobExecRepository _jobExecRepository;
    private readonly IJobSpecRepository _jobSpecRepository;
    private readonly IJobStepRepository _jobStepRepository;
    private readonly IItemConsRepository _itemConsRepository;
    private readonly IItemProdRepository _itemProdRepository;
    private readonly ILogger _logger;

    public JobExecService(IJobExecRepository jobExecRepository,
                          IItemConsRepository itemConsRepository,
                          IItemProdRepository itemProdRepository,
                          ICertRepository certRepository,
                          IJobRepository jobRepository,
                          IJobEventRepository jobEventRepository,
                          IJobSpecRepository jobSpecRepository,
                          IJobStepRepository jobStepRepository,
                          IEntRepository entRepository,
                          ILoggerFactory loggerFactory)
    {
        _certRepository = certRepository;
        _entRepository = entRepository;
        _jobRepository = jobRepository;
        _jobEventRepository = jobEventRepository;
        _jobExecRepository = jobExecRepository;
        _jobSpecRepository = jobSpecRepository;
        _jobStepRepository = jobStepRepository;
        _itemConsRepository = itemConsRepository;
        _itemProdRepository = itemProdRepository;
        _logger = loggerFactory.CreateLogger(nameof(JobExecService));

    }

    public async Task<string> AddConsAsync(int sessionId, string userId, int entId, int jobPos, int bomPos, double qtyCons, int? reasCd, string? lotNo, string? fgLotNo, string? sublotNo, string? fgSublotNo,
        int? fromEntId, string? itemId, string extRef, bool applyScalingFactor, string spare1, string spare2, string spare3, string spare4)
    {
        return await _itemConsRepository.AddConsAsync(sessionId, userId, entId, jobPos, bomPos, qtyCons, reasCd, lotNo, fgLotNo, sublotNo, fgSublotNo,
                            fromEntId, itemId, extRef, applyScalingFactor, spare1, spare2, spare3, spare4);
    }

    public async Task<string> AddConsDirectAsync(int fromEntId, string itemId, string lotNo, string sublotNo, double qtyCons, int reasCd, int gradeCd, int statusCd, string userId,
        string? woId, string? operId, int? seqNo, DateTime? shiftStartLocal, string? fgLotNo, string? fgSublotNo, int itemScrapped,
        int? entId, int? shiftId, double qtyConsErp, string? extRef, int transactionType, string spare1, string spare2, string spare3, string spare4)
    {
        return await _itemConsRepository.AddConsDirectAsync(fromEntId, itemId, lotNo, sublotNo, qtyCons, reasCd, gradeCd, statusCd, userId,
                            woId, operId, seqNo, shiftStartLocal, fgLotNo, fgSublotNo, itemScrapped, entId, shiftId, qtyConsErp, extRef,
                            transactionType, spare1, spare2, spare3, spare4);
    }

    public async Task<string> AddConsPostExecAsync(int sessionId, string userId, int entId, int? bomPos, double qtyCons, string woId, string operId, int seqNo, DateTime shiftStartLocal,
    int shiftId, string? itemId, int? reasCd, string? lotNo, string? fgLotNo, string? sublotNo, string? fgSublotNo, string? extRef, string spare1, string spare2, string spare3, string spare4)
    {
        return await _itemConsRepository.AddConsPostExecAsync(sessionId, userId, entId, bomPos, qtyCons, woId, operId, seqNo, shiftStartLocal,
                            shiftId, itemId, reasCd, lotNo, fgLotNo, sublotNo, fgSublotNo, extRef, spare1, spare2, spare3, spare4);
    }


    public async Task<string> AddProdAsync(int sessionId, string userId, int entId, double qtyProd, int? reasCd = null, string? lotNo = null, string? sublotNo = null,
        int? toEntId = null, string? itemId = null, int? byproductBomPos = null, string? extRef = null, bool applyScalingFactor = false, string spare1 = " ",
        string spare2 = " ", string spare3 = " ", string spare4 = " ", int jobPos = 0)
    {
        return await _jobExecRepository.AddProdAsync(sessionId, userId, entId, qtyProd, reasCd, lotNo, sublotNo, toEntId, itemId, byproductBomPos, extRef, applyScalingFactor, spare1, spare2, spare3, spare4, jobPos);
    }

    public async Task<int> AddProdPostExecAsync(int sessionId, string userId, int entId, double qtyProd, string woId, string operId, int seqNo, DateTime shiftStartLocal,
        int shiftId, string? itemId, int? reasCd, string? lotNo, string? sublotNo, int? toEntId, bool? processed, bool? byproduct, string extRef, int? moveStatus,
        string? spare1, string? spare2, string? spare3, string? spare4)
    {
        return await _jobExecRepository.AddProdPostExecAsync(sessionId, userId, entId, qtyProd, woId, operId, seqNo, shiftStartLocal, shiftId, itemId, reasCd, lotNo, sublotNo,
            toEntId, processed, byproduct, extRef, moveStatus, spare1, spare2, spare3, spare4);
    }

    public async Task<int> CancelAllJobsAsync(string woId)
    {
        return await _jobExecRepository.CancelAllJobsAsync(woId);
    }

    public async Task<string> CertSignOffAsync(string woId, string operId, int seqNo, int? stepNo, string lotNo, int prodLogId, int consLogId, string processId, int processStatus,
        bool active, string certName, string userId, DateTime? signOffLocal, string? comments, int refRowId)
    {
        return await _certRepository.CertSignoffAsync(woId, operId, seqNo, stepNo, lotNo, prodLogId, consLogId, processId, processStatus, active, certName, userId,
            signOffLocal, comments, refRowId);
    }

    public async Task<int> CertSignoffAllowedAsync(string userId, string processId, string operId, int? stepNo, string? certName)
    {
        return await _certRepository.CertSignoffAllowedAsync(userId, processId, operId, stepNo, certName);
    }

    public async Task<string> CertSignoffDoneAsync(string woId, string operId, int seqNo, int? stepNo, string? certName, string? lotNo, int? prodLogId, int? consLogId,
        string? processId, int? processStatus, bool? active)
    {
        return await _certRepository.CertSignoffDoneAsync(woId, operId, seqNo, stepNo, certName, lotNo, prodLogId, consLogId, processId, processStatus, active);
    }

    public async Task<string> CertSignoffReqdAsync(string processId, string operId, int? stepNo)
    {
        return await _certRepository.CertSignoffReqdAsync(processId, operId, stepNo);
    }

    public async Task<int> CertStartAllowedAsync(string userId, string? processId, string? operId, int? stepNo, string? itemId)
    {
        return await _certRepository.CertStartAllowedAsync(userId, processId, operId, stepNo, itemId);
    }

    public async Task<string> ChangeJobStatesAsync(int rowId, int? stateCd, DateTime? reqFinishTimeLocal, int? jobPriority, int? applyToAllJobs)
    {
        return await _jobExecRepository.ChangeJobStatesAsync(rowId, stateCd, reqFinishTimeLocal, jobPriority, applyToAllJobs);
    }

    public async Task<int> ChangeSpecValueAsync(string userId, int entId, string specId, string newSpecValue, bool updateTemplate, int bomPos = 0, string? bomVerId = null, string? comments = null, int jobPos = 0)
    {
        return await _jobSpecRepository.ChangeSpecValueAsync(userId, entId, specId, newSpecValue, updateTemplate, bomPos, bomVerId, comments, jobPos);
    }

    public async Task<int> ChangeSpecValuesAsync(int sessionId, string userId, int entId, string? newSpecValue, string? newMinValue, string? newMaxValue, bool updateTemplate = false, int checkPrivs = 0,
        int bomPos = 0, string? bomVerId = null, string comments = "", int jobPos = 0)
    {
        return await _jobSpecRepository.ChangeSpecValuesAsync(sessionId, userId, entId, newSpecValue, newMinValue, newMaxValue, updateTemplate, checkPrivs, bomPos, bomVerId, comments, jobPos);
    }

    public async Task<int> ChangeWOPriorityAsync(string woId, int newPriority)
    {
        return await _jobExecRepository.ChangeWOPriorityAsync(woId, newPriority);
    }

    public async Task<int> ChangeWOQtysAsync(string userId, string woId, double reqQty, string? processId = null, string? itemId = null, double? startQty = null, DateTime? reqFinishTime = null, DateTime? releaseTime = null)
    {
        return await _jobRepository.ChangeWOQtysAsync(userId, woId, reqQty, processId, itemId, startQty, reqFinishTime, releaseTime);
    }

    public async Task<int> ChangeWOReqdFinishTimeAsync(string woId, DateTime reqFinishTimeLocal)
    {
        return await _jobExecRepository.ChangeWOReqdFinishTimeAsync(woId, reqFinishTimeLocal);
    }

    public async Task<int> ChangeWOValuesAsync(string woId, int priority, DateTime reqFinishTimeLocal, double qtyReqd, double qtyAtStart)
    {
        return await _jobExecRepository.ChangeWOValuesAsync(woId, priority, reqFinishTimeLocal, qtyReqd, qtyAtStart);
    }

    public async Task<int> CloneJobAsync(string userId, string woId, string operId, int seqNo, string? newWoId, string? newOperId, int? newSeqNo, double? reqQty, double? startQty, DateTime? reqFinishTimeLocal)
    {
        return await _jobRepository.CloneJobAsync(userId, woId, operId, seqNo, newWoId, newOperId, newSeqNo, reqQty, startQty, reqFinishTimeLocal);
    }

    public async Task<int> CloneWoAsync(string userId, string woId, string newWoId, double? reqQty, string? woDesc, DateTime? releaseTimeLocal, DateTime? reqFinishTimeLocal, int? woPriority, string? custInfo, string? moId, string? notes)
    {
        return await _jobExecRepository.CloneWoAsync(userId, woId, newWoId, reqQty, woDesc, releaseTimeLocal, reqFinishTimeLocal, woPriority, custInfo, moId, notes);
    }

    public async Task<int> CreateWoFromProcessAsync(string userId, string woId, string processId, string itemId, double reqQty, double? startQty = null, int? initWoState = 1,
        string? woDesc = null, DateTime? releaseTime = null, DateTime? reqFinishTime = null, int? woPriority = 1, string? custInfo = null, string? moId = null, string? notes = "",
        string? bomVerId = null, bool forFirstOp = false, string? specVerId = null, bool mayOverrideRoute = false)
    {
        return await _jobExecRepository.CreateWoFromProcessAsync(userId, woId, processId, itemId, reqQty, startQty, initWoState, woDesc, releaseTime, reqFinishTime, woPriority,
            custInfo, moId, notes, bomVerId, forFirstOp, specVerId, mayOverrideRoute);
    }

    public async Task<int> DownloadSpecsAsync(int entId, string woId, string operId, int seqNo, int? stepNo = -1)
    {
        return await _jobExecRepository.DownloadSpecsAsync(entId, woId, operId, seqNo, stepNo);
    }

    public async Task<int> EndJobAsync(int entId, string woId, string operId, int seqNo, int jobPos = 0, string? statusNotes = null, string? userId = null, int? checkPrivs = null,
        int? checkCerts = null, int clientType = 37, int noPropogation = 0, int checkAutoJobStart = 1)
    {
        return await _jobExecRepository.EndJobAsync(entId, woId, operId, seqNo, jobPos, statusNotes, userId, checkPrivs, checkCerts, clientType, noPropogation, checkAutoJobStart);
    }

    public async Task<string> GetAvailJobPosAsync(int entId)
    {
        return await _jobExecRepository.GetAvailJobPosAsync(entId);
    }

    public async Task<string> GetAvailLotsAsync(string woId, string operId, int seqNo, int entId)
    {
        return await _jobExecRepository.GetAvailLotsAsync(woId, operId, seqNo, entId);
    }

    public async Task<string> GetCurrJobPosAsync(int entId, string woId, string operId, int seqNo)
    {
        return await _jobExecRepository.GetCurrJobPosAsync(entId, woId, operId, seqNo);
    }

    public async Task<string> GetJobBOMStepQuantitiesAsync(string woId, string operId, int seqNo, int stepNo)
    {
        return await _jobExecRepository.GetJobBOMStepQuantitiesAsync(woId, operId, seqNo, stepNo);
    }

    public async Task<string> GetJobQueueAsync(string woId, string itemId)
    {
        return await _jobExecRepository.GetJobQueueAsync(woId, itemId);
    }

    public async Task<string> GetJobQueueByFilterAsync(string entFilter, string jobFilter)
    {
        return await _jobRepository.GetJobQueueByFilterAsync(entFilter, jobFilter);
    }

    public async Task<string> GetReqdCertSignoffsAsync(string woId, string operId, int stepNo)
    {
        return await _jobExecRepository.GetReqdCertSignoffsAsync(woId, operId, stepNo);
    }

    public async Task<string> GetRunnableEntitiesAsync(int entId)
    {
        return await _entRepository.GetRunnableEntitiesAsync(entId);
    }

    public async Task<string> GetSchedEntsByWindowAsync(string woId = null, string operId = null, int windowId = 0)
    {
        return await _entRepository.GetSchedEntsByWindowAsync(woId, operId, windowId);
    }

    public async Task<string> GetSchedulableEntityAsync(int entId)
    {
        return await _entRepository.GetSchedulableEntityAsync(entId);
    }

    public async Task<string> GetSchedulableParentsAsync(int entId)
    {
        return await _entRepository.GetSchedulableParentsAsync(entId);
    }

    public async Task<string> GetStepBOMDataAsync(string woId, string operId, int seqNo, int? stepNo = null)
    {
        return await _jobExecRepository.GetStepBOMDataAsync(woId, operId, seqNo, stepNo);
    }

    public async Task<string> LogJobEventAsync(int entId, DateTime eventTimeLocal, int jobPos, int stepNo, string eventType, int bomPos, string lotNo, string sublotNo, string itemId, string certName, string doneByUserId,
        string checkedByUserId, int sourceRowId, string specId, string comments, string value1, string value2, string value3, string value4, string value5, string value6, string value7, string value8, string value9,
        string value10, string lastEditComment)
    {
        return await _jobEventRepository.LogJobEventAsync(entId, eventTimeLocal, jobPos, stepNo, eventType, bomPos, lotNo, sublotNo, itemId, certName, doneByUserId,
        checkedByUserId, sourceRowId, specId, comments, value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, lastEditComment);
    }

    public async Task<int> PauseJobAsync(int entId, string woId, string operId, int seqNo, int pausedJobState, int jobPos = 0, string statusNotes = null, DateTime? actFinishTimeLocal = null)
    {
        return await _jobExecRepository.PauseJobAsync(entId, woId, operId, seqNo, pausedJobState, jobPos, statusNotes, actFinishTimeLocal);

    }

    public async Task<int> RejectProdAsync(int sessionId, int oldRowId, double splitQtyProd, string newWoId = null, string newOperId = null, int? newSeqNo = null, DateTime? newShiftStartLocal = null,
    string newItemId = null, string newLotNo = null, string newRmLotNo = null, string newSublotNo = null, string newRmSublotNo = null, int? newReasCd = null, string newUserId = null, int? newEntId = null,
    int? newShiftId = null, int? newToEntId = null, double? splitQtyProdErp = null, bool splitProcessedFlag = false, bool splitByproductFlag = false)
    {
        return await _itemProdRepository.RejectProdAsync(sessionId, oldRowId, splitQtyProd, newWoId, newOperId, newSeqNo, newShiftStartLocal, newItemId, newLotNo, newRmLotNo, newSublotNo, newRmSublotNo,
            newReasCd, newUserId, newEntId, newShiftId, newToEntId, splitQtyProdErp, splitProcessedFlag, splitByproductFlag);
    }

    public async Task<int> SetCurLotDataAsync(int entId, int jobPos, int bomPos, string curItemId, string curLotNo, string curSublotNo, int curReasCd, int curStorageEntId, bool curUpdateInv, bool curBackflush)
    {
        return await _itemProdRepository.SetCurLotDataAsync(entId, jobPos, bomPos, curItemId, curLotNo, curSublotNo, curReasCd, curStorageEntId, curUpdateInv, curBackflush);
    }

    public async Task<string> IsSameProducedAsync(string woId, string operId, int? seqNo, string? itemId)
    {
        return await _itemProdRepository.IsSameProducedAsync(woId, operId, seqNo, itemId);
    }

    public async Task<string> SplitJobAsync(string userId, string woId, string operId, int origSeqNo, double splitQty, int newSeqNo, double? splitStartQty = null, int? newStateCd = null,
        DateTime? reqFinishTime = null, int? targetEntId = null, string? statusNotes = null, bool ignoreZeroStartQtyCheck = false)
    {
        return await _jobExecRepository.SplitJobAsync(userId, woId, operId, origSeqNo, splitQty, newSeqNo, splitStartQty,  newStateCd,  reqFinishTime, targetEntId,
            statusNotes, ignoreZeroStartQtyCheck);
    }

    public async Task<string> StartDataEntryJobAsync(string userId, int entId, string woId, string operId, string itemId, double estProdrate, int prodUom, int? uomId = null,
    string? spare1 = null, string? spare2 = null, string? spare3 = null, string? spare4 = null)
    {
        return await _jobExecRepository.StartDataEntryJobAsync(userId, entId, woId, operId, itemId, estProdrate, prodUom, uomId,  spare1, spare2, spare3, spare4);
    }

    public async Task<int> StartJobAsync(string userId, int entId, string woId, string operId, int seqNo, int jobPos = 0, string? statusNotes = null, int? checkPrivs = null, int? checkCerts = null)
    {
        return await _jobExecRepository.StartJobAsync(userId, entId, woId, operId, seqNo, jobPos, statusNotes, checkPrivs, checkCerts);
    }

    public async Task<string> StartSomeAsync(int sessionId, string userId, string woId, string operId, int seqNo, double qtyAtStart, string? statusNotes = null, int? checkPrivs = null, int? checkCerts = null, int? jobPos = null, double? qtyReqd = null)
    {
        return await _jobExecRepository.StartSomeAsync(sessionId, userId, woId, operId, seqNo, qtyAtStart, statusNotes, checkPrivs, checkCerts, jobPos, qtyReqd);
    }

    public async Task<int> StartStepAsync(int sessionId, string userId, int jobPos, int stepNo, string lotNo, string sublotNo, int? stateCd = null, bool? checkCert = null, bool? laborOption = null)
    {
        return await _jobStepRepository.StartStepAsync(sessionId, userId, jobPos, stepNo, lotNo, sublotNo, stateCd, checkCert, laborOption);
    }

    public async Task<int> StepLoginAsync(int sessionId, string userId, int entId, int stepNo, int jobPos, string lotNo, string sublotNo, string labCd = null, string deptId = null, DateTime? eventTimeLocal = null)
    {
        return await _jobStepRepository.StepLoginAsync(sessionId, userId, entId, stepNo, jobPos, lotNo, sublotNo, labCd, deptId, eventTimeLocal);
    }

    public async Task<int> StepLogoutAsync(int sessionId, string userId, int entId, int stepNo, string lotNo, string sublotNo, DateTime? eventTimeLocal = null)
    {
        return await _jobStepRepository.StepLogoutAsync(sessionId, userId, entId, stepNo, lotNo, sublotNo, eventTimeLocal);
    }

    public async Task<int> StopStepAsync(int sessionId, string userId, int entId, int jobPos, int stepNo, string lotNo, string sublotNo, int? stateCd = null, bool? checkCert = null, bool? laborOption = null)
    {
        return await _jobStepRepository.StopStepAsync(sessionId, userId, entId, jobPos, stepNo, lotNo, sublotNo, stateCd, checkCert, laborOption);
    }

    public async Task<int> UpdateStepDataAsync(int sessionId, string userId, int entId, int jobPos, int stepNo, string lotNo, string sublotNo, string data)
    {
        return await _jobStepRepository.UpdateStepDataAsync(sessionId, userId, entId, jobPos, stepNo, lotNo, sublotNo, data);
    }

    public async Task<int> UpdateTemplateSpecValuesAsync(int sessionId, string userId, int entId, int? checkPrivs, int? jobPos)
    {
        return await _jobSpecRepository.UpdateTemplateSpecValuesAsync(sessionId, userId, entId, checkPrivs, jobPos);
    }

    public async Task<string> VerifyProcessAsync(string processId, string? parentItemId = null, string? woId = null)
    {
        return await _jobExecRepository.VerifyProcessAsync(processId, parentItemId, woId);
    }
}