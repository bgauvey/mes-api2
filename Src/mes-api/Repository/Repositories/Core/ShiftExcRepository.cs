//
//  AttrRepository.cs
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
using BOL.API.Domain.Models;
using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Interfaces.Core;
using BOL.API.Repository.Utils;
using Newtonsoft.Json;

namespace BOL.API.Repository.Repositories.Core;

public class ShiftExcRepository : RepositoryBase<ShiftExc>, IShiftExcRepository
{
    private readonly CommandProcessor _CommandProcessor;
    private readonly int _timeZoneBiasValue;

    public ShiftExcRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
    {
        _timeZoneBiasValue = (int)configuration.GetSection("Mes").GetValue(typeof(int), "_timeZoneBiasValue");
        _CommandProcessor = new CommandProcessor(configuration);
    }

    public async Task<string> GetExceptionsAsync(DateTime startTime, DateTime entTime)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("start_time", startTime),
            new KeyValuePair<string, object>("end_time", entTime),
            new KeyValuePair<string, object>("time_zone_bias_value", _timeZoneBiasValue)
        };

        Command command = new Command()
        {
            Cmd = "GetExceptions",
            MsgType = "getall",
            Object = "Shift_Exc",
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
