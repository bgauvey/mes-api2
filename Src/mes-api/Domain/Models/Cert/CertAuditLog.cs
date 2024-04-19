using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Cert;

[Table("cert_audit_log")]
public partial class CertAuditLog
{
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

    [Column("lot_no")]
    [StringLength(40)]
    public string? LotNo { get; set; }

    [Column("sublot_no")]
    [StringLength(40)]
    public string? SublotNo { get; set; }

    [Column("prod_log_id")]
    public int? ProdLogId { get; set; }

    [Column("cons_log_id")]
    public int? ConsLogId { get; set; }

    [Column("grp_id")]
    public int? GrpId { get; set; }

    [Column("process_id")]
    [StringLength(40)]
    public string? ProcessId { get; set; }

    [Column("process_status")]
    public int? ProcessStatus { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [Column("cert_name")]
    [StringLength(40)]
    public string CertName { get; set; } = null!;

    [Column("user_id")]
    [StringLength(40)]
    public string UserId { get; set; } = null!;

    [Column("sign_off_utc", TypeName = "datetime")]
    public DateTime SignOffUtc { get; set; }

    [Column("sign_off_local", TypeName = "datetime")]
    public DateTime SignOffLocal { get; set; }

    [Column("comments")]
    [StringLength(254)]
    public string? Comments { get; set; }

    [Column("ref_row_id")]
    public int? RefRowId { get; set; }

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
