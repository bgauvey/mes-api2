using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Prod;

[Table("item")]
public partial class Item
{
    [Key]
    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Column("item_desc")]
    [StringLength(80)]
    public string ItemDesc { get; set; } = null!;

    [Column("item_class_id")]
    [StringLength(40)]
    public string ItemClassId { get; set; } = null!;

    [Column("uom_id")]
    public int UomId { get; set; }

    [Column("template")]
    public bool Template { get; set; }

    [Column("lifetime")]
    public int? Lifetime { get; set; }

    [Column("unit_cost")]
    public double? UnitCost { get; set; }

    [Column("obsolete")]
    public bool Obsolete { get; set; }

    [Column("purchased")]
    public bool Purchased { get; set; }

    [Column("sold")]
    public bool Sold { get; set; }

    [Column("num_decimals")]
    public int NumDecimals { get; set; }

    [Column("must_complete_steps")]
    public bool MustCompleteSteps { get; set; }

    [Column("must_prod_reqd_qty")]
    public bool MustProdReqdQty { get; set; }

    [Column("min_grade")]
    public int? MinGrade { get; set; }

    [Column("min_state")]
    public int? MinState { get; set; }

    [Column("min_inv_level")]
    public double? MinInvLevel { get; set; }

    [Column("reorder_amt")]
    public double? ReorderAmt { get; set; }

    [Column("auto_reorder")]
    public bool AutoReorder { get; set; }

    [Column("lot_no_format")]
    [StringLength(40)]
    public string? LotNoFormat { get; set; }

    [Column("last_lot_no")]
    [StringLength(40)]
    public string? LastLotNo { get; set; }

    [Column("max_lot_size")]
    public double? MaxLotSize { get; set; }

    [Column("sublot_no_format")]
    [StringLength(40)]
    public string? SublotNoFormat { get; set; }

    [Column("last_sublot_no")]
    [StringLength(40)]
    public string? LastSublotNo { get; set; }

    [Column("serial_no_lvl")]
    public int SerialNoLvl { get; set; }

    [Column("max_sublot_size")]
    public double? MaxSublotSize { get; set; }

    [Column("max_order_size")]
    public double? MaxOrderSize { get; set; }

    [Column("min_trace_inv")]
    public double? MinTraceInv { get; set; }

    [Column("inv_unique_by_job")]
    public bool InvUniqueByJob { get; set; }

    [Column("notes", TypeName = "ntext")]
    public string? Notes { get; set; }

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

    [Column("row_id")]
    public int RowId { get; set; }
}
