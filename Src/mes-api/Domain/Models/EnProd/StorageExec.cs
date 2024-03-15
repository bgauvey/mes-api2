using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.EnProd;

[Table("storage_exec")]
public partial class StorageExec
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("type")]
    [StringLength(80)]
    public string? Type { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("max_capacity")]
    public double? MaxCapacity { get; set; }

    [Column("uom_id")]
    public int? UomId { get; set; }

    [Column("tare")]
    public double? Tare { get; set; }

    [Column("tare_uom_id")]
    public int? TareUomId { get; set; }

    [Column("auto_del_zero_inv")]
    public bool AutoDelZeroInv { get; set; }

    [Column("allow_neg_qty")]
    public bool AllowNegQty { get; set; }

    [Column("scannable_id")]
    [StringLength(40)]
    public string? ScannableId { get; set; }

    [Column("allow_multiple_items")]
    public bool AllowMultipleItems { get; set; }

    [Column("allow_multiple_lots")]
    public bool AllowMultipleLots { get; set; }

    [Column("movable")]
    public bool Movable { get; set; }

    [Column("storage_ent_id")]
    public int? StorageEntId { get; set; }

    [Column("allow_dirty_state")]
    public bool AllowDirtyState { get; set; }

    [Column("log_state_transitions")]
    public bool LogStateTransitions { get; set; }

    [Column("indistinguishable_lots")]
    public bool IndistinguishableLots { get; set; }

    [Column("unlisted")]
    public bool Unlisted { get; set; }

    [Column("spare_int1")]
    public int? SpareInt1 { get; set; }

    [Column("spare_int2")]
    public int? SpareInt2 { get; set; }

    [Column("spare_int3")]
    public int? SpareInt3 { get; set; }

    [Column("spare_int4")]
    public int? SpareInt4 { get; set; }

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
