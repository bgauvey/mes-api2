//
// CertRepository.cs
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
using BOL.API.Repository.Utils;
using BOL.API.Repository.Interfaces.Cert;
using Newtonsoft.Json;

namespace BOL.API.Repository.Repositories.Cert
{
    public class CertRepository: ICertRepository
    {
        private readonly CommandProcessor _CommandProcessor;

        protected FactelligenceContext _Context { get; set; }
        protected ILogger _Logger { get; set; }

        public CertRepository(FactelligenceContext factelligenceContext, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _CommandProcessor = new CommandProcessor(configuration);
            _Context = factelligenceContext;
            _Logger = loggerFactory.CreateLogger(nameof(CertRepository));
        }

        public async Task<string> CertSignoffAsync(string woId, string operId, int seqNo, int? stepNo, string lotNo, int prodLogId, int consLogId, string processId, int processStatus,
            bool active, string certName, string userId, DateTime? signOffLocal, string? comments, int refRowId)
        {
            int rowId = 0;
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("lot_no", lotNo),
            new KeyValuePair<string, object>("prod_log_id", prodLogId),
            new KeyValuePair<string, object>("cons_log_id", consLogId),
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("process_status", processStatus),
            new KeyValuePair<string, object>("active", active),
            new KeyValuePair<string, object>("cert_name", certName),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("sign_off_local", signOffLocal),
            new KeyValuePair<string, object>("comments", comments),
            new KeyValuePair<string, object>("ref_row_id", refRowId),
            new KeyValuePair<string, object>("time_zone_bias_value", 0),
            new KeyValuePair<string, object>("row_id OUTPUT", rowId),
        };
            Command command = new Command()
            {
                Cmd = "SignOff",
                MsgType = "",
                Object = "Cert",
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

        public async Task<int> CertSignoffAllowedAsync(string userId, string processId, string operId, int? stepNo, string? certName)
        {
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("cert_name", certName),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
            Command command = new Command()
            {
                Cmd = "SignOff_Allowed",
                MsgType = "",
                Object = "Cert",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });

            return data;
        }

        public async Task<string> CertSignoffDoneAsync(string woId, string operId, int seqNo, int? stepNo, string? certName, string? lotNo, int? prodLogId, int? consLogId,
            string? processId, int? processStatus, bool? active)
        {
            int success = 0;
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("cert_name", certName),
            new KeyValuePair<string, object>("lot_no", lotNo),
            new KeyValuePair<string, object>("prod_log_id", prodLogId),
            new KeyValuePair<string, object>("cons_log_id", consLogId),
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("process_status", processStatus),
            new KeyValuePair<string, object>("active", active),
            new KeyValuePair<string, object>("success OUTPUT", success),
        };
            Command command = new Command()
            {
                Cmd = "SignOff_Done",
                MsgType = "",
                Object = "Cert",
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

        public async Task<string> CertSignoffReqdAsync(string processId, string operId, int? stepNo)
        {
            int success = 0;
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("success OUTPUT", success),
        };
            Command command = new Command()
            {
                Cmd = "SignOff_Reqd",
                MsgType = "",
                Object = "Cert",
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

        public async Task<int> CertStartAllowedAsync(string userId, string? processId, string? operId, int? stepNo, string? itemId)
        {
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
            Command command = new Command()
            {
                Cmd = "Start_Allowed",
                MsgType = "",
                Object = "Cert",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });

            return data;
        }

    }
}

