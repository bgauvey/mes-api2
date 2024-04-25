using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.EnProd;

[Table("job_step_data")]
public partial class JobStepDatum
{
    [Column("wo_id")]
    [StringLength(40)]
    public string WoId { get; set; } = null!;

    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Column("seq_no")]
    public int SeqNo { get; set; }

    [Column("step_no")]
    public int StepNo { get; set; }

    [Column("lot_no")]
    [StringLength(40)]
    public string? LotNo { get; set; }

    [Column("sublot_no")]
    [StringLength(40)]
    public string? SublotNo { get; set; }

    [Column("state_cd")]
    public int StateCd { get; set; }

    [Column("act_start_time_utc", TypeName = "datetime")]
    public DateTime? ActStartTimeUtc { get; set; }

    [Column("act_start_time_local", TypeName = "datetime")]
    public DateTime? ActStartTimeLocal { get; set; }

    [Column("act_finish_time_utc", TypeName = "datetime")]
    public DateTime? ActFinishTimeUtc { get; set; }

    [Column("act_finish_time_local", TypeName = "datetime")]
    public DateTime? ActFinishTimeLocal { get; set; }

    [Column("step_data")]
    [StringLength(254)]
    public string? StepData { get; set; }

    [Column("step_data_time_utc", TypeName = "datetime")]
    public DateTime? StepDataTimeUtc { get; set; }

    [Column("step_data_time_local", TypeName = "datetime")]
    public DateTime? StepDataTimeLocal { get; set; }

    [Column("start_user_id")]
    [StringLength(40)]
    public string? StartUserId { get; set; }

    [Column("finish_user_id")]
    [StringLength(40)]
    public string? FinishUserId { get; set; }

    [Column("data_user_id")]
    [StringLength(40)]
    public string? DataUserId { get; set; }

    [Column("form_done")]
    public bool FormDone { get; set; }

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

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }
}
