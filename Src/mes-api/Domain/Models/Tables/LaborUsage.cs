using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("labor_usage")]
public partial class LaborUsage
{
    [Column("labor_start_utc", TypeName = "datetime")]
    public DateTime LaborStartUtc { get; set; }

    [Column("labor_start_local", TypeName = "datetime")]
    public DateTime LaborStartLocal { get; set; }

    [Column("user_id")]
    [StringLength(40)]
    public string UserId { get; set; } = null!;

    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("wo_id")]
    [StringLength(40)]
    public string? WoId { get; set; }

    [Column("oper_id")]
    [StringLength(40)]
    public string? OperId { get; set; }

    [Column("seq_no")]
    public int? SeqNo { get; set; }

    [Column("step_no")]
    public int? StepNo { get; set; }

    [Column("item_id")]
    [StringLength(40)]
    public string? ItemId { get; set; }

    [Column("lot_no")]
    [StringLength(40)]
    public string? LotNo { get; set; }

    [Column("sublot_no")]
    [StringLength(40)]
    public string? SublotNo { get; set; }

    [Column("lab_cd")]
    [StringLength(40)]
    public string LabCd { get; set; } = null!;

    [Column("dept_id")]
    [StringLength(40)]
    public string DeptId { get; set; } = null!;

    [Column("shift_id")]
    public int ShiftId { get; set; }

    [Column("shift_start_utc", TypeName = "datetime")]
    public DateTime ShiftStartUtc { get; set; }

    [Column("shift_start_local", TypeName = "datetime")]
    public DateTime ShiftStartLocal { get; set; }

    [Column("pct_to_apply")]
    public double PctToApply { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [Column("duration")]
    public int Duration { get; set; }

    [Column("comments")]
    [StringLength(254)]
    public string? Comments { get; set; }

    [Column("raw_reas_cd")]
    [StringLength(40)]
    public string? RawReasCd { get; set; }

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

    [Key]
    [Column("log_id")]
    public int LogId { get; set; }
}
