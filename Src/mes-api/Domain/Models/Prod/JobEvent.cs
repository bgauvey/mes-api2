using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Prod;

[Table("job_event")]
public partial class JobEvent
{
    [Column("event_time_utc", TypeName = "datetime")]
    public DateTime EventTimeUtc { get; set; }

    [Column("event_time_local", TypeName = "datetime")]
    public DateTime EventTimeLocal { get; set; }

    [Column("wo_id")]
    [StringLength(40)]
    public string WoId { get; set; } = null!;

    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Column("seq_no")]
    public int SeqNo { get; set; }

    [Column("step_no")]
    public int? StepNo { get; set; }

    [Column("event_type")]
    [StringLength(40)]
    public string? EventType { get; set; }

    [Column("ent_id")]
    public int? EntId { get; set; }

    [Column("bom_pos")]
    public int? BomPos { get; set; }

    [Column("lot_no")]
    [StringLength(40)]
    public string? LotNo { get; set; }

    [Column("sublot_no")]
    [StringLength(40)]
    public string? SublotNo { get; set; }

    [Column("item_id")]
    [StringLength(40)]
    public string? ItemId { get; set; }

    [Column("cert_name")]
    [StringLength(40)]
    public string? CertName { get; set; }

    [Column("done_by_user_id")]
    [StringLength(40)]
    public string? DoneByUserId { get; set; }

    [Column("checked_by_user_id")]
    [StringLength(40)]
    public string? CheckedByUserId { get; set; }

    [Column("source_row_id")]
    public int? SourceRowId { get; set; }

    [Column("spec_id")]
    [StringLength(40)]
    public string? SpecId { get; set; }

    [Column("comments")]
    [StringLength(254)]
    public string? Comments { get; set; }

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
