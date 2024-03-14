using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("WoId", "OperId", "SeqNo", "StepNo", "AssocFile")]
[Table("job_step_file")]
public partial class JobStepFile
{
    [Key]
    [Column("wo_id")]
    [StringLength(40)]
    public string WoId { get; set; } = null!;

    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Key]
    [Column("seq_no")]
    public int SeqNo { get; set; }

    [Key]
    [Column("step_no")]
    public int StepNo { get; set; }

    [Key]
    [Column("assoc_file")]
    [StringLength(254)]
    public string AssocFile { get; set; } = null!;

    [Column("assoc_file_type")]
    [StringLength(20)]
    public string AssocFileType { get; set; } = null!;

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

    [ForeignKey("AssocFileType")]
    [InverseProperty("JobStepFiles")]
    public virtual DocType AssocFileTypeNavigation { get; set; } = null!;
}
