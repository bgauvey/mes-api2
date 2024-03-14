using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[PrimaryKey("EntId", "AttrId")]
[Table("ent_attr")]
public partial class EntAttr
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("attr_id")]
    public int AttrId { get; set; }

    [Column("attr_value")]
    [StringLength(1700)]
    public string? AttrValue { get; set; }

    [Column("notes", TypeName = "ntext")]
    public string? Notes { get; set; }

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
