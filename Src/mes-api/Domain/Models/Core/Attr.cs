using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Core;

[Table("attr")]
public partial class Attr
{
    [Column("predefined")]
    public bool Predefined { get; set; }

    [Column("data_type")]
    public int DataType { get; set; }

    [Column("attr_desc")]
    [StringLength(80)]
    public string AttrDesc { get; set; } = null!;

    [Column("attr_grp")]
    public int AttrGrp { get; set; }

    [Column("filtr")]
    [StringLength(254)]
    public string? Filtr { get; set; }

    [Column("entry_type")]
    public int EntryType { get; set; }

    [Column("visible_in_queue")]
    public bool VisibleInQueue { get; set; }

    [Column("visible_in_inv")]
    public bool VisibleInInv { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("attr_id")]
    public int AttrId { get; set; }
}
