using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("data_entry_log")]
public partial class DataEntryLog
{
    [Column("key_id")]
    public int KeyId { get; set; }

    [Column("key_type")]
    public int KeyType { get; set; }

    [Column("category")]
    [StringLength(40)]
    public string Category { get; set; } = null!;

    [Column("value_name")]
    [StringLength(40)]
    public string ValueName { get; set; } = null!;

    [Column("trigger_at_utc", TypeName = "datetime")]
    public DateTime TriggerAtUtc { get; set; }

    [Column("trigger_at_local", TypeName = "datetime")]
    public DateTime TriggerAtLocal { get; set; }

    [Column("entries_reqd")]
    public int EntriesReqd { get; set; }

    [Column("entries_made")]
    public int EntriesMade { get; set; }

    [Column("display_seq")]
    public int? DisplaySeq { get; set; }

    [Column("trigger_desc")]
    [StringLength(40)]
    public string? TriggerDesc { get; set; }

    [Column("string_spare1")]
    [StringLength(40)]
    public string? StringSpare1 { get; set; }

    [Column("string_spare2")]
    [StringLength(40)]
    public string? StringSpare2 { get; set; }

    [Column("string_spare3")]
    [StringLength(40)]
    public string? StringSpare3 { get; set; }

    [Column("string_spare4")]
    [StringLength(40)]
    public string? StringSpare4 { get; set; }

    [Column("number_spare1")]
    public double? NumberSpare1 { get; set; }

    [Column("number_spare2")]
    public double? NumberSpare2 { get; set; }

    [Column("number_spare3")]
    public double? NumberSpare3 { get; set; }

    [Column("number_spare4")]
    public double? NumberSpare4 { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }
}
