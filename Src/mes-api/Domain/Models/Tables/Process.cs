using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("process")]
public partial class Process
{
    [Key]
    [Column("process_id")]
    [StringLength(40)]
    public string ProcessId { get; set; } = null!;

    [Column("process_class_id")]
    [StringLength(40)]
    public string ProcessClassId { get; set; } = null!;

    [Column("process_ver_id")]
    [StringLength(40)]
    public string ProcessVerId { get; set; } = null!;

    [Column("process_desc")]
    [StringLength(80)]
    public string ProcessDesc { get; set; } = null!;

    [Column("process_level")]
    public int ProcessLevel { get; set; }

    [Column("process_status")]
    public int ProcessStatus { get; set; }

    [Column("creator")]
    [StringLength(40)]
    public string Creator { get; set; } = null!;

    [Column("approver")]
    [StringLength(40)]
    public string? Approver { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("last_user_to_change_status")]
    [StringLength(40)]
    public string? LastUserToChangeStatus { get; set; }

    [Column("last_status_change_at", TypeName = "datetime")]
    public DateTime? LastStatusChangeAt { get; set; }

    [Column("checked_out_by")]
    [StringLength(40)]
    public string? CheckedOutBy { get; set; }

    [Column("last_instantiated", TypeName = "datetime")]
    public DateTime? LastInstantiated { get; set; }

    [Column("disassembly")]
    public bool Disassembly { get; set; }

    [Column("may_override_route")]
    public bool MayOverrideRoute { get; set; }

    [Column("rework")]
    public bool Rework { get; set; }

    [Column("notes", TypeName = "ntext")]
    public string? Notes { get; set; }

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

    [Column("last_editor")]
    [StringLength(40)]
    public string LastEditor { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("mod_id")]
    public byte[] ModId { get; set; } = null!;

    [Column("row_id")]
    public int RowId { get; set; }

    [InverseProperty("Process")]
    public virtual ICollection<ItemProcessLink> ItemProcessLinks { get; set; } = new List<ItemProcessLink>();

    [InverseProperty("Process")]
    public virtual ICollection<Oper> Opers { get; set; } = new List<Oper>();

    [InverseProperty("Process")]
    public virtual ICollection<ProcessAttr> ProcessAttrs { get; set; } = new List<ProcessAttr>();

    [ForeignKey("ProcessClassId")]
    [InverseProperty("Processes")]
    public virtual ProcessClass ProcessClass { get; set; } = null!;
}
