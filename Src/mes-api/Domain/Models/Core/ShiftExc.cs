using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[PrimaryKey("EntId", "StartTime")]
[Table("shift_exc")]
public partial class ShiftExc
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("start_time", TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column("end_time", TypeName = "datetime")]
    public DateTime EndTime { get; set; }

    [Column("shift_id")]
    public int? ShiftId { get; set; }

    [Column("additive")]
    public bool Additive { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("mod_id")]
    public byte[] ModId { get; set; } = null!;

    [Column("row_id")]
    public int RowId { get; set; }
}
