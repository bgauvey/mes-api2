using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ItemId", "OperId", "EntId", "VerId", "DownlDir")]
[Table("folder_distr")]
public partial class FolderDistr
{
    [Key]
    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("ver_id")]
    [StringLength(40)]
    public string VerId { get; set; } = null!;

    [Key]
    [Column("downl_dir")]
    [StringLength(254)]
    public string DownlDir { get; set; } = null!;

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

    [ForeignKey("ItemId, OperId, EntId, VerId")]
    [InverseProperty("FolderDistrs")]
    public virtual Folder Folder { get; set; } = null!;
}
