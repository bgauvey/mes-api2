using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("EntId", "SeqNo")]
[Table("fileque")]
public partial class Fileque
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("seq_no")]
    public int SeqNo { get; set; }

    [Column("in_use")]
    public bool InUse { get; set; }

    [Column("group_no")]
    public int GroupNo { get; set; }

    [Column("q_times")]
    public int QTimes { get; set; }

    [Column("grp_order")]
    public bool GrpOrder { get; set; }

    [Column("path")]
    [StringLength(254)]
    public string Path { get; set; } = null!;

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("row_id")]
    public int RowId { get; set; }
}
