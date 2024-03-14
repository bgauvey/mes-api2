using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("MappingId", "InternalId")]
[Table("dx_map_exp")]
public partial class DxMapExp
{
    [Key]
    [Column("mapping_id")]
    [StringLength(40)]
    public string MappingId { get; set; } = null!;

    [Key]
    [Column("internal_id")]
    [StringLength(80)]
    public string InternalId { get; set; } = null!;

    [Column("external_id")]
    [StringLength(80)]
    public string ExternalId { get; set; } = null!;

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
