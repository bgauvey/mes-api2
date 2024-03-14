using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("DeptId", "LabCd")]
[Table("labor_dept_cat_link")]
public partial class LaborDeptCatLink
{
    [Key]
    [Column("dept_id")]
    [StringLength(40)]
    public string DeptId { get; set; } = null!;

    [Key]
    [Column("lab_cd")]
    [StringLength(40)]
    public string LabCd { get; set; } = null!;

    [Column("std_crew")]
    public double? StdCrew { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("row_id")]
    public int RowId { get; set; }
}
