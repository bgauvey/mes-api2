using System;
using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Interfaces.Core;

namespace BOL.API.Repository.Core;

public class EntRepository : IEntRepository
{
	public EntRepository()
	{
	}

    public void AddEnt(Ent ent)
    {
        throw new NotImplementedException();
    }

    public void DeleteEnt(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ent> GetAllEnts()
    {
        throw new NotImplementedException();
    }

    public Ent GetEntById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateEnt(Ent ent)
    {
        throw new NotImplementedException();
    }
}

