using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("oper_type")]
public partial class OperType
{
    [Key]
    [Column("oper_type")]
    [StringLength(80)]
    public string OperType1 { get; set; } = null!;

    [Column("oper_type_desc")]
    [StringLength(80)]
    public string? OperTypeDesc { get; set; }

    [Column("est_fixed_lab")]
    public double? EstFixedLab { get; set; }

    [Column("est_lab_rate")]
    public double? EstLabRate { get; set; }

    [Column("est_setup_time")]
    public double? EstSetupTime { get; set; }

    [Column("est_teardown_time")]
    public double? EstTeardownTime { get; set; }

    [Column("est_prod_rate")]
    public double? EstProdRate { get; set; }

    [Column("prod_uom")]
    public int ProdUom { get; set; }

    [Column("batch_size")]
    public double? BatchSize { get; set; }

    [Column("est_transfer_time")]
    public double? EstTransferTime { get; set; }

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
