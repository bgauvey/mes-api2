using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("spc_stats")]
public partial class SpcStat
{
    [Key]
    [Column("row_id")]
    public int RowId { get; set; }

    [Column("x_bar")]
    public double? XBar { get; set; }

    [Column("x_dbar")]
    public double? XDbar { get; set; }

    [Column("r_bar")]
    public double? RBar { get; set; }

    [Column("s_bar")]
    public double? SBar { get; set; }

    [Column("sigma")]
    public double? Sigma { get; set; }

    [Column("e_sigma")]
    public double? ESigma { get; set; }

    [Column("min_valu")]
    public double? MinValu { get; set; }

    [Column("max_valu")]
    public double? MaxValu { get; set; }

    [Column("x_1")]
    public double? X1 { get; set; }

    [Column("x_99")]
    public double? X99 { get; set; }

    [Column("z_lsl")]
    public double? ZLsl { get; set; }

    [Column("z_usl")]
    public double? ZUsl { get; set; }

    [Column("cp")]
    public double? Cp { get; set; }

    [Column("cpk")]
    public double? Cpk { get; set; }

    [Column("pp")]
    public double? Pp { get; set; }

    [Column("ppk")]
    public double? Ppk { get; set; }

    [Column("pos_actual")]
    public double? PosActual { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [ForeignKey("RowId")]
    [InverseProperty("SpcStat")]
    public virtual SpcCharJob Row { get; set; } = null!;
}
