using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("uom_conv")]
[Index("FromUomId", "ToUomId", "ItemId", Name = "IX_uom_conv", IsUnique = true)]
public partial class UomConv
{
    [Column("from_uom_id")]
    public int FromUomId { get; set; }

    [Column("to_uom_id")]
    public int ToUomId { get; set; }

    [Column("item_id")]
    [StringLength(40)]
    public string? ItemId { get; set; }

    [Column("factor")]
    public double Factor { get; set; }

    [Column("offset")]
    public double Offset { get; set; }

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
