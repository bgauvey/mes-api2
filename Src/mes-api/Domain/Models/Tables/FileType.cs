using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("file_type")]
public partial class FileType
{
    [Key]
    [Column("file_ext")]
    [StringLength(20)]
    public string FileExt { get; set; } = null!;

    [Column("doc_type")]
    [StringLength(20)]
    public string DocType { get; set; } = null!;

    [Column("file_desc")]
    [StringLength(40)]
    public string? FileDesc { get; set; }

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
