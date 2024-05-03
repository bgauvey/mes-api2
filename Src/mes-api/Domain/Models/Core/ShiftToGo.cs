using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[PrimaryKey("EntId", "StartTime")]
[Table("shift_to_go")]
public partial class ShiftToGo
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
    public int ShiftId { get; set; }

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
}
