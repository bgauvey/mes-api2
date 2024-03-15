using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("storage_ent_transfer")]
public partial class StorageEntTransfer
{
    [Column("ent_id")]
    public int EntId { get; set; }

    [Column("to_storage_ent_id")]
    public int? ToStorageEntId { get; set; }

    [Column("to_status")]
    public int? ToStatus { get; set; }

    [Column("to_spare1")]
    [StringLength(1000)]
    public string? ToSpare1 { get; set; }

    [Column("to_spare2")]
    [StringLength(1000)]
    public string? ToSpare2 { get; set; }

    [Column("to_spare3")]
    [StringLength(1000)]
    public string? ToSpare3 { get; set; }

    [Column("to_spare4")]
    [StringLength(1000)]
    public string? ToSpare4 { get; set; }

    [Column("to_spare_int1")]
    public int? ToSpareInt1 { get; set; }

    [Column("to_spare_int2")]
    public int? ToSpareInt2 { get; set; }

    [Column("to_spare_int3")]
    public int? ToSpareInt3 { get; set; }

    [Column("to_spare_int4")]
    public int? ToSpareInt4 { get; set; }

    [Column("from_storage_ent_id")]
    public int? FromStorageEntId { get; set; }

    [Column("from_status")]
    public int? FromStatus { get; set; }

    [Column("from_spare1")]
    [StringLength(1000)]
    public string? FromSpare1 { get; set; }

    [Column("from_spare2")]
    [StringLength(1000)]
    public string? FromSpare2 { get; set; }

    [Column("from_spare3")]
    [StringLength(1000)]
    public string? FromSpare3 { get; set; }

    [Column("from_spare4")]
    [StringLength(1000)]
    public string? FromSpare4 { get; set; }

    [Column("from_spare_int1")]
    public int? FromSpareInt1 { get; set; }

    [Column("from_spare_int2")]
    public int? FromSpareInt2 { get; set; }

    [Column("from_spare_int3")]
    public int? FromSpareInt3 { get; set; }

    [Column("from_spare_int4")]
    public int? FromSpareInt4 { get; set; }

    [Column("comments")]
    [StringLength(254)]
    public string? Comments { get; set; }

    [Column("transfer_by")]
    [StringLength(40)]
    public string TransferBy { get; set; } = null!;

    [Column("transfer_time_utc", TypeName = "datetime")]
    public DateTime TransferTimeUtc { get; set; }

    [Column("transfer_time_local", TypeName = "datetime")]
    public DateTime TransferTimeLocal { get; set; }

    [Key]
    [Column("trans_id")]
    public int TransId { get; set; }
}
