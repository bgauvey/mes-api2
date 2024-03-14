using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("GrpId", "ProcessId", "OperId", "StepNo")]
[Table("data_log_grp_oper_step_link")]
public partial class DataLogGrpOperStepLink
{
    [Key]
    [Column("grp_id")]
    public int GrpId { get; set; }

    [Key]
    [Column("process_id")]
    [StringLength(40)]
    public string ProcessId { get; set; } = null!;

    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Key]
    [Column("step_no")]
    public int StepNo { get; set; }

    [Column("cert_name")]
    [StringLength(40)]
    public string? CertName { get; set; }

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

    [ForeignKey("ProcessId, OperId, StepNo")]
    [InverseProperty("DataLogGrpOperStepLinks")]
    public virtual OperStep OperStep { get; set; } = null!;
}
