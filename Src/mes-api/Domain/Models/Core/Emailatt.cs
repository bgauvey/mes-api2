using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[PrimaryKey("Sender", "Sent", "Recipient", "Path")]
[Table("emailatt")]
public partial class Emailatt
{
    [Key]
    [Column("sender")]
    [StringLength(80)]
    public string Sender { get; set; } = null!;

    [Key]
    [Column("sent", TypeName = "datetime")]
    public DateTime Sent { get; set; }

    [Key]
    [Column("recipient")]
    [StringLength(40)]
    public string Recipient { get; set; } = null!;

    [Key]
    [Column("path")]
    [StringLength(254)]
    public string Path { get; set; } = null!;

    [Column("file_name")]
    [StringLength(254)]
    public string FileName { get; set; } = null!;

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
