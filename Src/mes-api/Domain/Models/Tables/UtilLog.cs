using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("util_log")]
[Index("EventTimeUtc", "EntId", Name = "IX_util_log", IsUnique = true)]
public partial class UtilLog
{
    [Column("event_time_utc", TypeName = "datetime")]
    public DateTime EventTimeUtc { get; set; }

    [Column("event_time_local", TypeName = "datetime")]
    public DateTime EventTimeLocal { get; set; }

    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("shift_id")]
    public int ShiftId { get; set; }

    [Column("shift_start_utc", TypeName = "datetime")]
    public DateTime ShiftStartUtc { get; set; }

    [Column("shift_start_local", TypeName = "datetime")]
    public DateTime ShiftStartLocal { get; set; }

    [Column("state_cd")]
    public int StateCd { get; set; }

    [Column("reas_cd")]
    public int ReasCd { get; set; }

    [Column("reas_pending")]
    public bool ReasPending { get; set; }

    [Column("runtime")]
    public bool Runtime { get; set; }

    [Column("downtime")]
    public bool Downtime { get; set; }

    [Column("setuptime")]
    public bool Setuptime { get; set; }

    [Column("teardowntime")]
    public bool Teardowntime { get; set; }

    [Column("fixedtime")]
    public bool Fixedtime { get; set; }

    [Column("vartime")]
    public bool Vartime { get; set; }

    [Column("duration")]
    public int Duration { get; set; }

    [Column("comments")]
    [StringLength(254)]
    public string? Comments { get; set; }

    [Column("raw_reas_cd")]
    [StringLength(40)]
    public string? RawReasCd { get; set; }

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

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("log_id")]
    public int LogId { get; set; }
}
