using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("GrpId", "ValueIndex")]
[Table("data_log_value")]
public partial class DataLogValue
{
    [Key]
    [Column("grp_id")]
    public int GrpId { get; set; }

    [Key]
    [Column("value_index")]
    public int ValueIndex { get; set; }

    [Column("value_name")]
    [StringLength(80)]
    public string ValueName { get; set; } = null!;

    [Column("value_type")]
    public int ValueType { get; set; }

    [Column("editable")]
    public bool Editable { get; set; }

    [Column("cur_value")]
    [StringLength(80)]
    public string? CurValue { get; set; }

    [Column("spec_id")]
    [StringLength(40)]
    public string? SpecId { get; set; }

    [Column("meaning")]
    public int? Meaning { get; set; }

    [Column("meaning_to_value_index")]
    public int? MeaningToValueIndex { get; set; }

    [Column("spare1")]
    [StringLength(1000)]
    public string? Spare1 { get; set; }

    [Column("spare2")]
    [StringLength(1000)]
    public string? Spare2 { get; set; }

    [Column("spare3")]
    [StringLength(1000)]
    public string? Spare3 { get; set; }

    [Column("spare4")]
    [StringLength(1000)]
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
