//
// JobSchedExecService.cs
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
    public class JobSchedExecService: IJobSchedExecService
	{
        private readonly IJobSchedExecRepository _jobSchedExecRepository;
        private readonly ILogger _logger;

        public JobSchedExecService(IJobSchedExecRepository jobSchedExecRepository, ILoggerFactory loggerFactory)
        {
            _jobSchedExecRepository = jobSchedExecRepository;
            _logger = loggerFactory.CreateLogger(nameof(JobSchedExecService));
        }

        public IEnumerable<JobSchedExec> GetAll()
        {
            return _jobSchedExecRepository.GetAll();
        }

        public JobSchedExec GetById(string id)
        {
            return _jobSchedExecRepository.GetByCondition(x => x.EntId.Equals(id)).Single();
        }

        public void Create(JobSchedExec jobSchedExec)
        {
            _jobSchedExecRepository.Create(jobSchedExec);
        }

        public void Update(JobSchedExec jobSchedExec)
        {
            _jobSchedExecRepository.Update(jobSchedExec);
        }

        public void Delete(string id)
        {
            var jobSchedExec = GetById(id);
            _jobSchedExecRepository.Delete(jobSchedExec);
        }

        public async Task<int> DropTempShiftExcAsync(int sessionId)
        {
            return await _jobSchedExecRepository.DropTempShiftExcAsync(sessionId);
        }

        public async Task<int> RefreshTempShiftExcAsync(int sessionId)
        {
            return await _jobSchedExecRepository.RefreshTempShiftExcAsync(sessionId);
        }

        public Task<string> ApplyScheduleAsync(string xmlCommand)
        {
            throw new NotImplementedException();
        }
    }
}

