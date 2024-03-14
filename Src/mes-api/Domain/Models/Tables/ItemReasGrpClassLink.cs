using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ReasGrpId", "ItemClassId")]
[Table("item_reas_grp_class_link")]
public partial class ItemReasGrpClassLink
{
    [Key]
    [Column("reas_grp_id")]
    public int ReasGrpId { get; set; }

    [Key]
    [Column("item_class_id")]
    [StringLength(40)]
    public string ItemClassId { get; set; } = null!;

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
