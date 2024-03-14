using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ProcessId", "OperId", "EntId", "ItemId")]
[Table("folder_item_oper_ent_link")]
public partial class FolderItemOperEntLink
{
    [Key]
    [Column("process_id")]
    [StringLength(40)]
    public string ProcessId { get; set; } = null!;

    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Column("ver_id")]
    [StringLength(40)]
    public string VerId { get; set; } = null!;

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string? LastEditBy { get; set; }

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("row_id")]
    public int RowId { get; set; }

    [ForeignKey("ItemId, OperId, EntId, VerId")]
    [InverseProperty("FolderItemOperEntLinks")]
    public virtual Folder Folder { get; set; } = null!;

    [ForeignKey("ProcessId, OperId, EntId")]
    [InverseProperty("FolderItemOperEntLinks")]
    public virtual OperEntLink OperEntLink { get; set; } = null!;
}
