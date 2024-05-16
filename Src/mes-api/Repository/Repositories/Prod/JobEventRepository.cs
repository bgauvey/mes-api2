//
// JobEventRepository.cs
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
using BOL.API.Repository.Interfaces.Prod;
using BOL.API.Repository.Utils;
using Newtonsoft.Json;

namespace BOL.API.Repository.Repositories.Prod
{
    public class JobEventRepository : RepositoryBase<JobEvent>, IJobEventRepository
	{
        private readonly CommandProcessor _CommandProcessor;
        public JobEventRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
             : base(context, loggerFactory)
        {
            _CommandProcessor = new CommandProcessor(configuration);
        }

        public async Task<string> LogJobEventAsync(int entId, DateTime eventTimeLocal, int jobPos, int stepNo, string eventType, int bomPos, string lotNo, string sublotNo, string itemId, string certName, string doneByUserId,
            string checkedByUserId, int sourceRowId, string specId, string comments, string value1, string value2, string value3, string value4, string value5, string value6, string value7, string value8, string value9,
            string value10, string lastEditComment)
        {
            int rowId = -1;
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("event_time_local", eventTimeLocal),
            new KeyValuePair<string, object>("job_pos", jobPos),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("event_type", eventType),
            new KeyValuePair<string, object>("bom_pos", bomPos),
            new KeyValuePair<string, object>("lot_no", lotNo),
            new KeyValuePair<string, object>("sublot_no", sublotNo),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("cert_name", certName),
            new KeyValuePair<string, object>("done_by_user_id", doneByUserId),
            new KeyValuePair<string, object>("checked_by_user_id", checkedByUserId),
            new KeyValuePair<string, object>("source_row_id", sourceRowId),
            new KeyValuePair<string, object>("spec_id", specId),
            new KeyValuePair<string, object>("comments", comments),
            new KeyValuePair<string, object>("value1", value1),
            new KeyValuePair<string, object>("value2", value2),
            new KeyValuePair<string, object>("value3", value3),
            new KeyValuePair<string, object>("value4", value4),
            new KeyValuePair<string, object>("value5", value5),
            new KeyValuePair<string, object>("value6", value6),
            new KeyValuePair<string, object>("value7", value7),
            new KeyValuePair<string, object>("value8", value8),
            new KeyValuePair<string, object>("value9", value9),
            new KeyValuePair<string, object>("value10", value10),
            new KeyValuePair<string, object>("last_edit_comment", lastEditComment),
            new KeyValuePair<string, object>("time_zone_bias_value", 0),
            new KeyValuePair<string, object>("row_id OUTPUT", rowId),
        };
            Command command = new Command()
            {
                Cmd = "",
                MsgType = "add",
                Object = "Job_Event",
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

