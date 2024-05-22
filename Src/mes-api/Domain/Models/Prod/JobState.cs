using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Prod;

[Table("job_state")]
public partial class JobState
{
    [Key]
    [Column("state_cd")]
    public int StateCd { get; set; }

    [Column("state_desc")]
    [StringLength(40)]
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
}
