//
// UtilLogRepository.cs
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
using System.Data;
using System.Xml.Linq;
using BOL.API.Domain.Models;
using BOL.API.Domain.Models.Util;
using BOL.API.Repository.Utils;
using BOL.API.Repository.Interfaces.Util;
using Newtonsoft.Json;

namespace BOL.API.Repository.Repositories.Util
{
	public class UtilLogRepository: RepositoryBase<UtilLog>, IUtilLogRepository
    { 
        private readonly CommandProcessor _CommandProcessor;
        public UtilLogRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
             : base(context, loggerFactory)
        {
            _CommandProcessor = new CommandProcessor(configuration);
        }

        public async Task<int> AdjustDurationAsync(int entId, DateTime eventTimeLocal, double newDuration)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("ent_id", entId),
                new KeyValuePair<string, object>("event_time_local", eventTimeLocal),
                new KeyValuePair<string, object>("new_duration", newDuration),
                new KeyValuePair<string, object>("time_zone_bias_value", 0)
            };
            Command command = new Command()
            {
                Cmd = "AdjustDuration",
                MsgType = "exec",
                Object = "Util_Log",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                int rowsAffected = _CommandProcessor.ExecuteCommand(command);

                return rowsAffected;
            });

            return data;
        }

        public async Task<string> GetAllAsync(DateTime eventTime)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("event_time", eventTime),
                new KeyValuePair<string, object>("time_zone_bias_value", 0)
            };
            Command command = new Command()
            {
                MsgType = "getall",
                Object = "Util_Log",
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

        public async Task<string> GetAllByPeriodAsync(int entId, DateTime startTimeLocal, DateTime endTimeLocal)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("ent_id", entId),
                new KeyValuePair<string, object>("start_time_local", startTimeLocal),
                new KeyValuePair<string, object>("end_time_local", endTimeLocal),
                new KeyValuePair<string, object>("time_zone_bias_value", 0)
            };
            Command command = new Command()
            {
                Cmd = "ByPeriod",
                MsgType = "getall",
                Object = "Util_Log",
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

        public async Task<int> SplitAsync(int entId, DateTime eventTimeLocal, double newDuration, int shiftId, DateTime shiftStartLocal, int reasCd, bool reasPending, string comments, string rawReasCd)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("ent_id", entId),
                new KeyValuePair<string, object>("event_time_local", eventTimeLocal),
                new KeyValuePair<string, object>("new_duration", newDuration),
                new KeyValuePair<string, object>("shift_id", shiftId),
                new KeyValuePair<string, object>("shift_start_local", shiftStartLocal),
                new KeyValuePair<string, object>("reas_cd", reasCd),
                new KeyValuePair<string, object>("reas_pending", reasPending),
                new KeyValuePair<string, object>("comments", comments),
                new KeyValuePair<string, object>("raw_reas_cd", rawReasCd),
                new KeyValuePair<string, object>("time_zone_bias_value", 0)
            };
            Command command = new Command()
            {
                Cmd = "Split",
                MsgType = "exec",
                Object = "Util_Log",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                int rowsAffected = _CommandProcessor.ExecuteCommand(command);

                return rowsAffected;
            });

            return data;
        }
    }
}

