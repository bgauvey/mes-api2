using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("ItemId", "OperId", "EntId", "VerId", "FilePath")]
[Table("folder_file")]
public partial class FolderFile
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
    [Column("file_path")]
    [StringLength(254)]
    public string FilePath { get; set; } = null!;

    [Column("file_desc")]
    [StringLength(40)]
    public string? FileDesc { get; set; }

    [Column("file_type")]
    [StringLength(20)]
    public string FileType { get; set; } = null!;

    [Column("last_modified", TypeName = "datetime")]
    public DateTime? LastModified { get; set; }

    [Column("file_size")]
    public int? FileSize { get; set; }

    [Column("author")]
    [StringLength(40)]
    public string? Author { get; set; }

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

    [ForeignKey("FileType")]
    [InverseProperty("FolderFiles")]
    public virtual DocType FileTypeNavigation { get; set; } = null!;

    [ForeignKey("ItemId, OperId, EntId, VerId")]
    [InverseProperty("FolderFiles")]
    public virtual Folder Folder { get; set; } = null!;
}
