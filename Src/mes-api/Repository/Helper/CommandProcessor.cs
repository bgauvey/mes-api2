//
// CommandProcessor.cs
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
using System.Runtime.CompilerServices;
using BOL.API.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Repository.Helper
{
    public class CommandProcessor
	{
        private readonly IConfiguration _Configuration;
        public CommandProcessor(IConfiguration configuration)
		{
            _Configuration = configuration;
		}

        public int ExecuteCommand(Command command)
        {
            var conStr = _Configuration.GetConnectionString("DefaultConnection");
            var sqlConnection = new SqlConnection(conStr);
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                var cmd = parseCommand(command);
                sqlCommand.CommandText = cmd.StoredProcedure;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (cmd.parmaeters != null)
                {
                    foreach (var p in cmd.parmaeters)
                    {
                        var dbParameter = sqlCommand.CreateParameter();
                        dbParameter.ParameterName = p.Key;
                        if (p.Value != null)
                        {
                            var t = p.Value.GetType();
                            if (t is string)
                                dbParameter.Value = p.Value.ToString();
                            else
                                dbParameter.Value = p.Value;
                        }
                        sqlCommand.Parameters.Add(dbParameter);
                    }
                }
                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public DataTable GetDataTableFromCommand(Command command)
		{
            var conStr = _Configuration.GetConnectionString("DefaultConnection");
            var sqlConnection = new SqlConnection(conStr);

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                var cmd = parseCommand(command);
                sqlCommand.CommandText = cmd.StoredProcedure;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (cmd.parmaeters != null)
                {
                    foreach (var p in cmd.parmaeters)
                    {
                        var dbParameter = sqlCommand.CreateParameter();
                        dbParameter.ParameterName = p.Key;
                        if (p.Value != null)
                        {
                            var t = p.Value.GetType();
                            if (t is string)
                                dbParameter.Value = p.Value.ToString();
                            else
                                dbParameter.Value = p.Value;
                        }
                        sqlCommand.Parameters.Add(dbParameter);
                    }
                }
                sqlConnection.Open();
                using (var result = sqlCommand.ExecuteReader())
                {
                    dt.TableName = command.Object;
                    dt.Load(result);
                }
            }
            return dt;
        }


        #region Private Methods
        private (string StoredProcedure, List<KeyValuePair<string, object>> parmaeters) parseCommand(Command command)
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
}

