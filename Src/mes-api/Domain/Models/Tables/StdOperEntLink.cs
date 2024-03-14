﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("OperId", "EntId")]
[Table("std_oper_ent_link")]
public partial class StdOperEntLink
{
    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("est_fixed_lab")]
    public double? EstFixedLab { get; set; }

    [Column("est_lab_rate")]
    public double? EstLabRate { get; set; }

    [Column("est_setup_time")]
    public double? EstSetupTime { get; set; }

    [Column("est_teardown_time")]
    public double? EstTeardownTime { get; set; }

    [Column("est_prod_rate")]
    public double EstProdRate { get; set; }

    [Column("prod_uom")]
    public int ProdUom { get; set; }

    [Column("batch_size")]
    public double BatchSize { get; set; }

    [Column("est_transfer_time")]
    public double? EstTransferTime { get; set; }

    [Column("init_prod_pct")]
    public double? InitProdPct { get; set; }

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

    [ForeignKey("EntId")]
    [InverseProperty("StdOperEntLinks")]
    public virtual JobSchedExec Ent { get; set; } = null!;

    [ForeignKey("OperId")]
    [InverseProperty("StdOperEntLinks")]
    public virtual StdOper Oper { get; set; } = null!;

    [InverseProperty("StdOperEntLink")]
    public virtual ICollection<StdOperEntSpec> StdOperEntSpecs { get; set; } = new List<StdOperEntSpec>();
}
