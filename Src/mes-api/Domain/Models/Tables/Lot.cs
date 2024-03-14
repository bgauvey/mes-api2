﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ItemId", "LotNo")]
[Table("lot")]
public partial class Lot
{
    [Key]
    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Key]
    [Column("lot_no")]
    [StringLength(40)]
    public string LotNo { get; set; } = null!;

    [Column("grade_cd")]
    public int? GradeCd { get; set; }

    [Column("status_cd")]
    public int? StatusCd { get; set; }

    [Column("expiry_date", TypeName = "datetime")]
    public DateTime? ExpiryDate { get; set; }

    [Column("is_serial_no")]
    public bool IsSerialNo { get; set; }

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
    public string LastEditBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("row_id")]
    public int RowId { get; set; }

    [InverseProperty("Lot")]
    public virtual ICollection<AssignedLot> AssignedLots { get; set; } = new List<AssignedLot>();

    [InverseProperty("Lot")]
    public virtual InvLotAttr? InvLotAttr { get; set; }

    [InverseProperty("Lot")]
    public virtual ICollection<ItemInv> ItemInvs { get; set; } = new List<ItemInv>();

    [InverseProperty("Lot")]
    public virtual ICollection<LotAttr> LotAttrs { get; set; } = new List<LotAttr>();

    [InverseProperty("Lot")]
    public virtual ICollection<Sublot> Sublots { get; set; } = new List<Sublot>();
}
