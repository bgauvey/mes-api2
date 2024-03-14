using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("data_log_16")]
public partial class DataLog16
{
    [Column("grp_id")]
    public int GrpId { get; set; }

    [Column("sample_time_utc", TypeName = "datetime")]
    public DateTime SampleTimeUtc { get; set; }

    [Column("sample_time_local", TypeName = "datetime")]
    public DateTime SampleTimeLocal { get; set; }

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

    [Column("shift_start_utc", TypeName = "datetime")]
    public DateTime ShiftStartUtc { get; set; }

    [Column("shift_start_local", TypeName = "datetime")]
    public DateTime ShiftStartLocal { get; set; }

    [Column("shift_id")]
    public int ShiftId { get; set; }

    [Column("ent_id")]
    public int? EntId { get; set; }

    [Column("value1")]
    [StringLength(80)]
    public string? Value1 { get; set; }

    [Column("value2")]
    [StringLength(80)]
    public string? Value2 { get; set; }

    [Column("value3")]
    [StringLength(80)]
    public string? Value3 { get; set; }

    [Column("value4")]
    [StringLength(80)]
    public string? Value4 { get; set; }

    [Column("value5")]
    [StringLength(80)]
    public string? Value5 { get; set; }

    [Column("value6")]
    [StringLength(80)]
    public string? Value6 { get; set; }

    [Column("value7")]
    [StringLength(80)]
    public string? Value7 { get; set; }

    [Column("value8")]
    [StringLength(80)]
    public string? Value8 { get; set; }

    [Column("value9")]
    [StringLength(80)]
    public string? Value9 { get; set; }

    [Column("value10")]
    [StringLength(80)]
    public string? Value10 { get; set; }

    [Column("value11")]
    [StringLength(80)]
    public string? Value11 { get; set; }

    [Column("value12")]
    [StringLength(80)]
    public string? Value12 { get; set; }

    [Column("value13")]
    [StringLength(80)]
    public string? Value13 { get; set; }

    [Column("value14")]
    [StringLength(80)]
    public string? Value14 { get; set; }

    [Column("value15")]
    [StringLength(80)]
    public string? Value15 { get; set; }

    [Column("value16")]
    [StringLength(80)]
    public string? Value16 { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }
}
