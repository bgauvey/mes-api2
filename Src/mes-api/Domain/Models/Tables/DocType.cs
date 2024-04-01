using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("doc_type")]
public partial class DocType
{
    [Key]
    [Column("doc_type")]
    [StringLength(20)]
    public string DocType1 { get; set; } = null!;

    [Column("descrip")]
    [StringLength(40)]
    public string Descrip { get; set; } = null!;

    [Column("viewer")]
    public int? Viewer { get; set; }

    [Column("editor")]
    public int? Editor { get; set; }

    [Column("edit_level")]
    public int EditLevel { get; set; }

    [Column("download")]
    public int Download { get; set; }

    [Column("down_level")]
    public int DownLevel { get; set; }

    [Column("view_level")]
    public int ViewLevel { get; set; }

    [Column("print_level")]
    public int PrintLevel { get; set; }

    [Column("url")]
    public bool Url { get; set; }

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
