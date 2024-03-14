using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ItemId", "OperId", "EntId", "VerId")]
[Table("folder")]
public partial class Folder
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

    [Column("oper_desc")]
    [StringLength(80)]
    public string? OperDesc { get; set; }

    [Column("notes", TypeName = "ntext")]
    public string? Notes { get; set; }

    [Column("udf1")]
    [StringLength(40)]
    public string? Udf1 { get; set; }

    [Column("udf2")]
    [StringLength(40)]
    public string? Udf2 { get; set; }

    [Column("preferred_ver")]
    public bool PreferredVer { get; set; }

    [Column("design_hold")]
    public bool DesignHold { get; set; }

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

    [InverseProperty("Folder")]
    public virtual ICollection<FolderDistr> FolderDistrs { get; set; } = new List<FolderDistr>();

    [InverseProperty("Folder")]
    public virtual ICollection<FolderFile> FolderFiles { get; set; } = new List<FolderFile>();

    [InverseProperty("Folder")]
    public virtual ICollection<FolderItemOperEntLink> FolderItemOperEntLinks { get; set; } = new List<FolderItemOperEntLink>();
}
