﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Prod;

[Table("item_reas_grp")]
public partial class ItemReasGrp
{
    [Column("reas_grp_desc")]
    [StringLength(80)]
    public string ReasGrpDesc { get; set; } = null!;

    [Column("reas_grp_type")]
    public int ReasGrpType { get; set; }

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
    [Column("reas_grp_id")]
    public int ReasGrpId { get; set; }
}
