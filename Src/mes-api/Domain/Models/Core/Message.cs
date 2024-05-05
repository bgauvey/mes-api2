using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[PrimaryKey("Sender", "Sent", "Recipient")]
[Table("message")]
public partial class Message
{
    [Key]
    [Column("sender")]
    [StringLength(80)]
    public string Sender { get; set; } = null!;

    [Column("subject")]
    [StringLength(80)]
    public string? Subject { get; set; }

    [Key]
    [Column("sent", TypeName = "datetime")]
    public DateTime Sent { get; set; }

    [Key]
    [Column("recipient")]
    [StringLength(40)]
    public string Recipient { get; set; } = null!;

    [Column("rcvd", TypeName = "datetime")]
    public DateTime? Rcvd { get; set; }

    [Column("message", TypeName = "ntext")]
    public string? Message1 { get; set; }

    [Column("ver_recpt")]
    public bool VerRecpt { get; set; }

    [Column("cc")]
    public bool Cc { get; set; }

    [Column("category")]
    public int Category { get; set; }

    [Column("priority")]
    public int Priority { get; set; }

    [Column("save_till", TypeName = "datetime")]
    public DateTime? SaveTill { get; set; }

    [Column("read_at", TypeName = "datetime")]
    public DateTime? ReadAt { get; set; }

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
