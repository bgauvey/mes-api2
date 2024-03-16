//
//  UtilityRepository.cs
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
using System.Runtime.CompilerServices;
using BOL.API.Domain.Models;
using BOL.API.Repository.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BOL.API.Repository.Repositories.Generic;

public class GenericRepository : IGenericRepository
	{
    private readonly FactelligenceContext _Context;
    private readonly ILogger _Logger;

    public GenericRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
    {
        _Context = context;
        _Logger = loggerFactory.CreateLogger( nameof(GenericRepository) );
    }

    public async Task<int> ExecuteCommand(Command command)
    {
        string sqlCmd = parseCommandAsScalar(command);
        return await _Context.Database.ExecuteSqlRawAsync(sqlCmd);

        // var sql = GetFormattableString(command);
        // return await _Context.Database.ExecuteSqlInterpolatedAsync(sql);
    }

    public async Task<object> GetFromCommand(Command command)
    {
        var dataSet = await Task.Run(() =>
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            using (var sqlCommand = _Context.Database.GetDbConnection().CreateCommand())
            {
                var cmd = parseCommand(command);
                sqlCommand.CommandText = cmd.StoredProcedure ;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (cmd.parmaeters != null)
                    foreach (var p in cmd.parmaeters)
                    {
                        var dbParameter = sqlCommand.CreateParameter();
                        dbParameter.ParameterName = p.Key;
                        var t = p.Value.GetType();
                        dbParameter.Value =  p.Value.ToString();
                        sqlCommand.Parameters.Add(dbParameter);

                    }
                _Context.Database.OpenConnection();
                using (var result = sqlCommand.ExecuteReader())
                {
                    dt.TableName = command.Object;
                    dt.Load(result);
                }
            }
            var jsonString = JsonConvert.SerializeObject(ds, Formatting.Indented);
            return jsonString;
        });

        dynamic dsObject = JsonConvert.DeserializeObject<ExpandoObject>(dataSet);
        return dsObject;
    }

    #region Private Methods
    private (string StoredProcedure, List<KeyValuePair<string,object>> parmaeters) parseCommand(Command command)
    {
  
        var sp = getSpFromCommand(command);
        return (sp, command.Parameters);
    }


    private string parseCommandAsScalar(Command command)
    {
        var sqlCommand = getSpFromCommand(command);

        if (command.Parameters != null)
        {
            string commandParameter = "";
            foreach (var p in command.Parameters)
            {
                commandParameter = string.Concat(" @", p.Key, "='", p.Value.ToString(), "',");
                sqlCommand += commandParameter;
            }
        }
        sqlCommand = sqlCommand.TrimEnd(',');
        return $"EXEC {sqlCommand}";
    }

    private string getSpFromCommand(Command command)
    {
        string schema = String.IsNullOrEmpty(command.Schema) ? "dbo" : command.Schema;
        string messageType = "U";
        switch (command.MsgType.ToLower())
        {
            case "exec":
                messageType = "U_";
                break;
            case "getall":
                messageType = "SA_";
                break;
            case "getspec":
                messageType = "S_";
                break;
            case "add":
                messageType = "I_";
                break;
            case "remove":
                messageType = "D_";
                break;
        }

        var sqlCommand = $"{schema}.sp_{messageType}{command.Object}_{command.Cmd}";
        return sqlCommand.TrimEnd('_');

    }

    private FormattableString GetFormattableString(Command command)
    {
        var sqlCommand = getSpFromCommand(command);

        List<object> arguments = new List<object>();
        if (command.Parameters != null)
        {
            string commandParameter = "";
            foreach (var p in command.Parameters)
            {
                arguments.Add(p.Value);
                commandParameter = string.Concat(" @", p.Key, "= {", p.Key, "},");
                sqlCommand += commandParameter;
            }
        }
        sqlCommand = sqlCommand.TrimEnd(',');

       

        return FormattableStringFactory.Create(sqlCommand, arguments.ToArray());
    }
    #endregion
}

