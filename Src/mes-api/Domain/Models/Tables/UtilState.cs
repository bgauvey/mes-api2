using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("util_state")]
[Index("StateDesc", Name = "IX_util_state", IsUnique = true)]
public partial class UtilState
{
    [Column("state_desc")]
    [StringLength(80)]
    public string StateDesc { get; set; } = null!;

    [Column("color")]
    public int Color { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("state_cd")]
    public int StateCd { get; set; }
}
