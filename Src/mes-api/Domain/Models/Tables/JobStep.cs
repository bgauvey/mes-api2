using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("WoId", "OperId", "SeqNo", "StepNo")]
[Table("job_step")]
public partial class JobStep
{
    [Key]
    [Column("wo_id")]
    [StringLength(40)]
    public string WoId { get; set; } = null!;

    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Key]
    [Column("seq_no")]
    public int SeqNo { get; set; }

    [Key]
    [Column("step_no")]
    public int StepNo { get; set; }

    [Column("step_seq")]
    public int StepSeq { get; set; }

    [Column("step_name")]
    [StringLength(40)]
    public string? StepName { get; set; }

    [Column("step_desc")]
    [StringLength(1700)]
    public string StepDesc { get; set; } = null!;

    [Column("action_type")]
    public int ActionType { get; set; }

    [Column("std_time")]
    public double StdTime { get; set; }

    [Column("complete_cond")]
    public int CompleteCond { get; set; }

    [Column("allow_bypass")]
    public bool AllowBypass { get; set; }

    [Column("enter_data")]
    public bool EnterData { get; set; }

    [Column("step_grp_id")]
    public int StepGrpId { get; set; }

    [Column("spc_char")]
    [StringLength(40)]
    public string? SpcChar { get; set; }

    [Column("form_name")]
    [StringLength(254)]
    public string? FormName { get; set; }

    [Column("data_log_grp_id")]
    public int? DataLogGrpId { get; set; }

    [Column("reqd_rep")]
    public int ReqdRep { get; set; }

    [Column("control_type")]
    public int ControlType { get; set; }

    [Column("high_limit")]
    public double? HighLimit { get; set; }

    [Column("low_limit")]
    public double? LowLimit { get; set; }

    [Column("limit_warning")]
    public bool LimitWarning { get; set; }

    [Column("spare1")]
    [StringLength(80)]
    public string? Spare1 { get; set; }

    [Column("spare2")]
    [StringLength(80)]
    public string? Spare2 { get; set; }

    [Column("spare3")]
    [StringLength(80)]
    public string? Spare3 { get; set; }

    [Column("spare4")]
    [StringLength(80)]
    public string? Spare4 { get; set; }

    [Column("spare5")]
    [StringLength(80)]
    public string? Spare5 { get; set; }

    [Column("spare6")]
    [StringLength(80)]
    public string? Spare6 { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("row_id")]
    public int RowId { get; set; }
}
