using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ItemId", "CharId")]
[Table("spc_item_char_link")]
public partial class SpcItemCharLink
{
    [Key]
    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Key]
    [Column("char_id")]
    public int CharId { get; set; }

    [Column("lvl")]
    public double? Lvl { get; set; }

    [Column("uvl")]
    public double? Uvl { get; set; }

    [Column("lcl")]
    public double? Lcl { get; set; }

    [Column("ucl")]
    public double? Ucl { get; set; }

    [Column("lsl")]
    public double? Lsl { get; set; }

    [Column("usl")]
    public double? Usl { get; set; }

    [Column("lrl")]
    public double? Lrl { get; set; }

    [Column("url")]
    public double? Url { get; set; }

    [Column("target_v")]
    public double? TargetV { get; set; }

    [Column("target_rs")]
    public double? TargetRs { get; set; }

    [Column("lcpk")]
    public double? Lcpk { get; set; }

    [Column("ucpk")]
    public double? Ucpk { get; set; }

    [Column("est_sigma")]
    public bool EstSigma { get; set; }

    [Column("units")]
    [StringLength(40)]
    public string? Units { get; set; }

    [Column("decimals")]
    public int Decimals { get; set; }

    [Column("prefill")]
    [StringLength(20)]
    public string? Prefill { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    [Column("created_by")]
    [StringLength(40)]
    public string CreatedBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("row_id")]
    public int RowId { get; set; }

    [ForeignKey("CharId")]
    [InverseProperty("SpcItemCharLinks")]
    public virtual SpcChar Char { get; set; } = null!;

    [InverseProperty("SpcItemCharLink")]
    public virtual ICollection<SpcItemCharRuleLink> SpcItemCharRuleLinks { get; set; } = new List<SpcItemCharRuleLink>();
}
