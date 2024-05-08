using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[Table("mgr_data_config")]
public partial class MgrDataConfig
{
    [Column("rep_type")]
    public int RepType { get; set; }

    [Column("rep_name")]
    [StringLength(80)]
    public string RepName { get; set; } = null!;

    [Column("query_id")]
    public int QueryId { get; set; }

    [Column("rep_desc")]
    [StringLength(254)]
    public string? RepDesc { get; set; }

    [Column("rep_category")]
    [StringLength(40)]
    public string? RepCategory { get; set; }

    [Column("rep_filepath")]
    [StringLength(254)]
    public string? RepFilepath { get; set; }

    [Column("rep_parameters")]
    [StringLength(254)]
    public string? RepParameters { get; set; }

    [Column("sort_order")]
    [StringLength(254)]
    public string? SortOrder { get; set; }

    [Column("custom_filter")]
    [StringLength(1700)]
    public string? CustomFilter { get; set; }

    [Column("view_level")]
    public int ViewLevel { get; set; }

    [Column("max_pages")]
    public int MaxPages { get; set; }

    [Column("parent_rep")]
    [StringLength(80)]
    public string? ParentRep { get; set; }

    [Column("url_enabled")]
    public bool UrlEnabled { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("rep_id")]
    public int RepId { get; set; }
}
