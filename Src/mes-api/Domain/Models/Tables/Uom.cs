using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("uom")]
[Index("Description", Name = "IX_uom", IsUnique = true)]
public partial class Uom
{
    [Column("description")]
    [StringLength(40)]
    public string Description { get; set; } = null!;

    [Column("abbreviation")]
    [StringLength(20)]
    public string? Abbreviation { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("uom_id")]
    public int UomId { get; set; }
}
