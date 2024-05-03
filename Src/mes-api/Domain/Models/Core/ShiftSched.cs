using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[PrimaryKey("EntId", "StartDay", "ShiftId")]
[Table("shift_sched")]
public partial class ShiftSched
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("start_day")]
    public int StartDay { get; set; }

    [Key]
    [Column("shift_id")]
    public int ShiftId { get; set; }

    [Column("start_time", TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column("end_time", TypeName = "datetime")]
    public DateTime EndTime { get; set; }

    [Column("break1_start", TypeName = "datetime")]
    public DateTime? Break1Start { get; set; }

    [Column("break1_end", TypeName = "datetime")]
    public DateTime? Break1End { get; set; }

    [Column("break2_start", TypeName = "datetime")]
    public DateTime? Break2Start { get; set; }

    [Column("break2_end", TypeName = "datetime")]
    public DateTime? Break2End { get; set; }

    [Column("break3_start", TypeName = "datetime")]
    public DateTime? Break3Start { get; set; }

    [Column("break3_end", TypeName = "datetime")]
    public DateTime? Break3End { get; set; }

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
