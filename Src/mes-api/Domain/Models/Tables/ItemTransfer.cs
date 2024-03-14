using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("item_transfer")]
public partial class ItemTransfer
{
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
    public int? ToEntId { get; set; }

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

    [Column("qty_txd")]
    public double QtyTxd { get; set; }

    [Column("uom_id")]
    public int? UomId { get; set; }

    [Column("expiry_date", TypeName = "datetime")]
    public DateTime? ExpiryDate { get; set; }

    [Column("to_spare1")]
    [StringLength(80)]
    public string? ToSpare1 { get; set; }

    [Column("to_spare2")]
    [StringLength(80)]
    public string? ToSpare2 { get; set; }

    [Column("to_spare3")]
    [StringLength(80)]
    public string? ToSpare3 { get; set; }

    [Column("to_spare4")]
    [StringLength(80)]
    public string? ToSpare4 { get; set; }

    [Column("to_spare5")]
    [StringLength(80)]
    public string? ToSpare5 { get; set; }

    [Column("to_spare6")]
    [StringLength(80)]
    public string? ToSpare6 { get; set; }

    [Column("from_wo_id")]
    [StringLength(40)]
    public string? FromWoId { get; set; }

    [Column("from_oper_id")]
    [StringLength(40)]
    public string? FromOperId { get; set; }

    [Column("from_seq_no")]
    public int? FromSeqNo { get; set; }

    [Column("from_ent_id")]
    public int? FromEntId { get; set; }

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

    [Column("from_qty_txd")]
    public double? FromQtyTxd { get; set; }

    [Column("from_uom_id")]
    public int? FromUomId { get; set; }

    [Column("from_expiry_date", TypeName = "datetime")]
    public DateTime? FromExpiryDate { get; set; }

    [Column("from_spare1")]
    [StringLength(80)]
    public string? FromSpare1 { get; set; }

    [Column("from_spare2")]
    [StringLength(80)]
    public string? FromSpare2 { get; set; }

    [Column("from_spare3")]
    [StringLength(80)]
    public string? FromSpare3 { get; set; }

    [Column("from_spare4")]
    [StringLength(80)]
    public string? FromSpare4 { get; set; }

    [Column("from_spare5")]
    [StringLength(80)]
    public string? FromSpare5 { get; set; }

    [Column("from_spare6")]
    [StringLength(80)]
    public string? FromSpare6 { get; set; }

    [Column("qty_txd_erp")]
    public double? QtyTxdErp { get; set; }

    [Column("goods_received")]
    public bool GoodsReceived { get; set; }

    [Column("goods_shipped")]
    public bool GoodsShipped { get; set; }

    [Column("transfer_list_row_id")]
    public int? TransferListRowId { get; set; }

    [Column("comments")]
    [StringLength(254)]
    public string? Comments { get; set; }

    [Column("transfer_by")]
    [StringLength(40)]
    public string? TransferBy { get; set; }

    [Column("transfer_time_utc", TypeName = "datetime")]
    public DateTime TransferTimeUtc { get; set; }

    [Column("transfer_time_local", TypeName = "datetime")]
    public DateTime TransferTimeLocal { get; set; }

    [Column("mod_id")]
    public byte[] ModId { get; set; } = null!;

    [Key]
    [Column("trans_id")]
    public int TransId { get; set; }
}
