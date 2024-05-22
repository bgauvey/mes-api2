//
// JobEventService.cs
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
    public class JobEventService: IJobEventService
	{
        private readonly IJobEventRepository _jobEventRepository;
        private readonly ILogger _logger;

        public JobEventService(IJobEventRepository jobEventRepository, ILoggerFactory loggerFactory)
        {
            _jobEventRepository = jobEventRepository;
            _logger = loggerFactory.CreateLogger(nameof(JobEventService));
        }

        public IEnumerable<JobEvent> GetAll()
        {
            return _jobEventRepository.GetAll();
        }

        public JobEvent GetById(string id)
        {
            return _jobEventRepository.GetByCondition(x => x.RowId.Equals(id)).Single();
        }

        public void Create(JobEvent jobEvent)
        {
            _jobEventRepository.Create(jobEvent);
        }

        public void Update(JobEvent jobEvent)
        {
            _jobEventRepository.Update(jobEvent);
        }

        public void Delete(string id)
        {
            var jobEvent = GetById(id);
            _jobEventRepository.Delete(jobEvent);
        }
    }
}

