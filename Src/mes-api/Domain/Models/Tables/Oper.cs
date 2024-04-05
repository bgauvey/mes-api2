using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ProcessId", "OperId")]
[Table("oper")]
public partial class Oper
{
    [Key]
    [Column("process_id")]
    [StringLength(40)]
    public string ProcessId { get; set; } = null!;

    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Column("oper_desc")]
    [StringLength(80)]
    public string? OperDesc { get; set; }

    [Column("def_reject_rate")]
    public double? DefRejectRate { get; set; }

    [Column("first_oper")]
    public bool FirstOper { get; set; }

    [Column("final_oper")]
    public bool FinalOper { get; set; }

    [Column("display_seq")]
    public int DisplaySeq { get; set; }

    [Column("check_inv")]
    public bool CheckInv { get; set; }

    [Column("sched_to_ent_id")]
    public int? SchedToEntId { get; set; }

    [Column("oper_type")]
    [StringLength(80)]
    public string? OperType { get; set; }

    [Column("oper_cost")]
    public double? OperCost { get; set; }

    [Column("deviation_above")]
    public double DeviationAbove { get; set; }

    [Column("deviation_below")]
    public double DeviationBelow { get; set; }

    [Column("assoc_file")]
    [StringLength(254)]
    public string? AssocFile { get; set; }

    [Column("assoc_file_type")]
    [StringLength(20)]
    public string? AssocFileType { get; set; }

    [Column("rework_cd")]
    [StringLength(40)]
    public string? ReworkCd { get; set; }

    [Column("notes", TypeName = "ntext")]
    public string? Notes { get; set; }

    [Column("spare1")]
    [StringLength(80)]
    public string? Spare1 { get; set; }

    [Column("spare2")]
    [StringLength(80)]
    public string? Spare2 { get; set; }

    [Column("spare3")]
    [StringLength(80)]
    public string? Spare3 { get; set; }

    [Column("spare4")]
    [StringLength(80)]
    public string? Spare4 { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("mod_id")]
    public byte[] ModId { get; set; } = null!;

    [Column("row_id")]
    public int RowId { get; set; }
}
