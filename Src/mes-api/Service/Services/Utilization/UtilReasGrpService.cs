//
// UtilReasGrpService.cs
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
using BOL.API.Domain.Models.Util;
using BOL.API.Repository.Interfaces.Util;
using BOL.API.Service.Interfaces.Utilization;

namespace BOL.API.Service.Services.Utilization
{
    public class UtilReasGrpService : IUtilReasGrpService
	{
        private readonly IUtilReasGrpRepository _utilReasGrpRepository;
        private readonly ILogger _logger;

        public UtilReasGrpService(IUtilReasGrpRepository utilReasGrpRepository, ILoggerFactory loggerFactory)
		{
            _utilReasGrpRepository = utilReasGrpRepository;
            _logger = loggerFactory.CreateLogger(nameof(UtilReasGrpService));
        }

        public async Task<int> CreateAsync(UtilReasGrp utilReasGrp)
        {
            return await _utilReasGrpRepository.CreateAsync(utilReasGrp);
        }

        public async Task<int> DeleteAsync(UtilReasGrp utilReasGrp)
        {
            return await _utilReasGrpRepository.DeleteAsync(utilReasGrp);
        }

        public async Task<IEnumerable<UtilReasGrp>> GetAllAsync()
        {
            return await _utilReasGrpRepository.GetAllAsync();
        }

        public async Task<UtilReasGrp> GetAsync(int reasGrpId)
        {
            return await _utilReasGrpRepository.GetByConditionAsync(t => t.ReasGrpId == reasGrpId);
        }

        public async Task<int> UpdateAsync(UtilReasGrp utilReasGrp)
        {
            return await _utilReasGrpRepository.UpdateAsync(utilReasGrp);
        }
    }
}

