using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[PrimaryKey("Id", "Address")]
[Table("mail_grp_member")]
public partial class MailGrpMember
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Key]
    [Column("address")]
    [StringLength(80)]
    public string Address { get; set; } = null!;

    [Column("ext_mail")]
    public bool ExtMail { get; set; }

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
