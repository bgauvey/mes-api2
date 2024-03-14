using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("GrpId", "ProcessId", "OperId")]
[Table("data_log_grp_oper_link")]
public partial class DataLogGrpOperLink
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

    [Column("cert_name")]
    [StringLength(40)]
    public string? CertName { get; set; }

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
    [InverseProperty("DataLogGrpOperLinks")]
    public virtual Oper Oper { get; set; } = null!;

    [InverseProperty("DataLogGrpOperLink")]
    public virtual ICollection<OperStep> OperSteps { get; set; } = new List<OperStep>();
}
