using System;
namespace BOL.API.Service.Interfaces.Utilization;

public interface IUtilExecService
{
    Task<int> SetReasonAsync(int entId, int newReasCode, DateTime newReasStartLocal, bool reasPending, string comments);
    Task<int> SetRawReasAsync(int entId, int rawReasCode, DateTime newReasStart, string comments);
    Task<int> SetPendingReasonAsync(int entId, int finalReasCode, int logId, int periodAffected, int oldReasCode, string comments);
    Task<string> GetAvailableReasonsAsync(int entId, int rawReasCode);
    Task<string> GetOldAvailableReasonsAsync(int entId, int reasCode);
    Task<int >UpdateDurationsAsync(int entId);
}