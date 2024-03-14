using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("assigned_lot")]
[Index("ItemId", "LotNo", "SublotNo", "WoId", "OperId", "SeqNo", Name = "IX_assigned_lot", IsUnique = true)]
public partial class AssignedLot
{
    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Column("lot_no")]
    [StringLength(40)]
    public string LotNo { get; set; } = null!;

    [Column("sublot_no")]
    [StringLength(40)]
    public string? SublotNo { get; set; }

    [Column("wo_id")]
    [StringLength(40)]
    public string WoId { get; set; } = null!;

    [Column("oper_id")]
    [StringLength(40)]
    public string? OperId { get; set; }

    [Column("seq_no")]
    public int? SeqNo { get; set; }

    [Column("status")]
    public int Status { get; set; }

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

    [Column("created_by")]
    [StringLength(40)]
    public string CreatedBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }

    [ForeignKey("ItemId, LotNo")]
    [InverseProperty("AssignedLots")]
    public virtual Lot Lot { get; set; } = null!;

    [ForeignKey("ItemId, LotNo, SublotNo")]
    [InverseProperty("AssignedLots")]
    public virtual Sublot? Sublot { get; set; }
}
