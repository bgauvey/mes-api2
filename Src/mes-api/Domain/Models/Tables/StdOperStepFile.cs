using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

/// <summary>
/// Provides the ability to link any number of files to a standard operation step
/// </summary>
[PrimaryKey("OperId", "StepNo", "AssocFile")]
[Table("std_oper_step_file")]
public partial class StdOperStepFile
{
    /// <summary>
    /// Identify operation
    /// </summary>
    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    /// <summary>
    /// Identify step
    /// </summary>
    [Key]
    [Column("step_no")]
    public int StepNo { get; set; }

    /// <summary>
    /// Associated file
    /// </summary>
    [Key]
    [Column("assoc_file")]
    [StringLength(254)]
    public string AssocFile { get; set; } = null!;

    /// <summary>
    /// Associated file’s type
    /// </summary>
    [Column("assoc_file_type")]
    [StringLength(20)]
    public string AssocFileType { get; set; } = null!;

    /// <summary>
    /// Why record was changed
    /// </summary>
    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    /// <summary>
    /// Who last changed this record
    /// </summary>
    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    /// <summary>
    /// When record was last changed
    /// </summary>
    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    /// <summary>
    /// Unique row identifier, for audit trail
    /// </summary>
    [Column("row_id")]
    public int RowId { get; set; }

    [ForeignKey("AssocFileType")]
    [InverseProperty("StdOperStepFiles")]
    public virtual DocType AssocFileTypeNavigation { get; set; } = null!;

    [ForeignKey("OperId, StepNo")]
    [InverseProperty("StdOperStepFiles")]
    public virtual StdOperStep StdOperStep { get; set; } = null!;
}
