using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("dx_sched")]
public partial class DxSched
{
    [Key]
    [Column("sched_id")]
    [StringLength(40)]
    public string SchedId { get; set; } = null!;

    [Column("sched_type")]
    public int SchedType { get; set; }

    [Column("enabled")]
    public bool Enabled { get; set; }

    [Column("trigger_option")]
    public int TriggerOption { get; set; }

    [Column("trigger_detail")]
    [StringLength(1000)]
    public string? TriggerDetail { get; set; }

    [Column("data_type")]
    public int DataType { get; set; }

    [Column("data_detail")]
    [StringLength(1000)]
    public string? DataDetail { get; set; }

    [Column("query_id")]
    public int? QueryId { get; set; }

    [Column("format_option")]
    public int FormatOption { get; set; }

    [Column("format_detail")]
    [StringLength(1000)]
    public string? FormatDetail { get; set; }

    [Column("transport_option")]
    public int TransportOption { get; set; }

    [Column("transport_detail")]
    [StringLength(1000)]
    public string? TransportDetail { get; set; }

    [Column("post_update_option")]
    public int PostUpdateOption { get; set; }

    [Column("post_update_detail")]
    [StringLength(1000)]
    public string? PostUpdateDetail { get; set; }

    [Column("post_action_option")]
    public int PostActionOption { get; set; }

    [Column("post_action_detail")]
    [StringLength(1000)]
    public string? PostActionDetail { get; set; }

    [Column("last_activity", TypeName = "datetime")]
    public DateTime? LastActivity { get; set; }

    [Column("last_result")]
    public int? LastResult { get; set; }

    [Column("runtime_script")]
    [StringLength(1700)]
    public string? RuntimeScript { get; set; }

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

    [InverseProperty("Sched")]
    public virtual ICollection<DxField> DxFields { get; set; } = new List<DxField>();

    [InverseProperty("Sched")]
    public virtual ICollection<DxLog> DxLogs { get; set; } = new List<DxLog>();

    [ForeignKey("QueryId")]
    [InverseProperty("DxScheds")]
    public virtual DxQuery? Query { get; set; }
}
