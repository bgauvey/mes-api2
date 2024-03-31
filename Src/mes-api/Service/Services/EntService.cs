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

    public async Task<string> GetStatusInfoByUserAsync(int sessionId, string userId)
    {
        return await _entRepository.GetStatusInfoByUserAsync(sessionId, userId);
    }
}

