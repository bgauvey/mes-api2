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

    public void AddProd(int entId, double qtyProd,
       int? reasCd, string? lotNo, string? rmLotNo, int? toEntId, string? itemId, int? byproductBomPos,
       string? extRef, bool? applyScalingFactor, string? spare1, string? spare2, string? spare3, string? spare4, int? jobPos)
    {
        _jobExecRepository.AddProd(entId, qtyProd, reasCd, lotNo, rmLotNo, toEntId, itemId, byproductBomPos, extRef,
            applyScalingFactor, spare1, spare2, spare3, spare4, jobPos);
    }

    public void AddProdPostExec(int entId, double qtyProd, string woId, string operId, int seqNo, DateTime shiftStart,
        int shiftId, string? itemId, int? reasCd, string? lotNo, string? rmLotNo, int? toEntId, bool? processed, bool? byproduct,
        string extRef, int? moveStatus, string? spare1, string? spare2, string? spare3, string? spare4)
    {
        throw new NotImplementedException();
    }

    public void CancelAllJobs(string woId)
    {
        throw new NotImplementedException();
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

