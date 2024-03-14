using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("item_grade")]
[Index("ItemGradeDesc", Name = "IX_item_grade", IsUnique = true)]
public partial class ItemGrade
{
    [Column("item_grade_desc")]
    [StringLength(80)]
    public string ItemGradeDesc { get; set; } = null!;

    [Column("good_prod")]
    public bool GoodProd { get; set; }

    [Column("scrapped")]
    public bool Scrapped { get; set; }

    [Column("color")]
    public int Color { get; set; }

    [Column("pref")]
    public int Pref { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("item_grade_cd")]
    public int ItemGradeCd { get; set; }
}
