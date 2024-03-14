using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("QueryId", "ParamName")]
[Table("dx_query_param")]
public partial class DxQueryParam
{
    [Key]
    [Column("query_id")]
    public int QueryId { get; set; }

    [Key]
    [Column("param_name")]
    [StringLength(40)]
    public string ParamName { get; set; } = null!;

    [Column("seq_no")]
    public int SeqNo { get; set; }

    [Column("direction")]
    public int Direction { get; set; }

    [Column("param_type")]
    public int ParamType { get; set; }

    [Column("param_size")]
    public int? ParamSize { get; set; }

    [Column("runtime_source")]
    [StringLength(1700)]
    public string? RuntimeSource { get; set; }

    [Column("def_value")]
    [StringLength(40)]
    public string? DefValue { get; set; }

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

    [ForeignKey("QueryId")]
    [InverseProperty("DxQueryParams")]
    public virtual DxQuery Query { get; set; } = null!;
}
