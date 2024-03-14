using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Security;

[PrimaryKey("SessionId", "EntId")]
[Table("ent_logon")]
public partial class EntLogon
{
    [Key]
    [Column("session_id")]
    public int SessionId { get; set; }

    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("user_id")]
    [StringLength(40)]
    public string UserId { get; set; } = null!;

    [Column("start_time", TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column("cur_lab_cd")]
    [StringLength(40)]
    public string? CurLabCd { get; set; }

    [Column("pct_lab_to_apply")]
    public double? PctLabToApply { get; set; }

    [Column("cur_lab_dept_id")]
    [StringLength(40)]
    public string? CurLabDeptId { get; set; }

    [Column("cur_lab_usage_log_id")]
    public int? CurLabUsageLogId { get; set; }

    [Column("row_id")]
    public int RowId { get; set; }
}
