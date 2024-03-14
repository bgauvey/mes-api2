using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("lot_attr_default")]
public partial class LotAttrDefault
{
    [Column("wo_id")]
    [StringLength(40)]
    public string? WoId { get; set; }

    [Column("oper_id")]
    [StringLength(40)]
    public string? OperId { get; set; }

    [Column("seq_no")]
    public int? SeqNo { get; set; }

    [Column("item_id")]
    [StringLength(40)]
    public string? ItemId { get; set; }

    [Column("attr_id")]
    public int AttrId { get; set; }

    [Column("attr_value")]
    [StringLength(1700)]
    public string? AttrValue { get; set; }

    [Column("notes", TypeName = "ntext")]
    public string? Notes { get; set; }

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
