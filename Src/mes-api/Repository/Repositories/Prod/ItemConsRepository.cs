//
// ItemConsRepository.cs
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
    public class ItemConsRepository : RepositoryBase<ItemCons>, IItemConsRepository
    {
        private readonly CommandProcessor _CommandProcessor;
        public ItemConsRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
             : base(context, loggerFactory)
        {
            _CommandProcessor = new CommandProcessor(configuration);
        }


        public async Task<string> AddConsAsync(int sessionId, string userId, int entId, int jobPos, int bomPos, double qtyCons, int? reasCd, string? lotNo, string? fgLotNo, string? sublotNo, string? fgSublotNo,
            int? fromEntId, string? itemId, string extRef, bool applyScalingFactor, string spare1, string spare2, string spare3, string spare4)
        {
            int rowId = 0;
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("session_id", sessionId),
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>("ent_id", entId),
                new KeyValuePair<string, object>("job_pos", jobPos),
                new KeyValuePair<string, object>("bom_pos", bomPos),
                new KeyValuePair<string, object>("qty_cons", qtyCons),
                new KeyValuePair<string, object>("reas_cd", reasCd),
                new KeyValuePair<string, object>("lot_no", lotNo),
                new KeyValuePair<string, object>("fg_lot_no", fgLotNo),
                new KeyValuePair<string, object>("sublot_no", sublotNo),
                new KeyValuePair<string, object>("fg_sublot_no", fgSublotNo),
                new KeyValuePair<string, object>("from_ent_id", fromEntId),
                new KeyValuePair<string, object>("item_id", itemId),
                new KeyValuePair<string, object>("ext_ref", extRef),
                new KeyValuePair<string, object>("apply_scaling_factor", applyScalingFactor),
                new KeyValuePair<string, object>("spare1", spare1),
                new KeyValuePair<string, object>("spare2", spare2),
                new KeyValuePair<string, object>("spare3", spare3),
                new KeyValuePair<string, object>("spare4", spare4),
                new KeyValuePair<string, object>("time_zone_bias_value", 0),
                new KeyValuePair<string, object>("row_id OUTPUT", rowId),
            };
            Command command = new Command()
            {
                Cmd = "AddCons",
                MsgType = "exec",
                Object = "Item_Cons",
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


        public async Task<string> AddConsDirectAsync(int fromEntId, string itemId, string lotNo, string sublotNo, double qtyCons, int reasCd, int gradeCd, int statusCd, string userId,
            string? woId = null, string? operId = null, int? seqNo = null, DateTime? shiftStartLocal = null, string? fgLotNo = null, string? fgSublotNo = null, int itemScrapped = 0,
            int? entId = null, int? shiftId = null, double qtyConsErp = 0, string? extRef = null, int transactionType = 0, string spare1 = "", string spare2 = "", string spare3 = "",
            string spare4 = "")
        {
            int rowId = 0;
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("from_ent_id", fromEntId),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("lot_no", lotNo),
            new KeyValuePair<string, object>("sublot_no", sublotNo),
            new KeyValuePair<string, object>("qty_cons", qtyCons),
            new KeyValuePair<string, object>("reas_cd", reasCd),
            new KeyValuePair<string, object>("grade_cd", gradeCd),
            new KeyValuePair<string, object>("status_cd", statusCd),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("shift_start_local", shiftStartLocal),
            new KeyValuePair<string, object>("fg_lot_no", fgLotNo),
            new KeyValuePair<string, object>("fg_sublot_no", fgSublotNo),
            new KeyValuePair<string, object>("item_scrapped", itemScrapped),
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("shift_id", shiftId),
            new KeyValuePair<string, object>("qty_cons_erp", qtyConsErp),
            new KeyValuePair<string, object>("ext_ref", extRef),
            new KeyValuePair<string, object>("transaction_type", transactionType),
            new KeyValuePair<string, object>("spare1", spare1),
            new KeyValuePair<string, object>("spare2", spare2),
            new KeyValuePair<string, object>("spare3", spare3),
            new KeyValuePair<string, object>("spare4", spare4),
            new KeyValuePair<string, object>("time_zone_bias_value", 0),
            new KeyValuePair<string, object>("row_id OUTPUT", rowId),
        };
            Command command = new Command()
            {
                Cmd = "AddConsDirect",
                MsgType = "exec",
                Object = "Item_Cons",
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


        public async Task<string> AddConsPostExecAsync(int sessionId, string userId, int entId, int? bomPos, double qtyCons, string woId, string operId, int seqNo, DateTime shiftStartLocal,
            int shiftId, string? itemId = null, int? reasCd = null, string? lotNo = null, string? fgLotNo = null, string? sublotNo = null, string? fgSublotNo = null, string? extRef = null,
            string spare1 = "", string spare2 = "", string spare3 = "", string spare4 = "")
        {
            int rowId = 0;
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("session_id", sessionId),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("bom_pos", bomPos),
            new KeyValuePair<string, object>("qty_cons", qtyCons),
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("shift_start_local", shiftStartLocal),
            new KeyValuePair<string, object>("shift_id", shiftId),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("reas_cd", reasCd),
            new KeyValuePair<string, object>("lot_no", lotNo),
            new KeyValuePair<string, object>("fg_lot_no", fgLotNo),
            new KeyValuePair<string, object>("sublot_no", sublotNo),
            new KeyValuePair<string, object>("fg_sublot_no", fgSublotNo),
            new KeyValuePair<string, object>("ext_ref", extRef),
            new KeyValuePair<string, object>("spare1", spare1),
            new KeyValuePair<string, object>("spare2", spare2),
            new KeyValuePair<string, object>("spare3", spare3),
            new KeyValuePair<string, object>("spare4", spare4),
            new KeyValuePair<string, object>("row_id OUTPUT", rowId),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
            Command command = new Command()
            {
                Cmd = "AddConsPostExec",
                MsgType = "exec",
                Object = "Item_Cons",
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
