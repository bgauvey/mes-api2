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

    public List<object> GetJobQueue(string woId, string itemId)
    {
        throw new NotImplementedException();
    }

    public List<object> GetQueue(int entId, int? jobState, DateTime? reqdByTime, int? job_Priority, int? maxRows)
    {
        throw new NotImplementedException();
    }
}

