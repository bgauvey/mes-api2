using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("spc_char_oper_link")]
public partial class SpcCharOperLink
{
    [Column("process_id")]
    [StringLength(40)]
    public string ProcessId { get; set; } = null!;

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
    [InverseProperty("SpcCharOperLinks")]
    public virtual SpcChar Char { get; set; } = null!;

    [ForeignKey("ProcessId, OperId")]
    [InverseProperty("SpcCharOperLinks")]
    public virtual Oper Oper { get; set; } = null!;
}
