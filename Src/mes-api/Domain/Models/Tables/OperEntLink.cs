using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ProcessId", "OperId", "EntId")]
[Table("oper_ent_link")]
public partial class OperEntLink
{
    [Key]
    [Column("process_id")]
    [StringLength(40)]
    public string ProcessId { get; set; } = null!;

    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("est_fixed_lab")]
    public double? EstFixedLab { get; set; }

    [Column("est_lab_rate")]
    public double? EstLabRate { get; set; }

    [Column("est_setup_time")]
    public double? EstSetupTime { get; set; }

    [Column("est_teardown_time")]
    public double? EstTeardownTime { get; set; }

    [Column("est_prod_rate")]
    public double EstProdRate { get; set; }

    [Column("prod_uom")]
    public int ProdUom { get; set; }

    [Column("batch_size")]
    public double BatchSize { get; set; }

    [Column("est_transfer_time")]
    public double? EstTransferTime { get; set; }

    [Column("init_prod_pct")]
    public double? InitProdPct { get; set; }

    [Column("parent_contingent_ent")]
    public bool ParentContingentEnt { get; set; }

    [Column("child_contingent_ent")]
    public bool ChildContingentEnt { get; set; }

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

    [ForeignKey("EntId")]
    [InverseProperty("OperEntLinks")]
    public virtual JobSchedExec Ent { get; set; } = null!;

    [InverseProperty("OperEntLink")]
    public virtual ICollection<FolderItemOperEntLink> FolderItemOperEntLinks { get; set; } = new List<FolderItemOperEntLink>();

    [InverseProperty("OperEntLink")]
    public virtual ICollection<ItemRule> ItemRules { get; set; } = new List<ItemRule>();

    [ForeignKey("ProcessId, OperId")]
    [InverseProperty("OperEntLinks")]
    public virtual Oper Oper { get; set; } = null!;

    [InverseProperty("OperEntLink")]
    public virtual ICollection<OperAllocRule> OperAllocRules { get; set; } = new List<OperAllocRule>();

    [InverseProperty("OperEntLinkNavigation")]
    public virtual ICollection<OperEntRoute> OperEntRouteOperEntLinkNavigations { get; set; } = new List<OperEntRoute>();

    [InverseProperty("OperEntLink")]
    public virtual ICollection<OperEntRoute> OperEntRouteOperEntLinks { get; set; } = new List<OperEntRoute>();

    [InverseProperty("OperEntLink")]
    public virtual ICollection<OperEntSpec> OperEntSpecs { get; set; } = new List<OperEntSpec>();

    [InverseProperty("OperEntLinkNavigation")]
    public virtual ICollection<OperProdRule> OperProdRuleOperEntLinkNavigations { get; set; } = new List<OperProdRule>();

    [InverseProperty("OperEntLink")]
    public virtual ICollection<OperProdRule> OperProdRuleOperEntLinks { get; set; } = new List<OperProdRule>();
}
