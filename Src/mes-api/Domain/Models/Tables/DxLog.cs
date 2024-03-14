using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("dx_log")]
public partial class DxLog
{
    [Column("sched_id")]
    [StringLength(40)]
    public string SchedId { get; set; } = null!;

    [Column("status")]
    public int Status { get; set; }

    [Column("triggered_by")]
    [StringLength(80)]
    public string TriggeredBy { get; set; } = null!;

    [Column("rows_success")]
    public int? RowsSuccess { get; set; }

    [Column("rows_error")]
    public int? RowsError { get; set; }

    [Column("comments")]
    [StringLength(254)]
    public string? Comments { get; set; }

    [Column("error_desc")]
    [StringLength(1700)]
    public string? ErrorDesc { get; set; }

    [Column("logged_at", TypeName = "datetime")]
    public DateTime LoggedAt { get; set; }

    [Key]
    [Column("log_id")]
    public int LogId { get; set; }

    [ForeignKey("SchedId")]
    [InverseProperty("DxLogs")]
    public virtual DxSched Sched { get; set; } = null!;
}
