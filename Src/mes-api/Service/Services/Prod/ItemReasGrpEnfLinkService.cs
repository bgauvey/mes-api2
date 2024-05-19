//
// ItemReasGrpEntLinkService.cs
//
// Author:
//       Bill Gauvey <Bill.Gauvey@barretteoutdoorliving.com>
//
// Copyright (c) 2024 Barrette Outdoor Living
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using BOL.API.Domain.Models.Prod;
using BOL.API.Repository.Interfaces.Prod;
using BOL.API.Service.Interfaces.Prod;

namespace BOL.API.Service.Services.Prod
{
    public class ItemReasGrpEntLinkService: IItemReasGrpEntLinkService
	{
        private readonly IItemReasGrpEntLinkRepository _itemReasGrpEntLinkRepository;
        private readonly ILogger _logger;

        public ItemReasGrpEntLinkService(IItemReasGrpEntLinkRepository itemReasGrpEntLinkRepository, ILoggerFactory loggerFactory)
        {
            _itemReasGrpEntLinkRepository = itemReasGrpEntLinkRepository;
            _logger = loggerFactory.CreateLogger(nameof(ItemReasGrpEntLinkService));
        }

        public IEnumerable<ItemReasGrpEntLink> GetAll()
        {
            return _itemReasGrpEntLinkRepository.GetAll();
        }

        public ItemReasGrpEntLink GetById(string id)
        {
            return _itemReasGrpEntLinkRepository.GetByCondition(x => x.RowId.Equals(id)).Single();
        }

        public void Create(ItemReasGrpEntLink itemReasGrpEntLink)
        {
            _itemReasGrpEntLinkRepository.Create(itemReasGrpEntLink);
        }

        public void Update(ItemReasGrpEntLink itemReasGrpEntLink)
        {
            _itemReasGrpEntLinkRepository.Update(itemReasGrpEntLink);
        }

        public void Delete(string id)
        {
            var itemReasGrpEntLink = GetById(id);
            _itemReasGrpEntLinkRepository.Delete(itemReasGrpEntLink);
        }

        public async Task<string> GetReasonsAsync(int entId, string itemClassId, int reasGrpType)
        {
            return await _itemReasGrpEntLinkRepository.GetReasonsAsync(entId, itemClassId, reasGrpType);
        }
    }
}

