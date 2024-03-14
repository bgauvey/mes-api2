using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ParentItemId", "VerId")]
[Table("bom_ver")]
public partial class BomVer
{
    [Key]
    [Column("parent_item_id")]
    [StringLength(40)]
    public string ParentItemId { get; set; } = null!;

    [Key]
    [Column("ver_id")]
    [StringLength(40)]
    public string VerId { get; set; } = null!;

    [Column("ver_date", TypeName = "datetime")]
    public DateTime VerDate { get; set; }

    [Column("ver_comments")]
    [StringLength(80)]
    public string? VerComments { get; set; }

    [Column("preferred_ver")]
    public bool PreferredVer { get; set; }

    [Column("disassembly")]
    public bool Disassembly { get; set; }

    [Column("start_eff", TypeName = "datetime")]
    public DateTime? StartEff { get; set; }

    [Column("end_eff", TypeName = "datetime")]
    public DateTime? EndEff { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("mod_id")]
    public byte[] ModId { get; set; } = null!;

    [Column("row_id")]
    public int RowId { get; set; }
}
