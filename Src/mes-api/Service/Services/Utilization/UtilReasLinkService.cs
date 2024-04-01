//
// UtilReasLinkService.cs
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
using System;
using BOL.API.Domain.Models.Util;
using BOL.API.Repository.Interfaces.Util;
using BOL.API.Service.Interfaces.Utilization;

namespace BOL.API.Service.Services.Utilization
{
	public class UtilReasLinkService : IUtilReasLinkService
    {
        private readonly IUtilReasLinkRepository _utilReasLinkRepository;
        private readonly ILogger _logger;

        public UtilReasLinkService(IUtilReasLinkRepository utilReasLinkRepository, ILoggerFactory loggerFactory)
        {
            _utilReasLinkRepository = utilReasLinkRepository;
            _logger = loggerFactory.CreateLogger(nameof(UtilReasLinkService));
        }

        public async Task<int> CreateAsync(UtilReasLink utilReasLink)
        {
            return await _utilReasLinkRepository.CreateAsync(utilReasLink);
        }

        public async Task<int> DeleteAsync(UtilReasLink utilReasLink)
        {
            return await _utilReasLinkRepository.DeleteAsync(utilReasLink);
        }

        public async Task<IEnumerable<UtilReasLink>> GetAllAsync()
        {
            return await _utilReasLinkRepository.GetAllAsync();
        }

        public async Task<UtilReasLink> GetAsync(int rowId)
        {
            return await _utilReasLinkRepository.GetSingleByConditionAsync(t => t.RowId == rowId);
        }

        public async Task<int> UpdateAsync(UtilReasLink utilReasLink)
        {
            return await _utilReasLinkRepository.UpdateAsync(utilReasLink);
        }
    }
}

