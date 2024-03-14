using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ParentItemId", "VerId", "BomPos", "ProcessId", "OperId")]
[Table("bom_item_oper_link")]
public partial class BomItemOperLink
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

    [Column("qty_per_parent_item")]
    public double QtyPerParentItem { get; set; }

    [Column("reqd_start_pct")]
    public double ReqdStartPct { get; set; }

    [Column("def_reas_cd")]
    public int? DefReasCd { get; set; }

    [Column("def_lot_no")]
    [StringLength(40)]
    public string? DefLotNo { get; set; }

    [Column("def_sublot_no")]
    [StringLength(40)]
    public string? DefSublotNo { get; set; }

    [Column("def_storage_ent_id")]
    public int? DefStorageEntId { get; set; }

    [Column("def_reject_ent_id")]
    public int? DefRejectEntId { get; set; }

    [Column("update_inv")]
    public bool UpdateInv { get; set; }

    [Column("backflush")]
    public bool Backflush { get; set; }

    [Column("must_consume_from_inv")]
    public bool MustConsumeFromInv { get; set; }

    [Column("may_choose_alt_inv_loc")]
    public bool MayChooseAltInvLoc { get; set; }

    [Column("may_create_new_lots")]
    public bool MayCreateNewLots { get; set; }

    [Column("must_consume_from_wip")]
    public bool MustConsumeFromWip { get; set; }

    [Column("must_consume_before_prod")]
    public bool MustConsumeBeforeProd { get; set; }

    [Column("constant_qty")]
    public bool ConstantQty { get; set; }

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

    [InverseProperty("BomItemOperLink")]
    public virtual ICollection<BomItemOperStepLink> BomItemOperStepLinks { get; set; } = new List<BomItemOperStepLink>();

    [ForeignKey("DefStorageEntId")]
    [InverseProperty("BomItemOperLinks")]
    public virtual StorageExec? DefStorageEnt { get; set; }

    [ForeignKey("ProcessId, OperId")]
    [InverseProperty("BomItemOperLinks")]
    public virtual Oper Oper { get; set; } = null!;
}
