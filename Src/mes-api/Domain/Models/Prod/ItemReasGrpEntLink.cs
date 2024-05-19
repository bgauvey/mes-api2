using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Prod;

[PrimaryKey("ReasGrpId", "EntId")]
[Table("item_reas_grp_ent_link")]
public partial class ItemReasGrpEntLink
{
    [Key]
    [Column("reas_grp_id")]
    public int ReasGrpId { get; set; }

    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

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
