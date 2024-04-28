using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Core;

[Table("system_attr")]
public partial class SystemAttr
{
    [Key]
    [Column("attr_id")]
    public int AttrId { get; set; }

    [Column("attr_desc")]
    [StringLength(80)]
    public string AttrDesc { get; set; } = null!;

    [Column("attr_value")]
    [StringLength(80)]
    public string AttrValue { get; set; } = null!;

    [Column("grp_id")]
    public int GrpId { get; set; }

    [Column("attr_seq")]
    public int AttrSeq { get; set; }

    [Column("edit_type")]
    public int EditType { get; set; }

    [Column("attr_constraints")]
    [StringLength(254)]
    public string? AttrConstraints { get; set; }

    [Column("reqd_lic")]
    [StringLength(1700)]
    public string? ReqdLic { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }
}
