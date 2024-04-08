using BOL.API.Repository.Interfaces.Prod;
using BOL.API.Service.Interfaces;

namespace BOL.API.Service.Services;

public class JobExecService : IJobExecService
{
	private readonly IJobExecRepository _jobExecRepository;
	private readonly ILogger _logger;

	public JobExecService(IJobExecRepository jobExecRepository, ILoggerFactory loggerFactory)
	{
		_jobExecRepository = jobExecRepository;
		_logger = loggerFactory.CreateLogger(nameof(JobExecService));

    }

    public async Task<string> AddConsAsync(int sessionId, string userId, int entId, int jobPos, int bomPos, double qtyCons, int? reasCd, string? lotNo, string? fgLotNo, string? sublotNo, string? fgSublotNo,
        int? fromEntId, string? itemId, string extRef, bool applyScalingFactor, string spare1, string spare2, string spare3, string spare4)
    {
        return await _jobExecRepository.AddConsAsync(sessionId, userId, entId, jobPos, bomPos, qtyCons, reasCd, lotNo,  fgLotNo,  sublotNo, fgSublotNo,
                            fromEntId, itemId, extRef, applyScalingFactor, spare1, spare2, spare3, spare4);
    }

    public async Task<string> AddConsDirectAsync(int fromEntId, string itemId, string lotNo, string sublotNo, double qtyCons, int reasCd, int gradeCd, int statusCd, string userId,
        string? woId, string? operId, int? seqNo, DateTime? shiftStartLocal, string? fgLotNo, string? fgSublotNo, int itemScrapped,
        int? entId, int? shiftId, double qtyConsErp, string? extRef, int transactionType, string spare1, string spare2, string spare3, string spare4)
    {
        return await _jobExecRepository.AddConsDirectAsync(fromEntId, itemId, lotNo, sublotNo, qtyCons, reasCd, gradeCd, statusCd, userId,
                            woId, operId, seqNo, shiftStartLocal, fgLotNo, fgSublotNo, itemScrapped, entId, shiftId, qtyConsErp, extRef,
                            transactionType, spare1, spare2, spare3, spare4);
    }

    public async Task<string> AddConsPostExecAsync(int sessionId, string userId, int entId, int? bomPos, double qtyCons, string woId, string operId, int seqNo, DateTime shiftStartLocal,
    int shiftId, string? itemId, int? reasCd, string? lotNo, string? fgLotNo, string? sublotNo, string? fgSublotNo, string? extRef, string spare1, string spare2, string spare3, string spare4)
    {
        return await _jobExecRepository.AddConsPostExecAsync(sessionId, userId, entId, bomPos, qtyCons, woId, operId, seqNo, shiftStartLocal,
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
        return await _jobExecRepository.CertSignoffAsync(woId, operId, seqNo, stepNo, lotNo, prodLogId, consLogId, processId, processStatus, active, certName, userId,
            signOffLocal, comments, refRowId);
    }

    public async Task<int> CertSignoffAllowedAsync(string userId, string processId, string operId, int? stepNo, string? certName)
    {
        return await _jobExecRepository.CertSignoffAllowedAsync(userId, processId, operId, stepNo, certName);
    }

    public async Task<string> CertSignoffDoneAsync(string woId, string operId, int seqNo, int? stepNo, string? certName, string? lotNo, int? prodLogId, int? consLogId,
        string? processId, int? processStatus, bool? active)
    {
        return await _jobExecRepository.CertSignoffDoneAsync(woId, operId, seqNo, stepNo, certName, lotNo, prodLogId, consLogId, processId, processStatus, active);
    }

    public async Task<string> CertSignoffReqdAsync(string processId, string operId, int? stepNo)
    {
        return await _jobExecRepository.CertSignoffReqdAsync(processId, operId, stepNo);
    }

    public async Task<int> CertStartAllowedAsync(string userId, string? processId, string? operId, int? stepNo, string? itemId)
    {
        return await _jobExecRepository.CertStartAllowedAsync(userId, processId, operId, stepNo, itemId);
    }

    public async Task<string> ChangeJobStatesAsync(int rowId, int? stateCd, DateTime? reqFinishTimeLocal, int? jobPriority, int? applyToAllJobs)
    {
        return await _jobExecRepository.ChangeJobStatesAsync(rowId, stateCd, reqFinishTimeLocal, jobPriority, applyToAllJobs);
    }

    public async Task<int> ChangeSpecValueAsync(string userId, int entId, string specId, string newSpecValue, bool updateTemplate, int bomPos = 0, string? bomVerId = null, string? comments = null, int jobPos = 0)
    {
        return await _jobExecRepository.ChangeSpecValueAsync(userId, entId, specId, newSpecValue, updateTemplate, bomPos, bomVerId, comments, jobPos);
    }

    public async Task<int> ChangeSpecValuesAsync(int sessionId, string userId, int entId, string? newSpecValue, string? newMinValue, string? newMaxValue, bool updateTemplate = false, int checkPrivs = 0,
        int bomPos = 0, string? bomVerId = null, string comments = "", int jobPos = 0)
    {
        return await _jobExecRepository.ChangeSpecValuesAsync(sessionId, userId, entId, newSpecValue, newMinValue, newMaxValue, updateTemplate, checkPrivs, bomPos, bomVerId, comments, jobPos);
    }

    public async Task<int> ChangeWOPriorityAsync(string woId, int newPriority)
    {
        return await _jobExecRepository.ChangeWOPriorityAsync(woId, newPriority);
    }

    public async Task<int> ChangeWOQtysAsync(string userId, string woId, double reqQty, string? processId = null, string? itemId = null, double? startQty = null, DateTime? reqFinishTime = null, DateTime? releaseTime = null)
    {
        return await _jobExecRepository.ChangeWOQtysAsync(userId, woId, reqQty, processId, itemId, startQty, reqFinishTime, releaseTime);
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
        return await _jobExecRepository.CloneJobAsync(userId, woId, operId, seqNo, newWoId, newOperId, newSeqNo, reqQty, startQty, reqFinishTimeLocal);
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
        int? checkCerts = null, int clientType = 37, int noPropogation = 0, int checkAutoJobStart = 1, DateTime? actFinishTimeLocal = null)
    {
        return await _jobExecRepository.EndJobAsync(entId, woId, operId, seqNo, jobPos, statusNotes, userId, checkPrivs, checkCerts, clientType, noPropogation, checkAutoJobStart, actFinishTimeLocal);
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








        public List<object> GetJobQueue(string woId, string itemId)
    {
        throw new NotImplementedException();
    }

    public List<object> GetQueue(int entId, int? jobState, DateTime? reqdByTime, int? job_Priority, int? maxRows)
    {
        throw new NotImplementedException();
    }
}

