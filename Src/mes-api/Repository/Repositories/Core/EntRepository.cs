using System.Data;
using System.Xml.Linq;
using BOL.API.Domain.Models;
using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Helper;
using BOL.API.Repository.Interfaces.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BOL.API.Repository.Repositories.Core;

public class EntRepository : RepositoryBase<Ent>, IEntRepository
{
    private readonly IConfiguration _Configuration;
    private readonly CommandProcessor _CommandProcessor;
    public EntRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
    {
        _Configuration = configuration;
        _CommandProcessor = new CommandProcessor(_Configuration);
    }

    public async Task<string> GetAllTopLevelAsync()
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "GetTopLevelEnts",
            MsgType = "getall",
            Object = "Ent",
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

    public async Task<string> GetStatusInfoByUserAsync(int sessionId, string userId)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("session_id", sessionId),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "GetStatusByUser",
            MsgType = "getall",
            Object = "Ent",
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

    public async Task<string> GetShiftSchedEntitiesAsync(int entId)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "GetShiftSchedEnts",
            MsgType = "getall",
            Object = "Ent",
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

    public async Task<string> GetStatusInfoAsync(int entId, int childLevels)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("child_levels", childLevels),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "GetStatus",
            MsgType = "getall",
            Object = "Ent",
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

    public async Task<string> GetShiftTemplatesAsync(int entId, DateTime startDate, DateTime endDate)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("start_date", startDate),
            new KeyValuePair<string, object>("end_date", endDate),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "Sched_GetSched",
            MsgType = "getspec",
            Object = "Shift",
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




    public async Task<int> DoAutoShiftChangesAsync(int entId)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "DoAutoShiftChanges",
            MsgType = "exec",
            Object = "ent",
            Parameters = parameters,
            Schema = "dbo"
        };

        var rowsAffected = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);
        });

        return rowsAffected;
    }

    public async Task<int> DoPastShiftChangesAsync()
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "DoPastShiftChanges",
            MsgType = "exec",
            Object = "ent",
            Parameters = parameters,
            Schema = "dbo"
        };

        var rowsAffected = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);
        });

        return rowsAffected;
    }

    public async Task<int> StartShiftAsync(int entId, int shiftId, DateTime shiftStart)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("shift_id", shiftId),
            new KeyValuePair<string, object>("shift_start", shiftStart),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "StartShift",
            MsgType = "exec",
            Object = "ent",
            Parameters = parameters,
            Schema = "dbo"
        };

        var rowsAffected = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);
        });

        return rowsAffected;
    }

    public async Task<string> RefreshShiftSchedAsync(int inEntId, DateTime inStartTime, int inDaysAhead = 7)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("in_ent_id", inEntId),
            new KeyValuePair<string, object>("in_start_time", inStartTime),
            new KeyValuePair<string, object>("in_days_ahead", inDaysAhead),
            new KeyValuePair<string, object>("in_time_zone_bias_value", 0),
            new KeyValuePair<string, object>("shift_sched_ent OUTPUT", 0),
            new KeyValuePair<string, object>("shift_start_time OUTPUT", DateTime.Now),
            new KeyValuePair<string, object>("shift_end_time OUTPUT", DateTime.Now)
        };
        Command command = new Command()
        {
            Cmd = "RefreshShiftSched",
            MsgType = "exec",
            Object = "ent",
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

    public async Task<string> GetRefreshShiftSchedAsync(int inEntId, DateTime inStartTime, int inDaysAhead = 7)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("in_ent_id", inEntId),
            new KeyValuePair<string, object>("in_start_time", inStartTime),
            new KeyValuePair<string, object>("in_days_ahead", inDaysAhead),
            new KeyValuePair<string, object>("in_time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "GetRefrshdShiftSched",
            MsgType = "exec",
            Object = "ent",
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

    public async Task<string> GetShiftSchedulesAsync(int inEntId, DateTime startTime, DateTime endTime)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("in_ent_id", inEntId),
            new KeyValuePair<string, object>("start_time", startTime),
            new KeyValuePair<string, object>("end_time", endTime),
            new KeyValuePair<string, object>("in_time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "GetRefrshdShiftSched",
            MsgType = "exec",
            Object = "ent",
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
    /*
     * 
      {
        "_name": "ENT.CLONE"
      },

    */
}
