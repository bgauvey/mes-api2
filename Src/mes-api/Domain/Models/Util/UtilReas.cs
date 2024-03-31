using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Util;

[Table("util_reas")]
public partial class UtilReas
{
    [Column("reas_desc")]
    [StringLength(80)]
    public string ReasDesc { get; set; } = null!;

    [Column("reas_grp_id")]
    public int ReasGrpId { get; set; }

    [Column("state_cd")]
    public int StateCd { get; set; }

    [Column("runtime")]
    public bool Runtime { get; set; }

    [Column("downtime")]
    public bool Downtime { get; set; }

    [Column("setuptime")]
    public bool Setuptime { get; set; }

    [Column("teardowntime")]
    public bool Teardowntime { get; set; }

    [Column("fixedtime")]
    public bool Fixedtime { get; set; }

    [Column("vartime")]
    public bool Vartime { get; set; }

    [Column("def_lab_cd")]
    [StringLength(40)]
    public string? DefLabCd { get; set; }

    [Column("display_seq")]
    public int DisplaySeq { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("reas_cd")]
    public int ReasCd { get; set; }
}
