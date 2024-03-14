using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BOL.API.Domain.Models.Security;

[PrimaryKey("GrpId", "UserId")]
[Table("user_grp_link")]
public class UserGrpLink
{
    [Key]
    [Column("grp_id")]
    public int GrpId { get; set; }

    [Key]
    [Column("user_id")]
    [StringLength(40)]
    public string UserId { get; set; } = null!;

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

