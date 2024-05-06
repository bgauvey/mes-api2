using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Core;

[Table("pred_msg")]
public partial class PredMsg
{
    [Key]
    [Column("id")]
    [StringLength(20)]
    public string Id { get; set; } = null!;

    [Column("recipients")]
    [StringLength(254)]
    public string Recipients { get; set; } = null!;

    [Column("subject")]
    [StringLength(80)]
    public string? Subject { get; set; }

    [Column("message", TypeName = "ntext")]
    public string? Message { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }
}
