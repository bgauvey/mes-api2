using System.Data;
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

    public async Task<string> GetStatusInfoByUserAsync(int sessionId, string userId = "")
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
}
