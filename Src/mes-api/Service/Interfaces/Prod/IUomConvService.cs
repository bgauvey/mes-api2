using BOL.API.Domain.Models.Prod;

namespace BOL.API.Service.Interfaces.Prod;

public interface IUomConvService
{
    Task<IEnumerable<UomConv>> GetAllAsync();
    Task<UomConv> GetByIdAsync(int uomConvId);
    Task<int> CreateAsync(UomConv uomConv);
    Task<int> UpdateAsync(UomConv uomConv);
    Task<int> DeleteAsync(int uomConvId);
}

