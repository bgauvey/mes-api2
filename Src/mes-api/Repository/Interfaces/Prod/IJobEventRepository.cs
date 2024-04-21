//
// IJobEventRepository.cs
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

namespace BOL.API.Repository.Interfaces.Prod
{
	public interface IJobEventRepository : IRepositoryBase<JobEvent>
	{

        Task<string> LogJobEventAsync(int entId, DateTime eventTimeLocal, int jobPos, int stepNo, string eventType, int bomPos, string lotNo, string sublotNo, string itemId, string certName, string doneByUserId,
            string checkedByUserId, int sourceRowId, string specId, string comments, string value1, string value2, string value3, string value4, string value5, string value6, string value7, string value8, string value9,
            string value10, string lastEditComment);
    }
}

