//
// UtilLogService.cs
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
using System.Security.Claims;
using BOL.API.Domain.Models.Util;
using BOL.API.Repository.Interfaces.Util;
using BOL.API.Service.Interfaces.Utilization;

namespace BOL.API.Service.Services.Utilization
{
	public class UtilLogService : IUtilLogService
	{
        private readonly IUtilLogRepository _utilLogRepository;
        private readonly ILogger _logger;

        public UtilLogService(IUtilLogRepository utilLogRepository, ILoggerFactory loggerFactory)
        {
            _utilLogRepository = utilLogRepository;
            _logger = loggerFactory.CreateLogger(nameof(UtilLogService));
        }
        public async Task<int> AdjustDurationAsync(int entId, DateTime eventTimeLocal, double newDuration)
        {
            return await _utilLogRepository.AdjustDurationAsync(entId, eventTimeLocal, newDuration);
        }

        public async Task<int> DeleteAsync(UtilLog utilLog)
        {
            return await _utilLogRepository.DeleteAsync(utilLog);
        }

        public async Task<string> GetAllAsync(DateTime eventTime)
        {
            return await _utilLogRepository.GetAllAsync(eventTime);
        }

        public async Task<string> GetAllByPeriodAsync(int entId, DateTime startTimeLocal, DateTime endTimeLocal)
        {
            return await _utilLogRepository.GetAllByPeriodAsync(entId, startTimeLocal, endTimeLocal);
        }

        public async Task<UtilLog> GetAsync(int logId)
        {
            return await _utilLogRepository.GetByConditionAsync(t => t.LogId == logId);
        }

        public async Task<int> SplitAsync(int entId, DateTime eventTimeLocal, double newDuration, int shiftId, DateTime shiftStartLocal, int reasCd, bool reasPending, string comments, string rawReasCd)
        {
            return await _utilLogRepository.SplitAsync(entId, eventTimeLocal, newDuration, shiftId, shiftStartLocal, reasCd, reasPending, comments, rawReasCd);
        }

        public async Task<int> UpdateAsync(UtilLog utilLog)
        {
            return await _utilLogRepository.UpdateAsync(utilLog);
        }
    }
}

