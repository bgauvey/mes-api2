using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[Table("ui_button")]
public partial class UiButton
{
    [Key]
    [Column("button_id")]
    public int ButtonId { get; set; }

    [Column("button_desc")]
    [StringLength(40)]
    public string ButtonDesc { get; set; } = null!;

    [Column("tooltip")]
    [StringLength(254)]
    public string Tooltip { get; set; } = null!;

    [Column("def_enabled_img")]
    [StringLength(80)]
    public string DefEnabledImg { get; set; } = null!;

    [Column("def_disabled_img")]
    [StringLength(80)]
    public string? DefDisabledImg { get; set; }

    [Column("param_desc")]
    [StringLength(254)]
    public string? ParamDesc { get; set; }

    [Column("def_param")]
    [StringLength(80)]
    public string? DefParam { get; set; }

    [Column("config_help")]
    [StringLength(254)]
    public string? ConfigHelp { get; set; }

    [Column("dest_option")]
    [StringLength(254)]
    public string? DestOption { get; set; }

    [Column("spare1")]
    [StringLength(80)]
    public string? Spare1 { get; set; }

    [Column("spare2")]
    [StringLength(80)]
    public string? Spare2 { get; set; }

    [Column("spare3")]
    [StringLength(80)]
    public string? Spare3 { get; set; }

    [Column("spare4")]
    [StringLength(80)]
    public string? Spare4 { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime? LastEditAt { get; set; }
}
