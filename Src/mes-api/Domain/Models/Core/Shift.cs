using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Core;

[Table("shift")]
public partial class Shift
{
    [Key]
    [Column("shift_id")]
    public int ShiftId { get; set; }

    [Column("shift_desc")]
    [StringLength(80)]
    public string? ShiftDesc { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }
}
