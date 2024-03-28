using System;
namespace BOL.API.Service.Interfaces;

public interface IUtilizationService
{
    int SetReasonAsync();
    int SetRawReasAsync();
    int SetPendingReasonAsync();
    Task<string> GetAvailableReasonsAsync(int entId, int rawReasCode);
    Task<string> GetOldAvailableReasonsAsync(int entId, int reasCode);
    int UpdateDurationsAsync();
}