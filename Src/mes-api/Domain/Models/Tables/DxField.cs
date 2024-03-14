using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("SchedId", "FieldName")]
[Table("dx_field")]
public partial class DxField
{
    [Key]
    [Column("sched_id")]
    [StringLength(40)]
    public string SchedId { get; set; } = null!;

    [Key]
    [Column("field_name")]
    [StringLength(40)]
    public string FieldName { get; set; } = null!;

    [Column("included")]
    public bool Included { get; set; }

    [Column("mandatory")]
    public bool Mandatory { get; set; }

    [Column("display_seq")]
    public int DisplaySeq { get; set; }

    [Column("default_value")]
    [StringLength(254)]
    public string? DefaultValue { get; set; }

    [Column("mapping_id")]
    [StringLength(40)]
    public string? MappingId { get; set; }

    [Column("field_index")]
    public int? FieldIndex { get; set; }

    [Column("format_detail")]
    [StringLength(1000)]
    public string? FormatDetail { get; set; }

    [Column("formula")]
    [StringLength(254)]
    public string? Formula { get; set; }

    [Column("primary_key")]
    public bool PrimaryKey { get; set; }

    [Column("spare1")]
    [StringLength(254)]
    public string? Spare1 { get; set; }

    [Column("spare2")]
    [StringLength(254)]
    public string? Spare2 { get; set; }

    [Column("spare3")]
    [StringLength(254)]
    public string? Spare3 { get; set; }

    [Column("spare4")]
    [StringLength(254)]
    public string? Spare4 { get; set; }

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

    [ForeignKey("SchedId")]
    [InverseProperty("DxFields")]
    public virtual DxSched Sched { get; set; } = null!;
}
