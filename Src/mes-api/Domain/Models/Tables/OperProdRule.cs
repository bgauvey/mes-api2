using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ProcessId", "OperId", "EntId", "OutcomeNo")]
[Table("oper_prod_rule")]
public partial class OperProdRule
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

    [Key]
    [Column("outcome_no")]
    public int OutcomeNo { get; set; }

    [Column("basis")]
    public int Basis { get; set; }

    [Column("attr_id")]
    public int AttrId { get; set; }

    [Column("standard_value")]
    [StringLength(80)]
    public string StandardValue { get; set; } = null!;

    [Column("relational_op")]
    public int? RelationalOp { get; set; }

    [Column("sp_name")]
    [StringLength(40)]
    public string? SpName { get; set; }

    [Column("next_oper_id")]
    [StringLength(40)]
    public string NextOperId { get; set; } = null!;

    [Column("next_ent_id")]
    public int NextEntId { get; set; }

    [Column("is_default")]
    public bool IsDefault { get; set; }

    [Column("spare1")]
    [StringLength(1000)]
    public string? Spare1 { get; set; }

    [Column("spare2")]
    [StringLength(1000)]
    public string? Spare2 { get; set; }

    [Column("spare3")]
    [StringLength(1000)]
    public string? Spare3 { get; set; }

    [Column("spare4")]
    [StringLength(1000)]
    public string? Spare4 { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("row_id")]
    public int RowId { get; set; }

    [ForeignKey("ProcessId, NextOperId, NextEntId")]
    [InverseProperty("OperProdRuleOperEntLinks")]
    public virtual OperEntLink OperEntLink { get; set; } = null!;

    [ForeignKey("ProcessId, OperId, EntId")]
    [InverseProperty("OperProdRuleOperEntLinkNavigations")]
    public virtual OperEntLink OperEntLinkNavigation { get; set; } = null!;
}
