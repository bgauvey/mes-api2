using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("dx_query")]
public partial class DxQuery
{
    [Key]
    [Column("query_id")]
    public int QueryId { get; set; }

    [Column("query_desc")]
    [StringLength(254)]
    public string QueryDesc { get; set; } = null!;

    [Column("type")]
    public int Type { get; set; }

    [Column("query_detail")]
    [StringLength(4000)]
    public string? QueryDetail { get; set; }

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

    [InverseProperty("Query")]
    public virtual ICollection<DxQueryParam> DxQueryParams { get; set; } = new List<DxQueryParam>();

    [InverseProperty("Query")]
    public virtual ICollection<DxSched> DxScheds { get; set; } = new List<DxSched>();
}
