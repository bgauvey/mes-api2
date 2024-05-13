using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Prod;

[Table("item_class")]
public partial class ItemClass
{
    [Key]
    [Column("item_class_id")]
    [StringLength(40)]
    public string ItemClassId { get; set; } = null!;

    [Column("item_class_desc")]
    [StringLength(80)]
    public string ItemClassDesc { get; set; } = null!;

    [Column("produced")]
    public bool Produced { get; set; }

    [Column("consumed")]
    public bool Consumed { get; set; }

    [Column("obsolete")]
    public bool Obsolete { get; set; }

    [Column("purchased")]
    public bool Purchased { get; set; }

    [Column("sold")]
    public bool Sold { get; set; }

    [Column("lot_no_format")]
    [StringLength(40)]
    public string? LotNoFormat { get; set; }

    [Column("last_lot_no")]
    [StringLength(40)]
    public string? LastLotNo { get; set; }

    [Column("sublot_no_format")]
    [StringLength(40)]
    public string? SublotNoFormat { get; set; }

    [Column("last_sublot_no")]
    [StringLength(40)]
    public string? LastSublotNo { get; set; }

    [Column("serial_no_lvl")]
    public int SerialNoLvl { get; set; }

    [Column("inv_unique_by_job")]
    public bool InvUniqueByJob { get; set; }

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
