using System;
namespace BOL.API.Service.Interfaces;

public interface IUtilizationService
{
    int SetReasonAsync();
    int SetRawReasAsync();
    int SetPendingReasonAsync();
    object GetAvailableReasonsAsync();
    object GetOldAvailableReasonsAsync();
    int UpdateDurationsAsync();
    object GetStatusInfoByUserAsync();
}