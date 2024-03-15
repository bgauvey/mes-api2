using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Util;

[PrimaryKey("ReasCd", "ActionId")]
[Table("util_reas_corr_action_link")]
public partial class UtilReasCorrActionLink
{
    [Key]
    [Column("reas_cd")]
    public int ReasCd { get; set; }

    [Key]
    [Column("action_id")]
    public int ActionId { get; set; }

    [Column("action_seq")]
    public int? ActionSeq { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("row_id")]
    public int RowId { get; set; }
}
