using System;
namespace BOL.API.Service.Interfaces;

public interface IJobExecService
{
    void AddProd(int entId, double qtyProd,
       int? reasCd, string? lotNo, string? rmLotNo, int? toEntId, string? itemId, int? byproductBomPos,
       string? extRef, bool? applyScalingFactor, string? spare1, string? spare2, string? spare3, string? spare4, int? jobPos);

    void AddProdPostExec(int entId, double qtyProd,
    string woId, string operId, int seqNo, DateTime shiftStart, int shiftId, string? itemId, int? reasCd,
    string? lotNo, string? rmLotNo, int? toEntId, bool? processed, bool? byproduct, string extRef,
    int? moveStatus, string? spare1, string? spare2, string? spare3, string? spare4);

    void CancelAllJobs(string woId);

    List<object> GetJobQueue(string woId, string itemId);

    List<object> GetQueue(int entId, int? jobState, DateTime? reqdByTime, int? job_Priority, int? maxRows);
}

