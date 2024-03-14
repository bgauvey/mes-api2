using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("job_util_log_link")]
[Index("LogId", "WoId", "OperId", "SeqNo", "JobStartUtc", Name = "IX_job_util_log_link_job", IsUnique = true)]
[Index("LogId", "JobPos", "JobStartUtc", Name = "IX_job_util_log_link_job_start", IsUnique = true)]
public partial class JobUtilLogLink
{
    [Column("log_id")]
    public int LogId { get; set; }

    [Column("job_pos")]
    public int JobPos { get; set; }

    [Column("wo_id")]
    [StringLength(40)]
    public string WoId { get; set; } = null!;

    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Column("seq_no")]
    public int SeqNo { get; set; }

    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Column("job_start_utc", TypeName = "datetime")]
    public DateTime JobStartUtc { get; set; }

    [Column("job_start_local", TypeName = "datetime")]
    public DateTime JobStartLocal { get; set; }

    [Column("duration")]
    public int Duration { get; set; }

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
    [Column("row_id")]
    public int RowId { get; set; }
}
