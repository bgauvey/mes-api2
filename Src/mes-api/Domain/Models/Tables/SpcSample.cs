using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("spc_sample")]
public partial class SpcSample
{
    [Column("char_id")]
    public int CharId { get; set; }

    [Column("dl_row_id")]
    public int DlRowId { get; set; }

    [Column("sample_no")]
    public int SampleNo { get; set; }

    [Column("lot_no")]
    [StringLength(40)]
    public string? LotNo { get; set; }

    [Column("sublot_no")]
    [StringLength(40)]
    public string? SublotNo { get; set; }

    [Column("valu")]
    public double? Valu { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    [Column("created_by")]
    [StringLength(40)]
    public string CreatedBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }
}
