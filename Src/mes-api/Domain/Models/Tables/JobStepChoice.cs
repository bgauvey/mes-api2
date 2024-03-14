using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("job_step_choice")]
[Index("WoId", "OperId", "SeqNo", "StepNo", "ChoiceLabel", Name = "UIX_job_step_choice", IsUnique = true)]
public partial class JobStepChoice
{
    [Column("wo_id")]
    [StringLength(40)]
    public string WoId { get; set; } = null!;

    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Column("seq_no")]
    public int SeqNo { get; set; }

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
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }
}
