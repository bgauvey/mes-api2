using BOL.API.Domain.Models.Prod;
using BOL.API.Repository.Interfaces.Core;
using BOL.API.Repository.Interfaces.Prod;
using BOL.API.Service.Interfaces;
using BOL.API.Service.Models;

namespace BOL.API.Service.Services
{
    public class ItemService : IItemService
	{
        private readonly IItemRepository _itemcRepository;
        private readonly ILogger _logger;
        private readonly IAttrRepository _attrRepository;
        private readonly IItemAttrRepository _itemAttrRepository;
        private readonly IItemFileRepository _itemFileRepository;

        public ItemService(IItemRepository itemcRepository, IAttrRepository attrRepository, IItemAttrRepository itemAttrRepository, IItemFileRepository itemFileRepository, ILoggerFactory loggerFactory)
		{
            _itemcRepository = itemcRepository;
            _attrRepository = attrRepository;
            _itemAttrRepository = itemAttrRepository;
            _itemFileRepository = itemFileRepository;
            _logger = loggerFactory.CreateLogger(nameof(ItemService));
		}

        public async Task<int> CreateAsync(Item item)
        {
            return await _itemcRepository.CreateAsync(item);
        }

        public async Task<int> DeleteAsync(string itemId)
        {
            var item = await GetItemAsync(itemId);
            return await _itemcRepository.DeleteAsync(item);
        }

        public async Task<Item> GetItemAsync(string itemId)
        {
            return await _itemcRepository.GetSingleByConditionAsync(t => t.ItemId == itemId);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _itemcRepository.GetAllAsync();
        }

        public async Task<int> UpdateAsync(Item item)
        {
            return await _itemcRepository.UpdateAsync(item);
        }

        public async Task<IEnumerable<ItemAttribute>> GetAttrsAsync(string itemId)
        {
            var attrs = _attrRepository.GetAll().ToList();
            var itemAttrs = _itemAttrRepository.GetByCondition(x => x.ItemId == itemId).ToList();
            var task = await Task.Run(() =>
            { 
                var itemAttributes = itemAttrs
                        .Join(attrs, e => e.AttrId, a => a.AttrId,
                        (e, a) => new { e, a })
                        .Select(x => new ItemAttribute()
                        {
                            AttrId = x.a.AttrId,
                            AttrDesc = x.a.AttrDesc,
                            AttrValue = x.e.AttrValue,
                            ItemId = x.e.ItemId
                        }).AsEnumerable();
                return itemAttributes;
            });
            return task;
        }

        public async Task<IEnumerable<ItemFile>> GetFiles(string itemId)
        {
            return await _itemFileRepository.GetListByConditionAsync(item => item.ItemId == itemId);
        }
    }
}

