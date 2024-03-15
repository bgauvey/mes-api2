using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ParentItemId", "VerId", "BomPos", "AltNo")]
[Table("bom_item_subst")]
[Index("ParentItemId", "VerId", "BomPos", "ItemId", Name = "IX_bom_item_subst", IsUnique = true)]
public partial class BomItemSubst
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
    [Column("alt_no")]
    public int AltNo { get; set; }

    [Column("pref")]
    public int Pref { get; set; }

    [Column("subst_level")]
    public int SubstLevel { get; set; }

    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Column("reqd_grade_cd")]
    public int? ReqdGradeCd { get; set; }

    [Column("instruction")]
    [StringLength(1700)]
    public string? Instruction { get; set; }

    [Column("qty_per_parent_item")]
    public double QtyPerParentItem { get; set; }

    [Column("max_qty_per_parent_item")]
    public double? MaxQtyPerParentItem { get; set; }

    [Column("min_qty_per_parent_item")]
    public double? MinQtyPerParentItem { get; set; }

    [Column("update_inv")]
    public bool UpdateInv { get; set; }

    [Column("backflush")]
    public bool Backflush { get; set; }

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

    [Column("scaling_factor")]
    public double? ScalingFactor { get; set; }

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

    [Column("est_time")]
    public double? EstTime { get; set; }

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
    public string LastEditBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("row_id")]
    public int RowId { get; set; }

}
