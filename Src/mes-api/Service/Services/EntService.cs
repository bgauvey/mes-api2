using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Core;
using BOL.API.Service.Interfaces;

namespace BOL.API.Service.Services;

public class EntService : IEntService
{
    private readonly EntRepository _entRepository;

    public EntService(EntRepository entRepository)
    {
        _entRepository = entRepository;
    }

    public IEnumerable<Ent> GetAllEnts()
    {
        return _entRepository.GetAllEnts();
    }

    public Ent GetEntById(int id)
    {
        return _entRepository.GetEntById(id);
    }

    public void AddEnt(Ent ent)
    {
        _entRepository.AddEnt(ent);
    }

    public void UpdateEnt(Ent ent)
    {
        _entRepository.UpdateEnt(ent);
    }

    public void DeleteEnt(int id)
    {
        _entRepository.DeleteEnt(id);
    }
}

