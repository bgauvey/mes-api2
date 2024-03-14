using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("labor_exec")]
public partial class LaborExec
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("def_lab_cd")]
    [StringLength(40)]
    public string? DefLabCd { get; set; }

    [Column("def_dept_id")]
    [StringLength(40)]
    public string? DefDeptId { get; set; }

    [Column("multiple_operators")]
    public int? MultipleOperators { get; set; }

    [Column("cur_raw_reas_cd")]
    [StringLength(40)]
    public string? CurRawReasCd { get; set; }

    [Column("def_raw_reas_cd")]
    [StringLength(40)]
    public string? DefRawReasCd { get; set; }

    [Column("lab_cd_reqd")]
    public bool LabCdReqd { get; set; }

    [Column("spare1")]
    [StringLength(1000)]
    public string? Spare1 { get; set; }

    [Column("spare2")]
    [StringLength(1000)]
    public string? Spare2 { get; set; }

    [Column("spare3")]
    [StringLength(1000)]
    public string? Spare3 { get; set; }

    [Column("spare4")]
    [StringLength(1000)]
    public string? Spare4 { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [InverseProperty("Ent")]
    public virtual ICollection<LaborDeptEntLink> LaborDeptEntLinks { get; set; } = new List<LaborDeptEntLink>();

    [ForeignKey("EntId, DefRawReasCd")]
    [InverseProperty("LaborExecs")]
    public virtual LaborRawRea? LaborRawRea { get; set; }

    [InverseProperty("Ent")]
    public virtual ICollection<LaborRawRea> LaborRawReas { get; set; } = new List<LaborRawRea>();

    [InverseProperty("Ent")]
    public virtual ICollection<LaborReasLink> LaborReasLinks { get; set; } = new List<LaborReasLink>();
}
