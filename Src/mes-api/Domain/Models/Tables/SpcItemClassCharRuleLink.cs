using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ItemClassId", "CharId", "RuleId")]
[Table("spc_item_class_char_rule_link")]
public partial class SpcItemClassCharRuleLink
{
    [Key]
    [Column("item_class_id")]
    [StringLength(40)]
    public string ItemClassId { get; set; } = null!;

    [Key]
    [Column("char_id")]
    public int CharId { get; set; }

    [Key]
    [Column("rule_id")]
    public int RuleId { get; set; }

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

    [ForeignKey("RuleId")]
    [InverseProperty("SpcItemClassCharRuleLinks")]
    public virtual SpcRule Rule { get; set; } = null!;

    [ForeignKey("ItemClassId, CharId")]
    [InverseProperty("SpcItemClassCharRuleLinks")]
    public virtual SpcItemClassCharLink SpcItemClassCharLink { get; set; } = null!;
}
