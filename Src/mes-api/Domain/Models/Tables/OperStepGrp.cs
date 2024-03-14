using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ProcessId", "OperId", "StepGrpId")]
[Table("oper_step_grp")]
public partial class OperStepGrp
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
    [Column("step_grp_id")]
    public int StepGrpId { get; set; }

    [Column("step_grp_desc")]
    [StringLength(80)]
    public string StepGrpDesc { get; set; } = null!;

    [Column("step_grp_seq")]
    public int StepGrpSeq { get; set; }

    [Column("repeatability")]
    public int Repeatability { get; set; }

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

    [ForeignKey("ProcessId, OperId")]
    [InverseProperty("OperStepGrps")]
    public virtual Oper Oper { get; set; } = null!;

    [InverseProperty("OperStepGrp")]
    public virtual ICollection<OperStep> OperSteps { get; set; } = new List<OperStep>();
}
