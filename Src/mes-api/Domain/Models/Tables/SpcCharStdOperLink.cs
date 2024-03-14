using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("spc_char_std_oper_link")]
[Index("OperId", "StepNo", "CharId", Name = "IX_spc_char_std_oper_link", IsUnique = true)]
public partial class SpcCharStdOperLink
{
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Column("step_no")]
    public int StepNo { get; set; }

    [Column("char_id")]
    public int CharId { get; set; }

    [Column("sequence")]
    public int Sequence { get; set; }

    [Column("grp_seq")]
    public int GrpSeq { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    [Column("created_by")]
    [StringLength(40)]
    public string CreatedBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }

    [ForeignKey("CharId")]
    [InverseProperty("SpcCharStdOperLinks")]
    public virtual SpcChar Char { get; set; } = null!;

    [ForeignKey("OperId")]
    [InverseProperty("SpcCharStdOperLinks")]
    public virtual StdOper Oper { get; set; } = null!;
}
