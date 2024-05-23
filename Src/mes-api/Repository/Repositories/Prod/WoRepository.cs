//
// WoRepository.cs
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
	public class WoRepository: RepositoryBase<Wo>, IWoRepository
    {
        private readonly CommandProcessor _CommandProcessor;

        public WoRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
        {
            _CommandProcessor = new CommandProcessor(configuration);
        }


        public async Task<string> GetNextWoIdAsync(string nextWoId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("next_wo_id", nextWoId),
            };
            Command command = new Command()
            {
                Cmd = "GetNextWoId",
                MsgType = "getyall",
                Object = "Wo",
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

