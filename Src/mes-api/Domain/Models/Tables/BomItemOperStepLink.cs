using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ParentItemId", "VerId", "BomPos", "ProcessId", "OperId", "StepNo")]
[Table("bom_item_oper_step_link")]
public partial class BomItemOperStepLink
{
    [Key]
    [Column("parent_item_id")]
    [StringLength(40)]
    public string ParentItemId { get; set; } = null!;

    [Key]
    [Column("ver_id")]
    [StringLength(40)]
    public string VerId { get; set; } = null!;

    [Key]
    [Column("bom_pos")]
    public int BomPos { get; set; }

    [Key]
    [Column("process_id")]
    [StringLength(40)]
    public string ProcessId { get; set; } = null!;

    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Key]
    [Column("step_no")]
    public int StepNo { get; set; }

    [Column("qty_per_parent_item")]
    public double QtyPerParentItem { get; set; }

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

    [ForeignKey("ParentItemId, VerId, BomPos, ProcessId, OperId")]
    [InverseProperty("BomItemOperStepLinks")]
    public virtual BomItemOperLink BomItemOperLink { get; set; } = null!;

    [ForeignKey("ProcessId, OperId, StepNo")]
    [InverseProperty("BomItemOperStepLinks")]
    public virtual OperStep OperStep { get; set; } = null!;
}
