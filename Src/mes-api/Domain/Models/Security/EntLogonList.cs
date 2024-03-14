using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Security;

[PrimaryKey("UserId", "ListId", "EntId")]
[Table("ent_logon_list")]
public partial class EntLogonList
{
    [Key]
    [Column("user_id")]
    [StringLength(40)]
    public string UserId { get; set; } = null!;

    [Key]
    [Column("list_id")]
    [StringLength(40)]
    public string ListId { get; set; } = null!;

    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("cur_lab_cd")]
    [StringLength(40)]
    public string? CurLabCd { get; set; }

    [Column("pct_lab_to_apply")]
    public double? PctLabToApply { get; set; }

    [Column("cur_lab_dept_id")]
    [StringLength(40)]
    public string? CurLabDeptId { get; set; }

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
