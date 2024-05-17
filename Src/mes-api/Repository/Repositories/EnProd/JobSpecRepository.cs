//
// JobSpecRepository.cs
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
    public class JobSpecRepository : RepositoryBase<JobSpec>, IJobSpecRepository
    {
        private readonly CommandProcessor _CommandProcessor;
        private readonly int _timeZoneBiasValue;

        public JobSpecRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
             : base(context, loggerFactory)
        {
            _timeZoneBiasValue = (int)configuration.GetSection("Mes").GetValue(typeof(int), "_timeZoneBiasValue");
            _CommandProcessor = new CommandProcessor(configuration);
        }

        public async Task<int> ChangeSpecValueAsync(string userId, int entId, string specId, string newSpecValue, bool updateTemplate, int bomPos = 0, string? bomVerId = null, string? comments = null, int jobPos = 0)
        {
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("spec_id", specId),
            new KeyValuePair<string, object>("new_spec_value", newSpecValue),
            new KeyValuePair<string, object>("update_template", updateTemplate),
            new KeyValuePair<string, object>("bom_pos", bomPos),
            new KeyValuePair<string, object>("bom_ver_id", bomVerId),
            new KeyValuePair<string, object>("comments", comments),
            new KeyValuePair<string, object>("job_pos", jobPos),
            new KeyValuePair<string, object>("time_zone_bias_value", _timeZoneBiasValue)
        };
            Command command = new Command()
            {
                Cmd = "ChangeSpecValue",
                MsgType = "exec",
                Object = "Job_Spec",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });
            return data;
        }

        public async Task<int> ChangeSpecValuesAsync(int sessionId, string userId, int entId, string? newSpecValue, string? newMinValue, string? newMaxValue, bool updateTemplate = false, int checkPrivs = 0,
            int bomPos = 0, string? bomVerId = null, string comments = "", int jobPos = 0)
        {
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("session_id", sessionId),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("new_spec_value", newSpecValue),
            new KeyValuePair<string, object>("new_min_value", newMinValue),
            new KeyValuePair<string, object>("new_max_value", newMaxValue),
            new KeyValuePair<string, object>("update_template", updateTemplate),
            new KeyValuePair<string, object>("check_privs", checkPrivs),
            new KeyValuePair<string, object>("bom_pos", bomPos),
            new KeyValuePair<string, object>("bom_ver_id", bomVerId),
            new KeyValuePair<string, object>("comments", comments),
            new KeyValuePair<string, object>("job_pos", jobPos),
            new KeyValuePair<string, object>("time_zone_bias_value", _timeZoneBiasValue)
        };
            Command command = new Command()
            {
                Cmd = "ChangeSpecValues",
                MsgType = "exec",
                Object = "Job_Spec",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });
            return data;
        }

        public async Task<int> UpdateTemplateSpecValuesAsync(int sessionId, string userId, int entId, int? checkPrivs, int? jobPos)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("session_id", sessionId),
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>("ent_id", entId),
                new KeyValuePair<string, object>("check_privs", checkPrivs),
                new KeyValuePair<string, object>("job_pos", jobPos)
            };
            Command command = new Command()
            {
                Cmd = "UpdTemplSpecVals",
                MsgType = "exec",
                Object = "Job_Spec",
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