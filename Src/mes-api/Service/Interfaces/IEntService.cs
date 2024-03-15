using BOL.API.Domain.Models.Core;

namespace BOL.API.Service.Interfaces;

public interface IEntService
{
    IEnumerable<Ent> GetAll();
    Ent GetEntById(int id);
    void Update(Ent ent);
    void Delete(int id);
    void Create(Ent ent);
}

