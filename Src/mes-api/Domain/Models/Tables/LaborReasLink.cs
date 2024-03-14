using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("EntId", "RawReasCd", "LabCd")]
[Table("labor_reas_link")]
public partial class LaborReasLink
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("raw_reas_cd")]
    [StringLength(40)]
    public string RawReasCd { get; set; } = null!;

    [Key]
    [Column("lab_cd")]
    [StringLength(40)]
    public string LabCd { get; set; } = null!;

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

    [ForeignKey("EntId")]
    [InverseProperty("LaborReasLinks")]
    public virtual LaborExec Ent { get; set; } = null!;
}
