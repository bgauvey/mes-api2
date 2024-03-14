using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

/// <summary>
/// Contains setup parameters specific to a standard operation being done on a specific entity, independent of which item is being consumed or produced
/// </summary>
[PrimaryKey("OperId", "StepNo", "EntId", "VerId", "SpecId")]
[Table("std_oper_ent_spec")]
public partial class StdOperEntSpec
{
    /// <summary>
    /// Identify operation
    /// </summary>
    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    /// <summary>
    /// Identify step no
    /// </summary>
    [Key]
    [Column("step_no")]
    public int StepNo { get; set; }

    /// <summary>
    /// Identify entity
    /// </summary>
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    /// <summary>
    /// Identify spec version
    /// </summary>
    [Key]
    [Column("ver_id")]
    [StringLength(40)]
    public string VerId { get; set; } = null!;

    /// <summary>
    /// Identify spec for operation
    /// </summary>
    [Key]
    [Column("spec_id")]
    [StringLength(40)]
    public string SpecId { get; set; } = null!;

    /// <summary>
    /// STRING80 (nvarchar)
    /// </summary>
    [Column("spec_value")]
    [StringLength(1700)]
    public string SpecValue { get; set; } = null!;

    /// <summary>
    /// Associated file
    /// </summary>
    [Column("assoc_file")]
    [StringLength(254)]
    public string? AssocFile { get; set; }

    /// <summary>
    /// Associated file’s type
    /// </summary>
    [Column("assoc_file_type")]
    [StringLength(20)]
    public string? AssocFileType { get; set; }

    /// <summary>
    /// Comments/instructions to operator
    /// </summary>
    [Column("comments")]
    [StringLength(1700)]
    public string? Comments { get; set; }

    /// <summary>
    /// Minimum acceptable value for the spec
    /// </summary>
    [Column("min_value")]
    [StringLength(80)]
    public string? MinValue { get; set; }

    /// <summary>
    /// Maximum acceptable value for the spec
    /// </summary>
    [Column("max_value")]
    [StringLength(80)]
    public string? MaxValue { get; set; }

    /// <summary>
    /// Required security access level for modifying this spec
    /// </summary>
    [Column("access_level")]
    public int? AccessLevel { get; set; }

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
    [InverseProperty("StdOperEntSpecs")]
    public virtual DocType? AssocFileTypeNavigation { get; set; }

    [ForeignKey("OperId, EntId")]
    [InverseProperty("StdOperEntSpecs")]
    public virtual StdOperEntLink StdOperEntLink { get; set; } = null!;

    [ForeignKey("OperId, VerId")]
    [InverseProperty("StdOperEntSpecs")]
    public virtual StdOperSpecVer StdOperSpecVer { get; set; } = null!;
}
