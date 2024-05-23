using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Prod;

[Table("wo")]
public partial class Wo
{
    [Key]
    [Column("wo_id")]
    [StringLength(40)]
    public string WoId { get; set; } = null!;

    [Column("wo_desc")]
    [StringLength(80)]
    public string? WoDesc { get; set; }

    [Column("process_id")]
    [StringLength(40)]
    public string? ProcessId { get; set; }

    [Column("bom_ver_id")]
    [StringLength(40)]
    public string? BomVerId { get; set; }

    [Column("spec_ver_id")]
    [StringLength(40)]
    public string? SpecVerId { get; set; }

    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Column("req_qty")]
    public double ReqQty { get; set; }

    [Column("release_time_utc", TypeName = "datetime")]
    public DateTime? ReleaseTimeUtc { get; set; }

    [Column("release_time_local", TypeName = "datetime")]
    public DateTime? ReleaseTimeLocal { get; set; }

    [Column("req_finish_time_utc", TypeName = "datetime")]
    public DateTime? ReqFinishTimeUtc { get; set; }

    [Column("req_finish_time_local", TypeName = "datetime")]
    public DateTime? ReqFinishTimeLocal { get; set; }

    [Column("state_cd")]
    public int StateCd { get; set; }

    [Column("wo_priority")]
    public int? WoPriority { get; set; }

    [Column("cust_info")]
    [StringLength(80)]
    public string? CustInfo { get; set; }

    [Column("mo_id")]
    [StringLength(40)]
    public string? MoId { get; set; }

    [Column("notes", TypeName = "ntext")]
    public string? Notes { get; set; }

    [Column("not_deletable")]
    public bool NotDeletable { get; set; }

    [Column("disassembly")]
    public bool Disassembly { get; set; }

    [Column("may_override_route")]
    public bool MayOverrideRoute { get; set; }

    [Column("override_serialization")]
    public bool OverrideSerialization { get; set; }

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

    [Column("mod_id")]
    public byte[] ModId { get; set; } = null!;

    [Column("row_id")]
    public int RowId { get; set; }
}
