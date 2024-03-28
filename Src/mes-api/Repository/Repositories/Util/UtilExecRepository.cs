//
//  UtilExecRepository.cs
//
//  Author:
//       Bill Gauvey <Bill.Gauvey@barretteoutdoorliving.com>
//
//  Copyright (c) 2024 Barrette Outdoor Living
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Data;
using System.Dynamic;
using BOL.API.Domain.Models;
using BOL.API.Domain.Models.Util;
using BOL.API.Repository.Helper;
using BOL.API.Repository.Interfaces.Util;
using BOL.API.Repository.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BOL.API.Repository.Util;

public class UtilExecRepository : RepositoryBase<UtilExec>, IUtilExecRepository
{
    private readonly IConfiguration _Configuration;
    private readonly CommandProcessor _CommandProcessor;
    public UtilExecRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
    {
        _Configuration = configuration;
        _CommandProcessor = new CommandProcessor(_Configuration);
    }

    public async Task<string> GetAvailableReasonsAsync(int entId, int rawReasCode)
    {
        var parameters = new List<KeyValuePair<string, object>>();
        parameters.Add(new KeyValuePair<string, object>("in_ent_id", entId));
        parameters.Add(new KeyValuePair<string, object>("in_raw_reas_cd", rawReasCode));
        Command command = new Command()
        {
            Cmd = "GETAVAILREASNS",
            MsgType = "getall",
            Object = "UTIL_EXEC",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            DataTable dt = _CommandProcessor.GetDataTableFromCommand(command);

            var jsonString = JsonConvert.SerializeObject(dt, Formatting.Indented);

            return jsonString;
        });

        //dynamic dsObject = JsonConvert.DeserializeObject<ExpandoObject>(data);
        return data;
    }

    public async Task<string> GetOldAvailableReasonsAsync(int entId, int reasCode)
    {
        var parameters = new List<KeyValuePair<string, object>>();
        parameters.Add(new KeyValuePair<string, object>("ent_id", entId));
        parameters.Add(new KeyValuePair<string, object>("reas_cd", reasCode));
        Command command = new Command()
        {
            Cmd = "GetOldAvalReas",
            MsgType = "getall",
            Object = "Util_Exec",
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

    public object GetStatusInfoByUser()
    {
        throw new NotImplementedException();
    }

    public int SetPendingReason()
    {
        throw new NotImplementedException();
    }

    public int SetRawReas()
    {
        throw new NotImplementedException();
    }

    public int SetReason()
    {
        throw new NotImplementedException();
    }

    public int UpdateDurations()
    {
        throw new NotImplementedException();
    }
}

