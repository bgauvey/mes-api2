using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("labor_cat")]
[Index("LabDesc", Name = "IX_labor_cat", IsUnique = true)]
public partial class LaborCat
{
    [Key]
    [Column("lab_cd")]
    [StringLength(40)]
    public string LabCd { get; set; } = null!;

    [Column("lab_desc")]
    [StringLength(80)]
    public string LabDesc { get; set; } = null!;

    [Column("fixedtime")]
    public bool Fixedtime { get; set; }

    [Column("vartime")]
    public bool Vartime { get; set; }

    [Column("color")]
    public int Color { get; set; }

    [Column("std_crew")]
    public double? StdCrew { get; set; }

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
}
