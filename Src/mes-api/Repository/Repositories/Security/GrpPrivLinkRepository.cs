//
// GrpPrivLinkRepository.cs
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
using BOL.API.Domain.Models.Security;
using BOL.API.Repository.Interfaces.Security;
using BOL.API.Repository.Utils;
using Newtonsoft.Json;

namespace BOL.API.Repository.Repositories.Security
{
	public class GrpPrivLinkRepository : RepositoryBase<GrpPrivLink>, IGrpPrivLinkRepository
	{
        private readonly IConfiguration _Configuration;
        private readonly CommandProcessor _CommandProcessor;

        public GrpPrivLinkRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
        {
            _Configuration = configuration;
            _CommandProcessor = new CommandProcessor(_Configuration);
        }

        public async Task<string> GetPrivAsync(string userId, int privId)
        {
            var privValue = -1;
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>("priv_id", privId),
                new KeyValuePair<string, object>("priv_value OUTPUT", privValue)
            };
            Command command = new Command()
            {
                Cmd = "GetPriv",
                MsgType = "getspec",
                Object = "Grp_Priv_Link",
                Parameters = parameters,
                Schema = "dbo"
            };

            var returnData = await Task.Run(() =>
            {
                DataTable dt = _CommandProcessor.GetDataTableFromCommand(command);

                var jsonString = JsonConvert.SerializeObject(dt, Formatting.Indented);

                return jsonString;
            });

            return returnData;
        }

        public async Task<string> GetPrivilegesByUserAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId)
            };
            Command command = new Command()
            {
                Cmd = "By_User",
                MsgType = "getspec",
                Object = "Grp_Priv_Link",
                Parameters = parameters,
                Schema = "dbo"
            };

            var returnData = await Task.Run(() =>
            {
                DataTable dt = _CommandProcessor.GetDataTableFromCommand(command);

                var jsonString = JsonConvert.SerializeObject(dt, Formatting.Indented);

                return jsonString;
            });

            return returnData;
        }

        public async Task<string> GetUsersByPrivilegeAsync(int privId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("priv_id", privId)
            };
            Command command = new Command()
            {
                Cmd = "By_Priv",
                MsgType = "getspec",
                Object = "Grp_Priv_Link",
                Parameters = parameters,
                Schema = "dbo"
            };

            var returnData = await Task.Run(() =>
            {
                DataTable dt = _CommandProcessor.GetDataTableFromCommand(command);

                var jsonString = JsonConvert.SerializeObject(dt, Formatting.Indented);

                return jsonString;
            });

            return returnData;
        }
    }
}

