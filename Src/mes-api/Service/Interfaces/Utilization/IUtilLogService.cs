//
// IUtilLogService.cs
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

namespace BOL.API.Service.Interfaces.Utilization
{
	public interface IUtilLogService
	{
        Task<UtilLog> GetAsync(int logId);
        Task<string> GetAllAsync(DateTime eventTime);
        Task<int> UpdateAsync(UtilLog utilLog);
        Task<int> DeleteAsync(UtilLog utilLog);

        Task<string> GetAllByPeriodAsync(int entId, DateTime startTimeLocal, DateTime endTimeLocal);
        Task<int> SplitAsync(int entId, DateTime eventTimeLocal, double newDuration, int shiftId, DateTime shiftStartLocal, int reasCd, bool reasPending, string comments, string rawReasCd);
        Task<int> AdjustDurationAsync(int entId, DateTime eventTimeLocal, double newDuration);
    }
}

