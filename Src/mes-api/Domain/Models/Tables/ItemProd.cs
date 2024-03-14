﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("item_prod")]
public partial class ItemProd
{
    [Column("wo_id")]
    [StringLength(40)]
    public string WoId { get; set; } = null!;

    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Column("seq_no")]
    public int SeqNo { get; set; }

    [Column("shift_start_utc", TypeName = "datetime")]
    public DateTime ShiftStartUtc { get; set; }

    [Column("shift_start_local", TypeName = "datetime")]
    public DateTime ShiftStartLocal { get; set; }

    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Column("lot_no")]
    [StringLength(40)]
    public string? LotNo { get; set; }

    [Column("rm_lot_no")]
    [StringLength(40)]
    public string? RmLotNo { get; set; }

    [Column("sublot_no")]
    [StringLength(40)]
    public string? SublotNo { get; set; }

    [Column("rm_sublot_no")]
    [StringLength(40)]
    public string? RmSublotNo { get; set; }

    [Column("reas_cd")]
    public int ReasCd { get; set; }

    [Column("user_id")]
    [StringLength(40)]
    public string UserId { get; set; } = null!;

    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("shift_id")]
    public int ShiftId { get; set; }

    [Column("grade_cd")]
    public int GradeCd { get; set; }

    [Column("status_cd")]
    public int StatusCd { get; set; }

    [Column("to_ent_id")]
    public int? ToEntId { get; set; }

    [Column("good_prod")]
    public bool GoodProd { get; set; }

    [Column("qty_prod")]
    public double QtyProd { get; set; }

    [Column("qty_prod_erp")]
    public double QtyProdErp { get; set; }

    [Column("processed_flag")]
    public int ProcessedFlag { get; set; }

    [Column("byproduct")]
    public bool Byproduct { get; set; }

    [Column("ext_ref")]
    [StringLength(40)]
    public string? ExtRef { get; set; }

    [Column("move_status")]
    public int MoveStatus { get; set; }

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
    public DateTime LastEditAt { get; set; }

    [Column("created_at_utc", TypeName = "datetime")]
    public DateTime CreatedAtUtc { get; set; }

    [Column("created_at_local", TypeName = "datetime")]
    public DateTime CreatedAtLocal { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }
}
