using BOL.API.Domain.Models.Prod;

namespace BOL.API.Service.Interfaces;

public interface IItemService
{
    Task<List<Item>> GetItemsAsync();
    Task<Item> GetItemAsync(string itemId);
    Task<string> CreateAsync(Item item);
    Task<int> UpdateAsync(Item item);
    void Delete(string itemId);
}

