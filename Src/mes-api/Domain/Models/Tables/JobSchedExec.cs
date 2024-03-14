using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("job_sched_exec")]
public partial class JobSchedExec
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("oper_type")]
    [StringLength(80)]
    public string? OperType { get; set; }

    [Column("queue_time")]
    public double? QueueTime { get; set; }

    [Column("sort_order")]
    [StringLength(1700)]
    public string? SortOrder { get; set; }

    [Column("filtr")]
    [StringLength(1700)]
    public string? Filtr { get; set; }

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

    [InverseProperty("Ent")]
    public virtual ICollection<OperEntLink> OperEntLinks { get; set; } = new List<OperEntLink>();

    [InverseProperty("Ent")]
    public virtual ICollection<OperStepEntExc> OperStepEntExcs { get; set; } = new List<OperStepEntExc>();

    [InverseProperty("Ent")]
    public virtual ICollection<StdOperEntLink> StdOperEntLinks { get; set; } = new List<StdOperEntLink>();

    [InverseProperty("Ent")]
    public virtual ICollection<StdOperStepEntExc> StdOperStepEntExcs { get; set; } = new List<StdOperStepEntExc>();
}
