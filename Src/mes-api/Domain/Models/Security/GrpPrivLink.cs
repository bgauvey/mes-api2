using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Security;

[PrimaryKey("GrpId", "PrivId")]
[Table("grp_priv_link")]
public partial class GrpPrivLink
{
    [Key]
    [Column("grp_id")]
    public int GrpId { get; set; }

    [Key]
    [Column("priv_id")]
    public int PrivId { get; set; }

    [Column("priv_value")]
    public int PrivValue { get; set; }

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
