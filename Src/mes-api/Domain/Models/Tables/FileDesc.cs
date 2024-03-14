using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("DocType", "FileDesc1")]
[Table("file_desc")]
public partial class FileDesc
{
    [Key]
    [Column("doc_type")]
    [StringLength(20)]
    public string DocType { get; set; } = null!;

    [Key]
    [Column("file_desc")]
    [StringLength(40)]
    public string FileDesc1 { get; set; } = null!;

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

    [ForeignKey("DocType")]
    [InverseProperty("FileDescs")]
    public virtual DocType DocTypeNavigation { get; set; } = null!;
}
