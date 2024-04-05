//
//  JobExecRepository.cs
//
//  Author:
//       Bill Gauvey <Bill.Gauvey@barretteoutdoorliving.com>
//
//  Copyright (c) 2024 Barrette Outdoor Living
//
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
using System.Diagnostics;
using api.Models;
using BOL.API.Domain.Models;
using BOL.API.Domain.Models.Core;
using BOL.API.Domain.Models.EnProd;
using BOL.API.Domain.Models.Prod;
using BOL.API.Repository.Helper;
using BOL.API.Repository.Interfaces.Prod;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BOL.API.Repository.Repositories.Prod;

public class JobExecRepository : RepositoryBase<JobExec>, IJobExecRepository
{
    private readonly CommandProcessor _CommandProcessor;
    public JobExecRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
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
            Cmd = "addcons",
            MsgType = "exec",
            Object = "item_Cons",
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
            Cmd = "addconsdirect",
            MsgType = "exec",
            Object = "item_Cons",
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
            Cmd = "addconspostexec",
            MsgType = "exec",
            Object = "item_Cons",
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

    public async Task<string> AddProdAsync(int sessionId, string userId, int entId, double qtyProd, int? reasCd = null, string? lotNo = null, string? sublotNo = null,
        int? toEntId = null, string? itemId = null, int? byproductBomPos = null, string? extRef = null, bool applyScalingFactor = false, string spare1 = " ",
        string spare2 = " ", string spare3 = " ", string spare4 = " ", int jobPos = 0)
    {

        int rowId = 0;
        string prodInfo = "";
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("session_id", sessionId),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("job_pos", jobPos),
            new KeyValuePair<string, object>("qty_prod", qtyProd),
            new KeyValuePair<string, object>("reas_cd", reasCd),
            new KeyValuePair<string, object>("lot_no", lotNo),
            new KeyValuePair<string, object>("sublot_no", sublotNo),
            new KeyValuePair<string, object>("to_ent_id", toEntId),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("byproduct_bom_pos", byproductBomPos),
            new KeyValuePair<string, object>("ext_ref", extRef),
            new KeyValuePair<string, object>("apply_scaling_factor", applyScalingFactor),
            new KeyValuePair<string, object>("spare1", spare1),
            new KeyValuePair<string, object>("spare2", spare2),
            new KeyValuePair<string, object>("spare3", spare3),
            new KeyValuePair<string, object>("spare4", spare4),
            new KeyValuePair<string, object>("time_zone_bias_value", 0),
            new KeyValuePair<string, object>("row_id OUTPUT", rowId),
            new KeyValuePair<string, object>("prod_info OUTPUT", prodInfo)
        };
        Command command = new Command()
        {
            Cmd = "AddProd",
            MsgType = "exec",
            Object = "Job_Exec",
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

    public async Task<int> AddProdPostExecAsync(int sessionId, string userId, int entId, double qtyProd, string woId, string operId, int seqNo, DateTime shiftStartLocal,
        int shiftId, string? itemId, int? reasCd, string? lotNo, string? sublotNo, int? toEntId, bool? processed, bool? byproduct, string extRef, int? moveStatus,
        string? spare1, string? spare2, string? spare3, string? spare4)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("session_id", sessionId),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("qty_prod", qtyProd),
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("shift_start_local", shiftStartLocal),
            new KeyValuePair<string, object>("shift_id", shiftId),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("reas_cd", reasCd),
            new KeyValuePair<string, object>("lot_no", lotNo),
            new KeyValuePair<string, object>("sublot_no", sublotNo),
            new KeyValuePair<string, object>("to_ent_id", toEntId),
            new KeyValuePair<string, object>("processed", processed),
            new KeyValuePair<string, object>("byproduct", byproduct),
            new KeyValuePair<string, object>("ext_ref", extRef),
            new KeyValuePair<string, object>("spare1", spare1),
            new KeyValuePair<string, object>("spare2", spare2),
            new KeyValuePair<string, object>("spare3", spare3),
            new KeyValuePair<string, object>("spare4", spare4),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
            
        };
        Command command = new Command()
        {
            Cmd = "AddProdPostExec",
            MsgType = "exec",
            Object = "Job_Exec",
            Parameters = parameters,
            Schema = "dbo"
        };

        var rowsAffected = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);
        });

        return rowsAffected;
    }

    public async Task<int> CancelAllJobsAsync(string woId)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId)
        };
        Command command = new Command()
        {
            Cmd = "CancelAllJobs",
            MsgType = "exec",
            Object = "Job_Exec",
            Parameters = parameters,
            Schema = "dbo"
        };

        var rowsAffected = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);
        });

        return rowsAffected;
    }

    public async Task<string> CertSignoffAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<string> CertSignoffAllowedAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<string> CertSignoffDoneAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<string> CertSignoffReqdAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<string> CertStartAllowedAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<string> ChangeJobStatesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<string> ChangeSpecValueAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> ChangeSpecValuesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> ChangeWOPriorityAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> ChangeWOQtysAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> ChangeWOReqdFinishTimeAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> ChangeWOValuesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> CloneJobAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> CloneWOAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateWOFromProcessAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> DownloadSpecsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> EndJobAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetAvailJobPosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetAvailLotsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetCurrJobPosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetJobBOMStepQuantitiesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetJobQueueAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetQueueAsync()
    {
        throw new NotImplementedException();
        // SP_SA_JOB_EXEC_GETQUEUE
    }

    public Task<string> GetReqdCertSignoffsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetRunnableEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetSchedEntsByWindowAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetSchedulableEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetSchedulableEntityAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetSchedulableParentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetStepBOMDataAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> InsertProdViaFCAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> LogJobEventAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> PauseJobAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> RejectProdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> SetActualSpecValueAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> SetAttrAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> SetCurLotDataAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> SetJobQueueAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> SetUIScreenTagValuesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> SplitJobAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> StartDataEntryJobAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> StartJobAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> StartNextJobViaFCAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> StartSomeAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> StartStepAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> StepLoginAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> StepLogoutAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> StopStepAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> TransQtyToCurJobAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateStepDataAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateTemplateSpecValuesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> VerifyProcessAsync()
    {
        throw new NotImplementedException();
    }

}

