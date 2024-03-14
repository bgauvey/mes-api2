using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("LangId", "StringId")]
[Table("language")]
public partial class Language
{
    [Key]
    [Column("lang_id")]
    public int LangId { get; set; }

    [Key]
    [Column("string_id")]
    public int StringId { get; set; }

    [Column("grp_id")]
    public int GrpId { get; set; }

    [Column("string")]
    [StringLength(1700)]
    public string? String { get; set; }

    [Column("context", TypeName = "ntext")]
    public string? Context { get; set; }

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
