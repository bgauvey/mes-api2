using BOL.API.Domain.Models.Core;
using BOL.API.Service.Models;

namespace BOL.API.Service.Interfaces;

public interface IEntService
{
    IEnumerable<Ent> GetAll();
    Ent GetEntById(int id);
    void Update(Ent ent);
    void Delete(int id);
    void Create(Ent ent);

    IEnumerable<EntFile> GetFiles(int id);
    IEnumerable<EntityAttribute> GetAttrs(int id);

    Task<string> GetStatusInfoByUserAsync(int sessionId, string userId);
    Task<string> GetAllTopLevelAsync();
    Task<string> GetShiftSchedEntitiesAsync(int entId);
    Task<string> GetStatusInfoAsync(int entId, int childLevels);
    Task<string> GetShiftTemplatesAsync(int entId, DateTime startDate, DateTime endDate);
}

