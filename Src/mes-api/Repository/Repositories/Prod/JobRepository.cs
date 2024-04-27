//
// JobRepository.cs
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

using System.Data;
using BOL.API.Domain.Models;
using BOL.API.Domain.Models.Prod;
using BOL.API.Repository.Utils;
using BOL.API.Repository.Interfaces.Prod;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BOL.API.Repository.Repositories.Prod
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        private readonly CommandProcessor _CommandProcessor;

        public JobRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
        {
            _CommandProcessor = new CommandProcessor(configuration);
        }

        public async Task<int> ChangeWOQtysAsync(string userId, string woId, double reqQty, string? processId = null, string? itemId = null, double? startQty = null, DateTime? reqFinishTime = null, DateTime? releaseTime = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("req_qty", reqQty),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("start_qty", startQty),
            new KeyValuePair<string, object>("req_finish_time", reqFinishTime),
            new KeyValuePair<string, object>("release_time", releaseTime),
            new KeyValuePair<string, object>("time_zone_bias_value", 0),
        };
            Command command = new Command()
            {
                Cmd = "Job_Qty",
                MsgType = "",
                Object = "Alloc",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });
            return data;
        }

        public async Task<int> CloneJobAsync(string userId, string woId, string operId, int seqNo, string? newWoId, string? newOperId, int? newSeqNo, double? reqQty, double? startQty, DateTime? reqFinishTimeLocal)
        {
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("new_wo_id", newWoId),
            new KeyValuePair<string, object>("new_oper_id", newOperId),
            new KeyValuePair<string, object>("new_seq_no", newSeqNo),
            new KeyValuePair<string, object>("req_qty", reqQty),
            new KeyValuePair<string, object>("start_qty", startQty),
            new KeyValuePair<string, object>("req_finish_time_local", reqFinishTimeLocal),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
            Command command = new Command()
            {
                Cmd = "Clone",
                MsgType = "exec",
                Object = "Job",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });
            return data;
        }

        public async Task<string> GetJobQueueByFilterAsync(string entFilter, string jobFilter)
        {
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_filter", entFilter),
            new KeyValuePair<string, object>("job_filter", jobFilter),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
            Command command = new Command()
            {
                Cmd = "GetJobQueueByFilter",
                MsgType = "getall",
                Object = "Job",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                DataTable dt = _CommandProcessor.GetDataTableFromCommand(command);

                var jsonString = JsonConvert.SerializeObject(dt, Formatting.Indented);

                return jsonString;
            });

            return data;
        }

    }
}

