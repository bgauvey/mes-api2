using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Security;

[Table("priv")]
public partial class Priv
{
    [Key]
    [Column("priv_id")]
    public int PrivId { get; set; }

    [Column("priv_desc")]
    [StringLength(80)]
    public string PrivDesc { get; set; } = null!;

    [Column("priv_grp")]
    [StringLength(80)]
    public string PrivGrp { get; set; } = null!;

    [Column("edit_type")]
    public int EditType { get; set; }

    [Column("priv_constraints")]
    [StringLength(254)]
    public string? PrivConstraints { get; set; }

    [Column("reqd_lic")]
    [StringLength(1700)]
    public string? ReqdLic { get; set; }
}
