//
// IItemProdRepository.cs
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
using System;
using BOL.API.Domain.Models;
using BOL.API.Domain.Models.Prod;
using BOL.API.Repository.Helper;
using BOL.API.Repository.Interfaces.Prod;

namespace BOL.API.Repository.Repositories.Prod
{
	public class ItemProdRepository : RepositoryBase<ItemProd>, IItemProdRepository
	{
        private readonly CommandProcessor _CommandProcessor;

        public ItemProdRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
        {
            _CommandProcessor = new CommandProcessor(configuration);
        }

        public async Task<int> RejectProdAsync(int sessionId, int oldRowId, double splitQtyProd, string newWoId = null, string newOperId = null, int? newSeqNo = null, DateTime? newShiftStartLocal = null,
            string newItemId = null, string newLotNo = null, string newRmLotNo = null, string newSublotNo = null, string newRmSublotNo = null, int? newReasCd = null, string newUserId = null, int? newEntId = null,
            int? newShiftId = null, int? newToEntId = null, double? splitQtyProdErp = null, bool splitProcessedFlag = false, bool splitByproductFlag = false)
        {
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("session_id", sessionId),
            new KeyValuePair<string, object>("old_row_id", oldRowId),
            new KeyValuePair<string, object>("split_qty_prod", splitQtyProd),
            new KeyValuePair<string, object>("new_wo_id", newWoId),
            new KeyValuePair<string, object>("new_oper_id", newOperId),
            new KeyValuePair<string, object>("new_seq_no", newSeqNo),
            new KeyValuePair<string, object>("new_shift_start_local", newShiftStartLocal),
            new KeyValuePair<string, object>("new_item_id", newItemId),
            new KeyValuePair<string, object>("new_lot_no", newLotNo),
            new KeyValuePair<string, object>("new_rm_lot_no", newRmLotNo),
            new KeyValuePair<string, object>("new_sublot_no", newSublotNo),
            new KeyValuePair<string, object>("new_rm_sublot_no", newRmSublotNo),
            new KeyValuePair<string, object>("new_reas_cd", newReasCd),
            new KeyValuePair<string, object>("new_user_id", newUserId),
            new KeyValuePair<string, object>("new_ent_id", newEntId),
            new KeyValuePair<string, object>("new_shift_id", newShiftId),
            new KeyValuePair<string, object>("new_to_ent_id", newToEntId),
            new KeyValuePair<string, object>("split_qty_prod_erp", splitQtyProdErp),
            new KeyValuePair<string, object>("split_processed_flag", splitProcessedFlag),
            new KeyValuePair<string, object>("split_byproduct_flag", splitByproductFlag),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
            Command command = new Command()
            {
                Cmd = "Split",
                MsgType = "exec",
                Object = "Item_Prod",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });
            return data;
        }

        public async Task<int> SetCurLotDataAsync(int entId, int jobPos, int bomPos, string curItemId, string curLotNo, string curSublotNo, int curReasCd, int curStorageEntId, bool curUpdateInv, bool curBackflush)
        {
            var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("job_pos", jobPos),
            new KeyValuePair<string, object>("bom_pos", bomPos),
            new KeyValuePair<string, object>("cur_item_id", curItemId),
            new KeyValuePair<string, object>("cur_lot_no", curLotNo),
            new KeyValuePair<string, object>("cur_sublot_no", curSublotNo),
            new KeyValuePair<string, object>("cur_reas_cd", curReasCd),
            new KeyValuePair<string, object>("cur_storage_ent_id", curStorageEntId),
            new KeyValuePair<string, object>("cur_update_inv", curUpdateInv),
            new KeyValuePair<string, object>("cur_backflush", curBackflush),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
            Command command = new Command()
            {
                Cmd = "SetCurLotData",
                MsgType = "exec",
                Object = "Item_Prod",
                Parameters = parameters,
                Schema = "dbo"
            };

            var data = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);

            });
            return data;
        }

    }
}

