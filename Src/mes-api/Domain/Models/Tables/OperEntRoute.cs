using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ProcessId", "OperId", "EntId", "InputOperId", "InputEntId")]
[Table("oper_ent_route")]
public partial class OperEntRoute
{
    [Key]
    [Column("process_id")]
    [StringLength(40)]
    public string ProcessId { get; set; } = null!;

    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("input_oper_id")]
    [StringLength(40)]
    public string InputOperId { get; set; } = null!;

    [Key]
    [Column("input_ent_id")]
    public int InputEntId { get; set; }

    [Column("input_percent")]
    public double InputPercent { get; set; }

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

    [Column("row_id")]
    public int RowId { get; set; }

    [ForeignKey("ProcessId, InputOperId, InputEntId")]
    [InverseProperty("OperEntRouteOperEntLinks")]
    public virtual OperEntLink OperEntLink { get; set; } = null!;

    [ForeignKey("ProcessId, OperId, EntId")]
    [InverseProperty("OperEntRouteOperEntLinkNavigations")]
    public virtual OperEntLink OperEntLinkNavigation { get; set; } = null!;
}
