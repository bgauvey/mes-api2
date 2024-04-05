using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ProcessId", "OperId", "StepNo", "EntId", "VerId", "SpecId")]
[Table("oper_ent_spec")]
public partial class OperEntSpec
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
    [Column("step_no")]
    public int StepNo { get; set; }

    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("ver_id")]
    [StringLength(40)]
    public string VerId { get; set; } = null!;

    [Key]
    [Column("spec_id")]
    [StringLength(40)]
    public string SpecId { get; set; } = null!;

    [Column("spec_value")]
    [StringLength(1700)]
    public string SpecValue { get; set; } = null!;

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
