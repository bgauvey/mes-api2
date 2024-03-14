using System;
using BOL.API.Domain.Models.Core;

namespace BOL.API.Repository.Interfaces.Core;

public interface IEntRepository
{
	IEnumerable<Ent> GetAllEnts();
	Ent GetEntById(int id);
	void UpdateEnt(Ent ent);
	void DeleteEnt(int id);
	void AddEnt(Ent ent);
}


