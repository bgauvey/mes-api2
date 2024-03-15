﻿using BOL.API.Domain.Models.Core;
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
}

