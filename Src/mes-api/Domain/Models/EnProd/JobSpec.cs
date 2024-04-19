using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.EnProd;

[PrimaryKey("WoId", "OperId", "SeqNo", "StepNo", "SpecId")]
[Table("job_spec")]
public partial class JobSpec
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
    [Column("spec_id")]
    [StringLength(40)]
    public string SpecId { get; set; } = null!;

    [Column("spec_value")]
    [StringLength(1700)]
    public string SpecValue { get; set; } = null!;

    [Column("act_spec_value")]
    [StringLength(1700)]
    public string? ActSpecValue { get; set; }

    [Column("assoc_file")]
    [StringLength(254)]
    public string? AssocFile { get; set; }

    [Column("assoc_file_type")]
    [StringLength(20)]
    public string? AssocFileType { get; set; }

    [Column("comments")]
    [StringLength(1700)]
    public string? Comments { get; set; }

    [Column("min_value")]
    [StringLength(80)]
    public string? MinValue { get; set; }

    [Column("max_value")]
    [StringLength(80)]
    public string? MaxValue { get; set; }

    [Column("access_level")]
    public int? AccessLevel { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("mod_id")]
    public byte[] ModId { get; set; } = null!;

    [Column("row_id")]
    public int RowId { get; set; }
}
