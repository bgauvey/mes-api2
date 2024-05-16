//
// GrpEntLinkRepository.cs
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
    public class GrpEntLinkRepository : RepositoryBase<GrpEntLink>, IGrpEntLinkRepository
	{
        private readonly CommandProcessor _CommandProcessor;
        public GrpEntLinkRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
        {
            _CommandProcessor = new CommandProcessor(configuration);
        }

        public async Task<string> CanAccessAsync(int grpId, int entId)
        {
            int accss = -1;
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("grp_id", grpId),
                new KeyValuePair<string, object>("ent_id", entId),
                new KeyValuePair<string, object>("accss OUTPUT", accss)
            };
            Command command = new Command()
            {
                Cmd = "Can_Access",
                MsgType = "getspec",
                Object = "Grp_Ent_Link",
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

        public async Task<string> GetEntAccessByUserAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId)
            };
            Command command = new Command()
            {
                Cmd = "EntAccByUser",
                MsgType = "getspec",
                Object = "Grp_Ent_Link",
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

        public async Task<string> GetGrpAccessByEntAsync(int entId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("ent_id", entId)
            };
            Command command = new Command()
            {
                Cmd = "GrpAccByEnt",
                MsgType = "getspec",
                Object = "Grp_Ent_Link",
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

        public async Task<string> GetUserAccessByEntAsync(int entId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("ent_id", entId)
            };
            Command command = new Command()
            {
                Cmd = "UserAccByEnt",
                MsgType = "getspec",
                Object = "Grp_Ent_Link",
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

