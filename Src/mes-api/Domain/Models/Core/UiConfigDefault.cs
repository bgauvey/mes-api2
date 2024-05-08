using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[PrimaryKey("Screen", "Sectn", "Parameter")]
[Table("ui_config_default")]
public partial class UiConfigDefault
{
    [Key]
    [Column("screen")]
    [StringLength(40)]
    public string Screen { get; set; } = null!;

    [Key]
    [Column("sectn")]
    [StringLength(40)]
    public string Sectn { get; set; } = null!;

    [Key]
    [Column("parameter")]
    [StringLength(80)]
    public string Parameter { get; set; } = null!;

    [Column("valu", TypeName = "ntext")]
    public string Valu { get; set; } = null!;

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
