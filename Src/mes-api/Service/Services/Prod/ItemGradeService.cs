//
// ItemGradeService.cs
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
    public class ItemGradeService: IItemGradeService
	{
        private readonly IItemGradeRepository _itemGradeRepository;
        private readonly ILogger _logger;

        public ItemGradeService(IItemGradeRepository itemGradeRepository, ILoggerFactory loggerFactory)
        {
            _itemGradeRepository = itemGradeRepository;
            _logger = loggerFactory.CreateLogger(nameof(ItemGradeService));
        }

        public IEnumerable<ItemGrade> GetAll()
        {
            return _itemGradeRepository.GetAll();
        }

        public ItemGrade GetById(int id)
        {
            return _itemGradeRepository.GetByCondition(x => x.ItemGradeCd.Equals(id)).Single();
        }

        public void Create(ItemGrade itemGrade)
        {
            _itemGradeRepository.Create(itemGrade);
        }

        public void Update(ItemGrade itemGrade)
        {
            _itemGradeRepository.Update(itemGrade);
        }

        public void Delete(int id)
        {
            var itemGrade = GetById(id);
            _itemGradeRepository.Delete(itemGrade);
        }
    }
}

