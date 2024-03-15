using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("transfer_list")]
public partial class TransferList
{
    [Column("transfer_type")]
    public int TransferType { get; set; }

    [Column("cust_id")]
    [StringLength(40)]
    public string? CustId { get; set; }

    [Column("order_id")]
    [StringLength(40)]
    public string? OrderId { get; set; }

    [Column("line_no")]
    public int? LineNo { get; set; }

    [Column("date_of_shipment_utc", TypeName = "datetime")]
    public DateTime? DateOfShipmentUtc { get; set; }

    [Column("date_of_shipment_local", TypeName = "datetime")]
    public DateTime? DateOfShipmentLocal { get; set; }

    [Column("wo_id")]
    [StringLength(40)]
    public string? WoId { get; set; }

    [Column("oper_id")]
    [StringLength(40)]
    public string? OperId { get; set; }

    [Column("seq_no")]
    public int? SeqNo { get; set; }

    [Column("bom_pos")]
    public int? BomPos { get; set; }

    [Column("to_ent_id")]
    public int ToEntId { get; set; }

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

    [Column("qty_to_store")]
    public double QtyToStore { get; set; }

    [Column("uom_id_store")]
    public int? UomIdStore { get; set; }

    [Column("expiry_date", TypeName = "datetime")]
    public DateTime? ExpiryDate { get; set; }

    [Column("from_ent_id")]
    public int FromEntId { get; set; }

    [Column("from_item_id")]
    [StringLength(40)]
    public string? FromItemId { get; set; }

    [Column("from_lot_no")]
    [StringLength(40)]
    public string? FromLotNo { get; set; }

    [Column("from_sublot_no")]
    [StringLength(40)]
    public string? FromSublotNo { get; set; }

    [Column("from_grade_cd")]
    public int? FromGradeCd { get; set; }

    [Column("from_status_cd")]
    public int? FromStatusCd { get; set; }

    [Column("qty_to_pick")]
    public double? QtyToPick { get; set; }

    [Column("uom_id_pick")]
    public int? UomIdPick { get; set; }

    [Column("from_expiry_date", TypeName = "datetime")]
    public DateTime? FromExpiryDate { get; set; }

    [Column("trans_id")]
    public int? TransId { get; set; }

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
    public string LastEditBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }
}
