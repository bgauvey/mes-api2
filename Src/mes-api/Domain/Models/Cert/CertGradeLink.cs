using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Cert;

[PrimaryKey("CertName", "FromItemGradeCd", "ToItemGradeCd")]
[Table("cert_grade_link")]
public partial class CertGradeLink
{
    [Key]
    [Column("cert_name")]
    [StringLength(40)]
    public string CertName { get; set; } = null!;

    [Key]
    [Column("from_item_grade_cd")]
    public int FromItemGradeCd { get; set; }

    [Key]
    [Column("to_item_grade_cd")]
    public int ToItemGradeCd { get; set; }

    [Column("cert_level")]
    public int CertLevel { get; set; }

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
