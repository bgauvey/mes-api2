using BOL.API.Domain.Models.Prod;

namespace BOL.API.Service.Interfaces.Prod;

public interface IUomService
{
    Task<IEnumerable<Uom>> GetAllAsync();
    Task<Uom> GetByIdAsync(int uomId);
    Task<int> CreateAsync(Uom uom);
    Task<int> UpdateAsync(Uom uom);
    Task<int> DeleteAsync(int uomId);
}

