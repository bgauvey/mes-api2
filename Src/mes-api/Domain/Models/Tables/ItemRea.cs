using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("item_reas")]
[Index("ReasDesc", "ReasGrpId", Name = "UK_Item_Reas_Desc_Grp", IsUnique = true)]
public partial class ItemRea
{
    [Key]
    [Column("reas_cd")]
    public int ReasCd { get; set; }

    [Column("reas_desc")]
    [StringLength(80)]
    public string ReasDesc { get; set; } = null!;

    [Column("reas_grp_id")]
    public int ReasGrpId { get; set; }

    [Column("item_grade_cd")]
    public int ItemGradeCd { get; set; }

    [Column("item_status_cd")]
    public int ItemStatusCd { get; set; }

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
}
