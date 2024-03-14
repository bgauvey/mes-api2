using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("oee_exec")]
public partial class OeeExec
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("job_ent_id")]
    public int JobEntId { get; set; }

    [Column("util_ent_id")]
    public int UtilEntId { get; set; }

    [Column("target_perf")]
    public double? TargetPerf { get; set; }

    [Column("current_perf")]
    public double? CurrentPerf { get; set; }

    [Column("target_qual")]
    public double? TargetQual { get; set; }

    [Column("current_qual")]
    public double? CurrentQual { get; set; }

    [Column("def_prod_rate")]
    public double? DefProdRate { get; set; }

    [Column("prod_uom")]
    public int ProdUom { get; set; }

    [Column("target_oee")]
    public double? TargetOee { get; set; }

    [Column("current_oee")]
    public double? CurrentOee { get; set; }

    [Column("basis")]
    public int Basis { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }
}
