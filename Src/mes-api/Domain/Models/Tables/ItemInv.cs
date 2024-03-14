using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("item_inv")]
public partial class ItemInv
{
    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Column("lot_no")]
    [StringLength(40)]
    public string? LotNo { get; set; }

    [Column("sublot_no")]
    [StringLength(40)]
    public string? SublotNo { get; set; }

    [Column("grade_cd")]
    public int? GradeCd { get; set; }

    [Column("status_cd")]
    public int? StatusCd { get; set; }

    [Column("qty_left")]
    public double QtyLeft { get; set; }

    [Column("qty_left_erp")]
    public double QtyLeftErp { get; set; }

    [Column("uom_id")]
    public int? UomId { get; set; }

    [Column("date_in_utc", TypeName = "datetime")]
    public DateTime DateInUtc { get; set; }

    [Column("date_in_local", TypeName = "datetime")]
    public DateTime DateInLocal { get; set; }

    [Column("date_out_utc", TypeName = "datetime")]
    public DateTime? DateOutUtc { get; set; }

    [Column("date_out_local", TypeName = "datetime")]
    public DateTime? DateOutLocal { get; set; }

    [Column("expiry_date", TypeName = "datetime")]
    public DateTime? ExpiryDate { get; set; }

    [Column("wo_id")]
    [StringLength(40)]
    public string? WoId { get; set; }

    [Column("oper_id")]
    [StringLength(40)]
    public string? OperId { get; set; }

    [Column("seq_no")]
    public int? SeqNo { get; set; }

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

    [Column("spare5")]
    [StringLength(80)]
    public string? Spare5 { get; set; }

    [Column("spare6")]
    [StringLength(80)]
    public string? Spare6 { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }

    [ForeignKey("EntId")]
    [InverseProperty("ItemInvs")]
    public virtual StorageExec Ent { get; set; } = null!;

    [ForeignKey("ItemId, LotNo")]
    [InverseProperty("ItemInvs")]
    public virtual Lot? Lot { get; set; }

    [ForeignKey("ItemId, LotNo, SublotNo")]
    [InverseProperty("ItemInvs")]
    public virtual Sublot? Sublot { get; set; }
}
