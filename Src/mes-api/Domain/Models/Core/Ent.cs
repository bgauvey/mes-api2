using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Core;

[Table("ent")]
public partial class Ent
{
    [Column("ent_name")]
    [StringLength(80)]
    public string EntName { get; set; } = null!;

    [Column("description")]
    [StringLength(80)]
    public string? Description { get; set; }

    [Column("parent_ent_id")]
    public int? ParentEntId { get; set; }

    [Column("site")]
    public int? Site { get; set; }

    [Column("hourly_cost")]
    public double? HourlyCost { get; set; }

    [Column("can_sched_jobs")]
    public bool CanSchedJobs { get; set; }

    [Column("can_run_jobs")]
    public bool CanRunJobs { get; set; }

    [Column("can_capture_util")]
    public bool CanCaptureUtil { get; set; }

    [Column("can_capture_labor")]
    public bool CanCaptureLabor { get; set; }

    [Column("can_do_dnc")]
    public bool CanDoDnc { get; set; }

    [Column("can_track_oee")]
    public bool CanTrackOee { get; set; }

    [Column("can_sched_shifts")]
    public bool CanSchedShifts { get; set; }

    [Column("can_store")]
    public bool CanStore { get; set; }

    [Column("can_log_data")]
    public bool CanLogData { get; set; }

    [Column("can_ship")]
    public bool CanShip { get; set; }

    [Column("can_receive")]
    public bool CanReceive { get; set; }

    [Column("can_copy_folders")]
    public bool CanCopyFolders { get; set; }

    [Column("cur_shift_id")]
    public int? CurShiftId { get; set; }

    [Column("cur_shift_start_time_utc", TypeName = "datetime")]
    public DateTime? CurShiftStartTimeUtc { get; set; }

    [Column("cur_shift_start_time_local", TypeName = "datetime")]
    public DateTime? CurShiftStartTimeLocal { get; set; }

    [Column("last_domain_change", TypeName = "datetime")]
    public DateTime? LastDomainChange { get; set; }

    [Column("tree_icon")]
    [StringLength(80)]
    public string? TreeIcon { get; set; }

    [Column("flow_diag_img")]
    [StringLength(80)]
    public string? FlowDiagImg { get; set; }

    [Column("identical_job_execs")]
    public int IdenticalJobExecs { get; set; }

    [Column("show_in_dsp_tree")]
    public bool ShowInDspTree { get; set; }

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

    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }
}
