using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("spc_rule")]
[Index("Priority", Name = "UIX_sr_priority", IsUnique = true)]
[Index("RuleDesc", Name = "UIX_sr_rule_desc", IsUnique = true)]
public partial class SpcRule
{
    [Column("rule_desc")]
    [StringLength(40)]
    public string RuleDesc { get; set; } = null!;

    [Column("rs_not_x")]
    public bool RsNotX { get; set; }

    [Column("test1")]
    public int Test1 { get; set; }

    [Column("test2")]
    public int Test2 { get; set; }

    [Column("and_not_or")]
    public bool AndNotOr { get; set; }

    [Column("level1")]
    public double? Level1 { get; set; }

    [Column("level2")]
    public double? Level2 { get; set; }

    [Column("num_points")]
    public int NumPoints { get; set; }

    [Column("of_points")]
    public int OfPoints { get; set; }

    [Column("priority")]
    public int Priority { get; set; }

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

    [Key]
    [Column("rule_id")]
    public int RuleId { get; set; }

    [InverseProperty("Rule")]
    public virtual ICollection<SpcCharJobRuleLink> SpcCharJobRuleLinks { get; set; } = new List<SpcCharJobRuleLink>();

    [InverseProperty("Rule")]
    public virtual ICollection<SpcItemCharRuleLink> SpcItemCharRuleLinks { get; set; } = new List<SpcItemCharRuleLink>();

    [InverseProperty("Rule")]
    public virtual ICollection<SpcItemClassCharRuleLink> SpcItemClassCharRuleLinks { get; set; } = new List<SpcItemClassCharRuleLink>();
}
