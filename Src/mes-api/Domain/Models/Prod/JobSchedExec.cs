using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Prod;

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

}
