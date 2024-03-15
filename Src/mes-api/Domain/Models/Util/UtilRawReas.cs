using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Util;

[PrimaryKey("EntId", "RawReasCd")]
[Table("util_raw_reas")]
public partial class UtilRawReas
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("raw_reas_cd")]
    [StringLength(40)]
    public string RawReasCd { get; set; } = null!;

    [Column("def_reas_cd")]
    public int DefReasCd { get; set; }

    [Column("prompt")]
    public bool Prompt { get; set; }

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
