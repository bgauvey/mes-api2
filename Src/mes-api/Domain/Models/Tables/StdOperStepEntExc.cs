using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("OperId", "StepNo", "EntId")]
[Table("std_oper_step_ent_exc")]
public partial class StdOperStepEntExc
{
    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Key]
    [Column("step_no")]
    public int StepNo { get; set; }

    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

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

    [ForeignKey("EntId")]
    [InverseProperty("StdOperStepEntExcs")]
    public virtual JobSchedExec Ent { get; set; } = null!;

    [ForeignKey("OperId, StepNo")]
    [InverseProperty("StdOperStepEntExcs")]
    public virtual StdOperStep StdOperStep { get; set; } = null!;
}
