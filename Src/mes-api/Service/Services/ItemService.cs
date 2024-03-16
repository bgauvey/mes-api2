using System;
using BOL.API.Domain.Models.Prod;
using BOL.API.Repository.Interfaces.Prod;
using BOL.API.Service.Interfaces;

namespace BOL.API.Service.Services
{
	public class ItemService : IItemService
	{
        private readonly IItemRepository _itemcRepository;
        private readonly ILogger _logger;


        public ItemService(IItemRepository itemcRepository, ILoggerFactory loggerFactory)
		{
            _itemcRepository = itemcRepository;
            _logger = loggerFactory.CreateLogger(nameof(ItemService));
		}

        public Task<string> CreateAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string itemId)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(string itemId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}

