using BOL.API.Domain.Models.Core;
using BOL.API.Domain.Models.Security;
using BOL.API.Repository.Interfaces.Core;
using BOL.API.Service.Interfaces;
using BOL.API.Service.Models;

namespace BOL.API.Service.Services;

public class EntService : IEntService
{
    private readonly IEntRepository _entRepository;
    private readonly IEntFileRepository _entFileRepository;
    private readonly IAttrRepository _attrRepository;
    private readonly IEntAttrRepository _entAttrRepository;
    private readonly ILogger _logger;

    public EntService(IEntRepository entRepository, IEntFileRepository entFileRepository, IAttrRepository attrRepository, IEntAttrRepository entAttrRepository,
        ILoggerFactory loggerFactory)
    {
        _entRepository = entRepository;
        _entFileRepository = entFileRepository;
        _attrRepository = attrRepository;
        _entAttrRepository = entAttrRepository;
        _logger = loggerFactory.CreateLogger(nameof(EntService));
    }

    public IEnumerable<Ent> GetAll()
    {
        return _entRepository.GetAll();
    }

    public Ent GetEntById(int id)
    {
        return _entRepository.GetByCondition(x => x.EntId.Equals(id)).Single();
    }

    public void Create(Ent ent)
    {
        _entRepository.Create(ent);
    }

    public void Update(Ent ent)
    {
        _entRepository.Update(ent);
    }

    public void Delete(int id)
    {
        var ent = GetEntById(id);
        _entRepository.Delete(ent);
    }

    public IEnumerable<EntFile> GetFiles(int id)
    {
        return _entFileRepository.GetByCondition(x => x.EntId == id);
    }

    public IEnumerable<EntityAttribute> GetAttrs(int id)
    {
        var attrs = _attrRepository.GetAll();
        var entAttrs = _entAttrRepository.GetByCondition(x => x.EntId == id);

        var entityAttrs = entAttrs
            .Join(attrs, e => e.AttrId, a => a.AttrId,
            (e, a) => new { e, a })
            .Select(x => new EntityAttribute()
            {
                AttrId = x.a.AttrId,
                AttrDesc = x.a.AttrDesc,
                AttrValue = x.e.AttrValue,
                EntId = x.e.EntId
            }).AsEnumerable();

        return entityAttrs;
    }

    public async Task<string> GetAllTopLevelAsync()
    {
        return await _entRepository.GetAllTopLevelAsync();
    }

    public async Task<string> GetShiftSchedEntitiesAsync(int entId)
    {
        return await _entRepository.GetShiftSchedEntitiesAsync(entId);
    }

    public async Task<string> GetShiftTemplatesAsync(int entId, DateTime startDate, DateTime endDate)
    {
        return await _entRepository.GetShiftTemplatesAsync(entId, startDate, endDate);
    }

    public async Task<string> GetStatusInfoAsync(int entId, int childLevels)
    {
        return await _entRepository.GetStatusInfoAsync(entId, childLevels);
    }

    public async Task<string> GetStatusInfoByUserAsync(int sessionId, string userId)
    {
        return await _entRepository.GetStatusInfoByUserAsync(sessionId, userId);
    }

    public async Task<int> DoAutoShiftChangesAsync(int entId)
    {
        return await _entRepository.DoAutoShiftChangesAsync(entId);
    }

    public async Task<int> DoPastShiftChangesAsync()
    {
        return await _entRepository.DoPastShiftChangesAsync();
    }

    public async Task<int> StartShiftAsync(int entId, int shiftId, DateTime shiftStart)
    {
        return await _entRepository.StartShiftAsync(entId, shiftId, shiftStart);
    }

    public async Task<string> RefreshShiftSchedAsync(int inEntId, DateTime inStartTime, int inDaysAhead)
    {
        return await _entRepository.RefreshShiftSchedAsync(inEntId, inStartTime, inDaysAhead);
    }

    public async Task<string> GetRefreshShiftSchedAsync(int inEntId, DateTime inStartTime, int inDaysAhead)
    {
        return await _entRepository.GetRefreshShiftSchedAsync(inEntId, inStartTime, inDaysAhead);
    }

    public async Task<string> GetShiftSchedulesAsync(int inEntId, DateTime startTime, DateTime endTime)
    {
        return await _entRepository.GetShiftSchedulesAsync(inEntId, startTime, endTime);
    }
}

