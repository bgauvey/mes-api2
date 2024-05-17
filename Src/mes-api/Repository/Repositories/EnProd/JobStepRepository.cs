//
// JobStepRepository.cs
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
using BOL.API.Domain.Models.EnProd;
using BOL.API.Repository.Interfaces.EnProd;
using BOL.API.Repository.Utils;

namespace BOL.API.Repository.Repositories.EnProd
{
    public class JobStepRepository: RepositoryBase<JobStep>, IJobStepRepository
	{
        private readonly CommandProcessor _CommandProcessor;
        private readonly int _timeZoneBiasValue;

        public JobStepRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
             : base(context, loggerFactory)
        {
            _timeZoneBiasValue = (int)configuration.GetSection("Mes").GetValue(typeof(int), "_timeZoneBiasValue");
            _CommandProcessor = new CommandProcessor(configuration);
        }

        public async Task<int> StartStepAsync(int sessionId, string userId, int jobPos, int stepNo, string lotNo, string sublotNo, int? stateCd = null, bool? checkCert = null, bool? laborOption = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("session_id", sessionId),
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>("job_pos", jobPos),
                new KeyValuePair<string, object>("step_no", stepNo) ,
                new KeyValuePair<string, object>("lot_no", lotNo),
                new KeyValuePair<string, object>("sublot_no", sublotNo),
                new KeyValuePair<string, object>("state_cd", stateCd),
                new KeyValuePair<string, object>("check_cert", checkCert),
                new KeyValuePair<string, object>("labor_option", laborOption),
                new KeyValuePair<string, object>("time_zone_bias_value", _timeZoneBiasValue)
            };
            Command command = new Command()
            {
                Cmd = "StartStep",
                MsgType = "exec",
                Object = "Job_Step",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });
            return data;
        }

        public async Task<int> StepLoginAsync(int sessionId, string userId, int entId, int stepNo, int jobPos, string lotNo, string sublotNo, string labCd = null, string deptId = null, DateTime? eventTimeLocal = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("session_id", sessionId),
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>("ent_id", entId),
                new KeyValuePair<string, object>("step_no", stepNo),
                new KeyValuePair<string, object>("job_pos", jobPos),
                new KeyValuePair<string, object>("lot_no", lotNo),
                new KeyValuePair<string, object>("sublot_no", sublotNo),
                new KeyValuePair<string, object>("lab_cd", labCd),
                new KeyValuePair<string, object>("dept_id", deptId),
                new KeyValuePair<string, object>("event_time_local", eventTimeLocal),
                new KeyValuePair<string, object>("time_zone_bias_value", _timeZoneBiasValue)
            };
            Command command = new Command()
            {
                Cmd = "StepLogin",
                MsgType = "exec",
                Object = "Job_Step",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });
            return data;
        }

        public async Task<int> StepLogoutAsync(int sessionId, string userId, int entId, int stepNo, string lotNo, string sublotNo, DateTime? eventTimeLocal = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("session_id", sessionId),
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>("ent_id", entId),
                new KeyValuePair<string, object>("step_no", stepNo),
                new KeyValuePair<string, object>("lot_no", lotNo),
                new KeyValuePair<string, object>("sublot_no", sublotNo),
                new KeyValuePair<string, object>("event_time_local", eventTimeLocal),
                new KeyValuePair<string, object>("time_zone_bias_value", _timeZoneBiasValue)
            };
            Command command = new Command()
            {
                Cmd = "StepLogout",
                MsgType = "exec",
                Object = "Job_Step",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });
            return data;
        }

        public async Task<int> StopStepAsync(int sessionId, string userId, int entId, int jobPos, int stepNo, string lotNo, string sublotNo, int? stateCd = null, bool? checkCert = null, bool? laborOption = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("session_id", sessionId),
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>("ent_id", entId),
                new KeyValuePair<string, object>("job_pos", jobPos),
                new KeyValuePair<string, object>("step_no", stepNo) ,
                new KeyValuePair<string, object>("lot_no", lotNo),
                new KeyValuePair<string, object>("sublot_no", sublotNo),
                new KeyValuePair<string, object>("state_cd", stateCd),
                new KeyValuePair<string, object>("check_cert", checkCert),
                new KeyValuePair<string, object>("labor_option", laborOption),
                new KeyValuePair<string, object>("time_zone_bias_value", _timeZoneBiasValue)
            };
            Command command = new Command()
            {
                Cmd = "StopStep",
                MsgType = "exec",
                Object = "Job_Step",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });
            return data;
        }

        public async Task<int> UpdateStepDataAsync(int sessionId, string userId, int entId, int jobPos, int stepNo, string lotNo, string sublotNo, string data)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("session_id", sessionId),
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>("ent_id", entId),
                new KeyValuePair<string, object>("job_pos", jobPos),
                new KeyValuePair<string, object>("step_no", stepNo) ,
                new KeyValuePair<string, object>("lot_no", lotNo),
                new KeyValuePair<string, object>("sublot_no", sublotNo),
                new KeyValuePair<string, object>("data", data),
                new KeyValuePair<string, object>("time_zone_bias_value", _timeZoneBiasValue)
            };
            Command command = new Command()
            {
                Cmd = "UpdateStepData",
                MsgType = "exec",
                Object = "Job_Step",
                Parameters = parameters,
                Schema = "dbo"
            };

            var returnData = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });
            return returnData;
        }
    }
}

