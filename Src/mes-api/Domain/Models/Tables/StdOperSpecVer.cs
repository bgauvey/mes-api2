using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

/// <summary>
/// Holds header information for sets of standard operation specsaccording to version number, which contains version control information
/// </summary>
[PrimaryKey("OperId", "VerId")]
[Table("std_oper_spec_ver")]
public partial class StdOperSpecVer
{
    /// <summary>
    /// Identify process
    /// </summary>
    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    /// <summary>
    /// Identify revision to spec database
    /// </summary>
    [Key]
    [Column("ver_id")]
    [StringLength(40)]
    public string VerId { get; set; } = null!;

    /// <summary>
    /// Date version created/last modified
    /// </summary>
    [Column("ver_date", TypeName = "datetime")]
    public DateTime VerDate { get; set; }

    /// <summary>
    /// Comments for this version
    /// </summary>
    [Column("ver_comments")]
    [StringLength(80)]
    public string? VerComments { get; set; }

    /// <summary>
    /// Is this the preferred version
    /// </summary>
    [Column("preferred_ver")]
    public bool PreferredVer { get; set; }

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

    [ForeignKey("OperId")]
    [InverseProperty("StdOperSpecVers")]
    public virtual StdOper Oper { get; set; } = null!;

    [InverseProperty("StdOperSpecVer")]
    public virtual ICollection<StdOperEntSpec> StdOperEntSpecs { get; set; } = new List<StdOperEntSpec>();
}
