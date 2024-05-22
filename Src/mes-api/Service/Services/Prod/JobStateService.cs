﻿//
// JobStateService.cs
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
    public class JobStateService: IJobStateService
	{
        private readonly IJobStateRepository _jobStateRepository;
        private readonly ILogger _logger;

        public JobStateService(IJobStateRepository jobStateRepository, ILoggerFactory loggerFactory)
        {
            _jobStateRepository = jobStateRepository;
            _logger = loggerFactory.CreateLogger(nameof(JobStateService));
        }

        public IEnumerable<JobState> GetAll()
        {
            return _jobStateRepository.GetAll();
        }

        public JobState GetById(int id)
        {
            return _jobStateRepository.GetByCondition(x => x.StateCd.Equals(id)).Single();
        }

        public void Create(JobState jobState)
        {
            _jobStateRepository.Create(jobState);
        }

        public void Update(JobState jobState)
        {
            _jobStateRepository.Update(jobState);
        }

        public void Delete(int id)
        {
            var jobState = GetById(id);
            _jobStateRepository.Delete(jobState);
        }
    }
}

