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
}

