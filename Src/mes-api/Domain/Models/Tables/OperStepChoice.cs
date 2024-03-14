using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("oper_step_choice")]
[Index("ProcessId", "OperId", "StepNo", "ChoiceLabel", Name = "UIX_oper_step_choice", IsUnique = true)]
public partial class OperStepChoice
{
    [Column("process_id")]
    [StringLength(40)]
    public string ProcessId { get; set; } = null!;

    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Column("step_no")]
    public int StepNo { get; set; }

    [Column("choice_no")]
    public int ChoiceNo { get; set; }

    [Column("choice_label")]
    [StringLength(40)]
    public string ChoiceLabel { get; set; } = null!;

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }

    [ForeignKey("ProcessId, OperId, StepNo")]
    [InverseProperty("OperStepChoices")]
    public virtual OperStep OperStep { get; set; } = null!;
}
