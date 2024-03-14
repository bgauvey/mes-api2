using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ProcessId", "OperId", "VerId")]
[Table("oper_spec_ver")]
public partial class OperSpecVer
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
    [Column("ver_id")]
    [StringLength(40)]
    public string VerId { get; set; } = null!;

    [Column("ver_date", TypeName = "datetime")]
    public DateTime VerDate { get; set; }

    [Column("ver_comments")]
    [StringLength(80)]
    public string? VerComments { get; set; }

    [Column("preferred_ver")]
    public bool PreferredVer { get; set; }

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

    [InverseProperty("OperSpecVer")]
    public virtual ICollection<BomItemOperSpec> BomItemOperSpecs { get; set; } = new List<BomItemOperSpec>();

    [ForeignKey("ProcessId, OperId")]
    [InverseProperty("OperSpecVers")]
    public virtual Oper Oper { get; set; } = null!;

    [InverseProperty("OperSpecVer")]
    public virtual ICollection<OperEntSpec> OperEntSpecs { get; set; } = new List<OperEntSpec>();
}
