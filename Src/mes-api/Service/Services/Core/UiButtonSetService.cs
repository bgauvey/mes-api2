//
// UiButtonSetService.cs
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
using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Interfaces.Core;
using BOL.API.Service.Interfaces.Core;

namespace BOL.API.Service.Services.Core
{
    public class UiButtonSetService: IUiButtonSetService
	{
        private readonly IUiButtonSetRepository _uiButtonSetRepository;
        private readonly ILogger _logger;

        public UiButtonSetService(IUiButtonSetRepository uiButtonSetRepository, ILoggerFactory loggerFactory)
        {
            _uiButtonSetRepository = uiButtonSetRepository;
            _logger = loggerFactory.CreateLogger(nameof(UiButtonSetService));
        }

        public IEnumerable<UiButtonSet> GetAll()
        {
            return _uiButtonSetRepository.GetAll();
        }

        public UiButtonSet GetById(int id)
        {
            return _uiButtonSetRepository.GetByCondition(x => x.ButtonId.Equals(id)).Single();
        }

        public void Create(UiButtonSet uiButtonSet)
        {
            _uiButtonSetRepository.Create(uiButtonSet);
        }

        public void Update(UiButtonSet uiButtonSet)
        {
            _uiButtonSetRepository.Update(uiButtonSet);
        }

        public void Delete(int id)
        {
            var uiButtonSet = GetById(id);
            _uiButtonSetRepository.Delete(uiButtonSet);
        }
    }
}

