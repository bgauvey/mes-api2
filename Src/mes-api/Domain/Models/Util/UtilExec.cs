using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Util;

[Table("util_exec")]
public partial class UtilExec
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("cur_state_cd")]
    public int? CurStateCd { get; set; }

    [Column("cur_reas_cd")]
    public int? CurReasCd { get; set; }

    [Column("cur_reas_start_utc", TypeName = "datetime")]
    public DateTime? CurReasStartUtc { get; set; }

    [Column("cur_reas_start_local", TypeName = "datetime")]
    public DateTime? CurReasStartLocal { get; set; }

    [Column("cur_raw_reas_cd")]
    [StringLength(40)]
    public string? CurRawReasCd { get; set; }

    [Column("reas_reqd")]
    public bool ReasReqd { get; set; }

    [Column("cur_log_id")]
    public int? CurLogId { get; set; }

    [Column("target_util")]
    public double? TargetUtil { get; set; }

    [Column("current_util")]
    public double? CurrentUtil { get; set; }

    [Column("jobstart_reas_cd")]
    public int? JobstartReasCd { get; set; }

    [Column("jobend_reas_cd")]
    public int? JobendReasCd { get; set; }

    [Column("shift_start_reas_cd")]
    public int? ShiftStartReasCd { get; set; }

    [Column("shift_end_reas_cd")]
    public int? ShiftEndReasCd { get; set; }

    [Column("unkn_stop_reas_cd")]
    public int? UnknStopReasCd { get; set; }

    [Column("break_start_reas_cd")]
    public int? BreakStartReasCd { get; set; }

    [Column("break_end_reas_cd")]
    public int? BreakEndReasCd { get; set; }

    [Column("inherit_from_parent")]
    public bool InheritFromParent { get; set; }

    [Column("spare1")]
    [StringLength(1000)]
    public string? Spare1 { get; set; }

    [Column("spare2")]
    [StringLength(1000)]
    public string? Spare2 { get; set; }

    [Column("spare3")]
    [StringLength(1000)]
    public string? Spare3 { get; set; }

    [Column("spare4")]
    [StringLength(1000)]
    public string? Spare4 { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }
}
