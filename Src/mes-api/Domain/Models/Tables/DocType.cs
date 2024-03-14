using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("doc_type")]
public partial class DocType
{
    [Key]
    [Column("doc_type")]
    [StringLength(20)]
    public string DocType1 { get; set; } = null!;

    [Column("descrip")]
    [StringLength(40)]
    public string Descrip { get; set; } = null!;

    [Column("viewer")]
    public int? Viewer { get; set; }

    [Column("editor")]
    public int? Editor { get; set; }

    [Column("edit_level")]
    public int EditLevel { get; set; }

    [Column("download")]
    public int Download { get; set; }

    [Column("down_level")]
    public int DownLevel { get; set; }

    [Column("view_level")]
    public int ViewLevel { get; set; }

    [Column("print_level")]
    public int PrintLevel { get; set; }

    [Column("url")]
    public bool Url { get; set; }

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

    [InverseProperty("AssocFileTypeNavigation")]
    public virtual ICollection<BomItemOperSpec> BomItemOperSpecs { get; set; } = new List<BomItemOperSpec>();

    [InverseProperty("DocTypeNavigation")]
    public virtual ICollection<FileDesc> FileDescs { get; set; } = new List<FileDesc>();

    [InverseProperty("DocTypeNavigation")]
    public virtual ICollection<FileType> FileTypes { get; set; } = new List<FileType>();

    [InverseProperty("FileTypeNavigation")]
    public virtual ICollection<FolderFile> FolderFiles { get; set; } = new List<FolderFile>();

    [InverseProperty("FileTypeNavigation")]
    public virtual ICollection<ItemFile> ItemFiles { get; set; } = new List<ItemFile>();

    [InverseProperty("AssocFileTypeNavigation")]
    public virtual ICollection<JobStepFile> JobStepFiles { get; set; } = new List<JobStepFile>();

    [InverseProperty("AssocFileTypeNavigation")]
    public virtual ICollection<OperEntSpec> OperEntSpecs { get; set; } = new List<OperEntSpec>();

    [InverseProperty("AssocFileTypeNavigation")]
    public virtual ICollection<OperStepFile> OperStepFiles { get; set; } = new List<OperStepFile>();

    [InverseProperty("AssocFileTypeNavigation")]
    public virtual ICollection<Oper> Opers { get; set; } = new List<Oper>();

    [InverseProperty("AssocFileTypeNavigation")]
    public virtual ICollection<SpcCharJob> SpcCharJobs { get; set; } = new List<SpcCharJob>();

    [InverseProperty("AssocFileTypeNavigation")]
    public virtual ICollection<SpcChar> SpcChars { get; set; } = new List<SpcChar>();

    [InverseProperty("AssocFileTypeNavigation")]
    public virtual ICollection<StdOperEntSpec> StdOperEntSpecs { get; set; } = new List<StdOperEntSpec>();

    [InverseProperty("AssocFileTypeNavigation")]
    public virtual ICollection<StdOperStepFile> StdOperStepFiles { get; set; } = new List<StdOperStepFile>();

    [InverseProperty("AssocFileTypeNavigation")]
    public virtual ICollection<StdOper> StdOpers { get; set; } = new List<StdOper>();

    [InverseProperty("FileTypeNavigation")]
    public virtual ICollection<WoFile> WoFiles { get; set; } = new List<WoFile>();
}
