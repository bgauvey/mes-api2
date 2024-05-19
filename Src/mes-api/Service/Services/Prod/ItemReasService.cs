//
// ItemReasService.cs
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
    public class ItemReasService: IItemReasService
	{
        private readonly IItemReasRepository _itemReasRepository;
        private readonly ILogger _logger;

        public ItemReasService(IItemReasRepository itemReasRepository, ILoggerFactory loggerFactory)
        {
            _itemReasRepository = itemReasRepository;
            _logger = loggerFactory.CreateLogger(nameof(ItemReasService));
        }

        public IEnumerable<ItemReas> GetAll()
        {
            return _itemReasRepository.GetAll();
        }

        public ItemReas GetById(string id)
        {
            return _itemReasRepository.GetByCondition(x => x.ReasCd.Equals(id)).Single();
        }

        public void Create(ItemReas itemReas)
        {
            _itemReasRepository.Create(itemReas);
        }

        public void Update(ItemReas itemReas)
        {
            _itemReasRepository.Update(itemReas);
        }

        public void Delete(string id)
        {
            var itemReas = GetById(id);
            _itemReasRepository.Delete(itemReas);
        }
    }
}

