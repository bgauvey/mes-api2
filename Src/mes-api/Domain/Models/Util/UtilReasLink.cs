using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Util;

[PrimaryKey("EntId", "RawReasCd", "ReasCd")]
[Table("util_reas_link")]
public partial class UtilReasLink
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("raw_reas_cd")]
    [StringLength(40)]
    public string RawReasCd { get; set; } = null!;

    [Key]
    [Column("reas_cd")]
    public int ReasCd { get; set; }

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
