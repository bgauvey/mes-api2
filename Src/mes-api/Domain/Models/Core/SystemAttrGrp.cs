using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Core;

[Table("system_attr_grp")]
public partial class SystemAttrGrp
{
    [Key]
    [Column("grp_id")]
    public int GrpId { get; set; }

    [Column("grp_desc")]
    [StringLength(80)]
    public string GrpDesc { get; set; } = null!;

    [Column("grp_seq")]
    public int GrpSeq { get; set; }
}
