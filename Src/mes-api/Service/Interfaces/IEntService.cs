using BOL.API.Domain.Models.Core;

namespace BOL.API.Service.Interfaces;

public interface IEntService
{
    IEnumerable<Ent> GetAllEnts();
    Ent GetEntById(int id);
    void UpdateEnt(Ent ent);
    void DeleteEnt(int id);
    void AddEnt(Ent ent);
}

