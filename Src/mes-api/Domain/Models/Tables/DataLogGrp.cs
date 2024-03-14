using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("data_log_grp")]
[Index("GrpDesc", Name = "IX_data_log_grp", IsUnique = true)]
public partial class DataLogGrp
{
    [Column("grp_desc")]
    [StringLength(80)]
    public string GrpDesc { get; set; } = null!;

    [Column("max_value")]
    public int MaxValue { get; set; }

    [Column("trigger_type")]
    public int TriggerType { get; set; }

    [Column("trigger_detail")]
    [StringLength(1000)]
    public string? TriggerDetail { get; set; }

    [Column("obsolete")]
    public bool Obsolete { get; set; }

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

    [Column("mod_id")]
    public byte[] ModId { get; set; } = null!;

    [Key]
    [Column("grp_id")]
    public int GrpId { get; set; }
}
