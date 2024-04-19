using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Cert;

[Table("cert_type")]
public partial class CertType
{
    [Key]
    [Column("cert_name")]
    [StringLength(40)]
    public string CertName { get; set; } = null!;

    [Column("max_level")]
    public int MaxLevel { get; set; }

    [Column("duration")]
    public int Duration { get; set; }

    [Column("cert_audit")]
    public bool CertAudit { get; set; }

    [Column("signoff_notes")]
    [StringLength(254)]
    public string? SignoffNotes { get; set; }

    [Column("num_signoffs_reqd")]
    public int? NumSignoffsReqd { get; set; }

    [Column("reqd_exp_to_renew")]
    public int ReqdExpToRenew { get; set; }

    [Column("comments_reqd")]
    public bool CommentsReqd { get; set; }

    [Column("avail_to_oper")]
    public bool AvailToOper { get; set; }

    [Column("avail_to_oper_step")]
    public bool AvailToOperStep { get; set; }

    [Column("avail_to_prod_item")]
    public bool AvailToProdItem { get; set; }

    [Column("avail_to_cons_item")]
    public bool AvailToConsItem { get; set; }

    [Column("avail_to_attr")]
    public bool AvailToAttr { get; set; }

    [Column("avail_to_grade_chg")]
    public bool AvailToGradeChg { get; set; }

    [Column("avail_to_state_chg")]
    public bool AvailToStateChg { get; set; }

    [Column("avail_to_log_data")]
    public bool AvailToLogData { get; set; }

    [Column("up_to_experimental")]
    public bool UpToExperimental { get; set; }

    [Column("up_to_approved")]
    public bool UpToApproved { get; set; }

    [Column("up_to_certified")]
    public bool UpToCertified { get; set; }

    [Column("down_to_disabled")]
    public bool DownToDisabled { get; set; }

    [Column("down_to_experimental")]
    public bool DownToExperimental { get; set; }

    [Column("down_to_approved")]
    public bool DownToApproved { get; set; }

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

    [Column("row_id")]
    public int RowId { get; set; }
}
