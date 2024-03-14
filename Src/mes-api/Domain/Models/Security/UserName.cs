using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BOL.API.Domain.Models.Security;

[Table("user_name")]
public class UserName
{
    [Key]
    [Column("user_id")]
    [StringLength(40)]
    public string UserId { get; set; } = null!;

    [Column("user_desc")]
    [StringLength(80)]
    public string? UserDesc { get; set; }

    [Column("encrypt_pw")]
    [StringLength(40)]
    public string EncryptPw { get; set; } = null!;

    [Column("active")]
    public bool Active { get; set; }

    [Column("hourly_cost")]
    public double? HourlyCost { get; set; }

    [Column("email_address")]
    [StringLength(80)]
    public string? EmailAddress { get; set; }

    [Column("lang_id")]
    public int LangId { get; set; }

    [Column("def_dept_id")]
    [StringLength(40)]
    public string? DefDeptId { get; set; }

    [Column("last_login", TypeName = "datetime")]
    public DateTime? LastLogin { get; set; }

    [Column("last_pw_change", TypeName = "datetime")]
    public DateTime? LastPwChange { get; set; }

    [Column("failed_logins")]
    public int FailedLogins { get; set; }

    [Column("auth_method")]
    public int AuthMethod { get; set; }

    [Column("def_lab_cd")]
    [StringLength(40)]
    public string? DefLabCd { get; set; }

    [Column("smtp_server")]
    [StringLength(80)]
    public string? SmtpServer { get; set; }

    [Column("pop3_server")]
    [StringLength(80)]
    public string? Pop3Server { get; set; }

    [Column("email_account")]
    [StringLength(80)]
    public string? EmailAccount { get; set; }

    [Column("email_pw")]
    [StringLength(20)]
    public string? EmailPw { get; set; }

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

    [Column("pw")]
    [StringLength(20)]
    public string? Pw { get; set; }
}

