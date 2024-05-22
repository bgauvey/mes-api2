//
// JobSchedExecRepository.cs
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

using BOL.API.Domain.Models;
using BOL.API.Domain.Models.Prod;
using BOL.API.Repository.Interfaces.Prod;
using BOL.API.Repository.Utils;

namespace BOL.API.Repository.Repositories.Prod
{
    public class JobSchedExecRepository: RepositoryBase<JobSchedExec>, IJobSchedExecRepository
    {
        private readonly CommandProcessor _CommandProcessor;

        public JobSchedExecRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
        {
            _CommandProcessor = new CommandProcessor(configuration);
        }

        public async Task<int> DropTempShiftExcAsync(int sessionId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("session_id", sessionId),
            };

            Command command = new Command()
            {
                Cmd = "DropTempShiftExc",
                MsgType = "exec",
                Object = "job_sched_exec",
                Parameters = parameters,
                Schema = "dbo"
            };

            var rowsAffected = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);
            });

            return rowsAffected;
        }

        public async Task<int> RefreshTempShiftExcAsync(int sessionId)
        {
            // throw new NotImplementedException();
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("session_id", sessionId),
            };

            Command command = new Command()
            {
                Cmd = "RefreshTempShiftExc",
                MsgType = "exec",
                Object = "job_sched_exec",
                Parameters = parameters,
                Schema = "dbo"
            };

            var rowsAffected = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);
            });

            return rowsAffected;
        }
    }
}

