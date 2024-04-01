using System;
using BOL.API.Domain.Models.Core;

namespace BOL.API.Repository.Interfaces.Core;

public interface IEntRepository : IRepositoryBase<Ent>
{
    Task<string> GetStatusInfoByUserAsync(int sessionId, string userId);
    Task<string> GetAllTopLevelAsync();
    Task<string> GetShiftSchedEntitiesAsync(int entId);
    Task<string> GetStatusInfoAsync(int entId, int childLevels);
    Task<string> GetShiftTemplatesAsync(int entId, DateTime startDate, DateTime endDate);

    Task<int> DoAutoShiftChangesAsync(int entId);
    Task<int> DoPastShiftChangesAsync();
    Task<int> StartShiftAsync(int entId, int shiftId, DateTime shiftStart);
    Task<string> RefreshShiftSchedAsync(int inEntId, DateTime inStartTime, int inDaysAhead);
    Task<string> GetRefreshShiftSchedAsync(int inEntId, DateTime inStartTime, int inDaysAhead);
    Task<string> GetShiftSchedulesAsync(int inEntId, DateTime startTime, DateTime endTime);
}


