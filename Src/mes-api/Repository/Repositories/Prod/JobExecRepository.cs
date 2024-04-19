﻿//
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
using BOL.API.Domain.Models;
using BOL.API.Domain.Models.Prod;
using BOL.API.Repository.Helper;
using BOL.API.Repository.Interfaces.Prod;
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

    public async Task<string> CertSignoffAsync(string woId, string operId, int seqNo, int? stepNo, string lotNo, int prodLogId, int consLogId, string processId, int processStatus,
        bool active, string certName, string userId, DateTime? signOffLocal, string? comments, int refRowId)
    {
        int rowId = 0;
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("lot_no", lotNo),
            new KeyValuePair<string, object>("prod_log_id", prodLogId),
            new KeyValuePair<string, object>("cons_log_id", consLogId),
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("process_status", processStatus),
            new KeyValuePair<string, object>("active", active),
            new KeyValuePair<string, object>("cert_name", certName),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("sign_off_local", signOffLocal),
            new KeyValuePair<string, object>("comments", comments),
            new KeyValuePair<string, object>("ref_row_id", refRowId),
            new KeyValuePair<string, object>("time_zone_bias_value", 0),
            new KeyValuePair<string, object>("row_id OUTPUT", rowId),
        };
        Command command = new Command()
        {
            Cmd = "SignOff",
            MsgType = "",
            Object = "Cert",
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
        throw new NotImplementedException();
        // SP_CERT_SIGNOFF
    }

    public async Task<int> CertSignoffAllowedAsync(string userId, string processId, string operId, int? stepNo, string? certName)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("cert_name", certName),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "SignOff_Allowed",
            MsgType = "",
            Object = "Cert",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });

        return data;
    }

    public async Task<string> CertSignoffDoneAsync(string woId, string operId, int seqNo, int? stepNo, string? certName, string? lotNo, int? prodLogId, int? consLogId,
        string? processId, int? processStatus, bool? active)
    {
        int success = 0;
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("cert_name", certName),
            new KeyValuePair<string, object>("lot_no", lotNo),
            new KeyValuePair<string, object>("prod_log_id", prodLogId),
            new KeyValuePair<string, object>("cons_log_id", consLogId),
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("process_status", processStatus),
            new KeyValuePair<string, object>("active", active),
            new KeyValuePair<string, object>("success OUTPUT", success),
        };
        Command command = new Command()
        {
            Cmd = "SignOff_Done",
            MsgType = "",
            Object = "Cert",
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

    public async Task<string> CertSignoffReqdAsync(string processId, string operId, int? stepNo)
    {
        int success = 0;
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("success OUTPUT", success),
        };
        Command command = new Command()
        {
            Cmd = "SignOff_Reqd",
            MsgType = "",
            Object = "Cert",
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

    public async Task<int> CertStartAllowedAsync(string userId, string? processId, string? operId, int? stepNo, string? itemId)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "Start_Allowed",
            MsgType = "",
            Object = "Cert",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });

        return data;
    }

    public async Task<string> ChangeJobStatesAsync(int rowId, int? stateCd, DateTime? reqFinishTimeLocal, int? jobPriority, int? applyToAllJobs = 0)
    {
        string result = String.Empty;
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("row_id", rowId),
            new KeyValuePair<string, object>("state_cd", stateCd),
            new KeyValuePair<string, object>("req_finish_time_local", reqFinishTimeLocal),
            new KeyValuePair<string, object>("job_priority", jobPriority),
            new KeyValuePair<string, object>("apply_to_all_jobs", applyToAllJobs),
            new KeyValuePair<string, object>("time_zone_bias_value", 0),
            new KeyValuePair<string, object>("result OUTPUT", result),
        };
        Command command = new Command()
        {
            Cmd = "ChangeJobStates",
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

    public async Task<int> ChangeWOPriorityAsync(string woId, int newPriority)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("new_priority", newPriority)
        };
        Command command = new Command()
        {
            Cmd = "ChangeWOPriority",
            MsgType = "exec",
            Object = "Job_Exec",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });
        return data;
    }

    public async Task<int> ChangeWOQtysAsync(string userId, string woId, double reqQty, string? processId = null, string? itemId = null, double? startQty = null, DateTime? reqFinishTime = null, DateTime? releaseTime = null)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("req_qty", reqQty),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("start_qty", startQty),
            new KeyValuePair<string, object>("req_finish_time", reqFinishTime),
            new KeyValuePair<string, object>("release_time", releaseTime),
            new KeyValuePair<string, object>("time_zone_bias_value", 0),
        };
        Command command = new Command()
        {
            Cmd = "Job_Qty",
            MsgType = "",
            Object = "Alloc",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });
        return data;
    }

    public async Task<int> ChangeWOReqdFinishTimeAsync(string woId, DateTime reqFinishTimeLocal)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("req_finish_time_local", reqFinishTimeLocal),

        };
        Command command = new Command()
        {
            Cmd = "ChWOReqFinTime",
            MsgType = "exec",
            Object = "Job_Exec",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });
        return data;
    }

    public async Task<int> ChangeWOValuesAsync(string woId, int priority, DateTime reqFinishTimeLocal, double qtyReqd, double qtyAtStart)
    {
        string modId = String.Empty;

        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("priority", priority),
            new KeyValuePair<string, object>("req_finish_time_local", reqFinishTimeLocal),
            new KeyValuePair<string, object>("qty_reqd", qtyReqd),
            new KeyValuePair<string, object>("qty_at_start", qtyAtStart),
            new KeyValuePair<string, object>("time_zone_bias_value", 0),
            new KeyValuePair<string, object>("mod_id OUTPUT", modId)

        };
        Command command = new Command()
        {
            Cmd = "ChangeWOValues",
            MsgType = "exec",
            Object = "Job_Exec",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });
        return data;
    }

    public async Task<int> CloneJobAsync(string userId, string woId, string operId, int seqNo, string? newWoId, string? newOperId, int? newSeqNo, double? reqQty, double? startQty, DateTime? reqFinishTimeLocal)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("new_wo_id", newWoId),
            new KeyValuePair<string, object>("new_oper_id", newOperId),
            new KeyValuePair<string, object>("new_seq_no", newSeqNo),
            new KeyValuePair<string, object>("req_qty", reqQty),
            new KeyValuePair<string, object>("start_qty", startQty),
            new KeyValuePair<string, object>("req_finish_time_local", reqFinishTimeLocal),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "Clone",
            MsgType = "exec",
            Object = "Job",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });
        return data;
    }

    public async Task<int> CloneWoAsync(string userId, string woId, string newWoId, double? reqQty, string? woDesc, DateTime? releaseTimeLocal, DateTime? reqFinishTimeLocal, int? woPriority, string? custInfo, string? moId, string? notes)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("new_wo_id", newWoId),
            new KeyValuePair<string, object>("existing_wo_id", woId),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("req_qty", reqQty),
            new KeyValuePair<string, object>("wo_desc", woDesc),
            new KeyValuePair<string, object>("release_time_local", releaseTimeLocal),
            new KeyValuePair<string, object>("req_finish_time_local", reqFinishTimeLocal),
            new KeyValuePair<string, object>("wo_priority", woPriority),
            new KeyValuePair<string, object>("cust_info", custInfo),
            new KeyValuePair<string, object>("mo_id", moId),
            new KeyValuePair<string, object>("notes", notes),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "CloneWO",
            MsgType = "exec",
            Object = "Job_Exec",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });
        return data;
    }

    public async Task<int> CreateWoFromProcessAsync(string userId, string woId, string processId, string itemId, double reqQty, double? startQty = null, int? initWoState = 1,
        string? woDesc = null, DateTime? releaseTime = null, DateTime? reqFinishTime = null, int? woPriority = 1, string? custInfo = null, string? moId = null, string? notes = "",
        string? bomVerId = null, bool forFirstOp = false, string? specVerId = null, bool mayOverrideRoute = false)
    {
        if (woDesc == null) woDesc = woId;
        var parameters = new List<KeyValuePair<string, object>>
        {

            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("process_id", processId),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("req_qty", reqQty),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("start_qty", startQty),
            new KeyValuePair<string, object>("init_wo_state", initWoState),
            new KeyValuePair<string, object>("wo_desc", woDesc),
            new KeyValuePair<string, object>("release_time", releaseTime),
            new KeyValuePair<string, object>("req_finish_time", reqFinishTime),
            new KeyValuePair<string, object>("wo_priority", woPriority),
            new KeyValuePair<string, object>("cust_info", custInfo),
            new KeyValuePair<string, object>("mo_id", moId),
            new KeyValuePair<string, object>("notes", notes),
            new KeyValuePair<string, object>("bom_ver_id", bomVerId),
            new KeyValuePair<string, object>("for_first_op", forFirstOp),
            new KeyValuePair<string, object>("spec_ver_id", specVerId),
            new KeyValuePair<string, object>("may_override_route", mayOverrideRoute),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "CWOFP_Stack",
            MsgType = "add",
            Object = "Job_Exec",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });
        return data;
    }

    public async Task<int> DownloadSpecsAsync(int entId, string woId, string operId, int seqNo, int? stepNo = -1)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("existing_wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("step_no", stepNo)
        };
        Command command = new Command()
        {
            Cmd = "DownloadSpecs",
            MsgType = "exec",
            Object = "Job_Exec",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });
        return data;
    }

    public async Task<int> EndJobAsync(int entId, string woId, string operId, int seqNo, int jobPos = 0, string? statusNotes = null, string? userId = null, int? checkPrivs = null,
        int? checkCerts = null, int clientType = 37, int noPropogation = 0, int checkAutoJobStart = 1)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("job_pos", jobPos),
            new KeyValuePair<string, object>("status_notes", statusNotes),
            new KeyValuePair<string, object>("user_id", userId),
            new KeyValuePair<string, object>("check_privs", checkPrivs),
            new KeyValuePair<string, object>("check_certs", checkCerts),
            new KeyValuePair<string, object>("client_type", clientType),
            new KeyValuePair<string, object>("no_propogation", noPropogation),
            new KeyValuePair<string, object>("check_auto_job_start", checkAutoJobStart),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "EndBatchJobs",
            MsgType = "exec",
            Object = "Job_Exec",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });
        return data;
    }

    public async Task<string> GetAvailJobPosAsync(int entId)
    {
        var jobPos = 0;
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("job_pos OUTPUT", jobPos)
        };
        Command command = new Command()
        {
            Cmd = "GetAvailJobPos",
            MsgType = "getall",
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

    public async Task<string> GetAvailLotsAsync(string woId, string operId, int seqNo, int entId)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("ent_id", entId)
        };
        Command command = new Command()
        {
            Cmd = "GetAvailLots",
            MsgType = "getall",
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

    public async Task<string> GetCurrJobPosAsync(int entId, string woId, string operId, int seqNo)
    {
        int jobPos = -1;
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("job_pos OUTPUT", jobPos)
        };
        Command command = new Command()
        {
            Cmd = "GetCurrJobPos",
            MsgType = "getall",
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

    public async Task<string> GetJobBOMStepQuantitiesAsync(string woId, string operId, int seqNo, int stepNo)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("step_no", stepNo)
        };
        Command command = new Command()
        {
            Cmd = "GetJBStepQuants",
            MsgType = "getall",
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

    public async Task<string> GetJobQueueAsync(string woId, string itemId)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "GetJobQueue",
            MsgType = "getall",
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

    public async Task<string> GetJobQueueByFilterAsync(string entFilter, string jobFilter)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_filter", entFilter),
            new KeyValuePair<string, object>("job_filter", jobFilter),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "GetJobQueueByFilter",
            MsgType = "getall",
            Object = "Job",
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

    public async Task<string> GetReqdCertSignoffsAsync(string woId, string operId, int stepNo)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("step_no", stepNo)
        };
        Command command = new Command()
        {
            Cmd = "GetReqdSignoffs",
            MsgType = "getall",
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

    public async Task<string> GetRunnableEntitiesAsync(int entId)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId)
        };
        Command command = new Command()
        {
            Cmd = "GetRunnableEntities",
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

    public async Task<string> GetSchedEntsByWindowAsync(string woId = null, string operId = null, int windowId = 0)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("window_id", windowId)
        };
        Command command = new Command()
        {
            Cmd = "GetSchedEnts",
            MsgType = "getall",
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

    public async Task<string> GetSchedulableEntityAsync(int entId)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id OUTPUT", entId)
        };
        Command command = new Command()
        {
            Cmd = "GetSchedulableEntity",
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

    public async Task<string> GetSchedulableParentsAsync(int entId)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId)
        };
        Command command = new Command()
        {
            Cmd = "GetSchedParents",
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

    public async Task<string> GetStepBOMDataAsync(string woId, string operId, int seqNo, int? stepNo = null)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("step_no", stepNo)
        };
        Command command = new Command()
        {
            Cmd = "GetStepBOMData",
            MsgType = "getall",
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

    public async Task<string> LogJobEventAsync(int entId, DateTime eventTimeLocal, int jobPos, int stepNo, string eventType, int bomPos, string lotNo,string sublotNo, string itemId, string certName, string doneByUserId,
        string checkedByUserId, int sourceRowId, string specId, string comments, string value1, string value2, string value3, string value4, string value5, string value6, string value7, string value8, string value9,
        string value10, string lastEditComment)
    {
        int rowId = -1;
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("event_time_local", eventTimeLocal),
            new KeyValuePair<string, object>("job_pos", jobPos),
            new KeyValuePair<string, object>("step_no", stepNo),
            new KeyValuePair<string, object>("event_type", eventType),
            new KeyValuePair<string, object>("bom_pos", bomPos),
            new KeyValuePair<string, object>("lot_no", lotNo),
            new KeyValuePair<string, object>("sublot_no", sublotNo),
            new KeyValuePair<string, object>("item_id", itemId),
            new KeyValuePair<string, object>("cert_name", certName),
            new KeyValuePair<string, object>("done_by_user_id", doneByUserId),
            new KeyValuePair<string, object>("checked_by_user_id", checkedByUserId),
            new KeyValuePair<string, object>("source_row_id", sourceRowId),
            new KeyValuePair<string, object>("spec_id", specId),
            new KeyValuePair<string, object>("comments", comments),
            new KeyValuePair<string, object>("value1", value1),
            new KeyValuePair<string, object>("value2", value2),
            new KeyValuePair<string, object>("value3", value3),
            new KeyValuePair<string, object>("value4", value4),
            new KeyValuePair<string, object>("value5", value5),
            new KeyValuePair<string, object>("value6", value6),
            new KeyValuePair<string, object>("value7", value7),
            new KeyValuePair<string, object>("value8", value8),
            new KeyValuePair<string, object>("value9", value9),
            new KeyValuePair<string, object>("value10", value10),
            new KeyValuePair<string, object>("last_edit_comment", lastEditComment),
            new KeyValuePair<string, object>("time_zone_bias_value", 0),
            new KeyValuePair<string, object>("row_id OUTPUT", rowId),
        };
        Command command = new Command()
        {
            Cmd = "",
            MsgType = "add",
            Object = "Job_Event",
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

    public async Task<int> PauseJobAsync(int entId, string woId, string operId, int seqNo, int pausedJobState, int jobPos = 0, string statusNotes = null, DateTime? actFinishTimeLocal = null)
    {
        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("ent_id", entId),
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("paused_job_state", pausedJobState),
            new KeyValuePair<string, object>("job_pos", jobPos),
            new KeyValuePair<string, object>("status_notes", statusNotes),
            new KeyValuePair<string, object>("act_finish_time_local", actFinishTimeLocal),
            new KeyValuePair<string, object>("time_zone_bias_value", 0)
        };
        Command command = new Command()
        {
            Cmd = "PauseJob",
            MsgType = "exec",
            Object = "Job_Exec",
            Parameters = parameters,
            Schema = "dbo"
        };

        var data = await Task.Run(() =>
        {
            return _CommandProcessor.ExecuteCommand(command);

        });
        return data;
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

    public async Task<string> SetJobQueueAsync(string woId, string operId, int seqNo, int? stateCd = null, int? jobPriority = null, DateTime? reqFinishTimeLocal = null, int? targetSchedEntId = null, int? concurrentLink = null, string statusNotes = null)
    {

        int runEntId = -1;
        DateTime editTime = DateTime.Now.ToUniversalTime();
        int refreshAll = 0;

        var parameters = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("wo_id", woId),
            new KeyValuePair<string, object>("oper_id", operId),
            new KeyValuePair<string, object>("seq_no", seqNo),
            new KeyValuePair<string, object>("state_cd", stateCd),
            new KeyValuePair<string, object>("job_priority", jobPriority),
            new KeyValuePair<string, object>("req_finish_time_local", reqFinishTimeLocal),
            new KeyValuePair<string, object>("target_sched_ent_id", targetSchedEntId),
            new KeyValuePair<string, object>("concurrent_link", concurrentLink),
            new KeyValuePair<string, object>("time_zone_bias_value", 0),
            new KeyValuePair<string, object>("run_ent_id OUTPUT", runEntId),
            new KeyValuePair<string, object>("edit_time OUTPUT", editTime),
            new KeyValuePair<string, object>("refresh_all OUTPUT", refreshAll)
        };
        Command command = new Command()
        {
            Cmd = "SetJobQueue",
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

