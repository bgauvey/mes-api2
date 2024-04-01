using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Models;

namespace BOL.API.Service.Interfaces;

public interface IItemService
{
    Task<IEnumerable<Item>> GetItemsAsync();
    Task<Item> GetItemAsync(string itemId);
    Task<int> CreateAsync(Item item);
    Task<int> UpdateAsync(Item item);
    Task<int> DeleteAsync(string itemId);
    Task<IEnumerable<ItemAttribute>> GetAttrsAsync(string itemId);
    Task<IEnumerable<ItemFile>> GetFiles(string itemId);
}

