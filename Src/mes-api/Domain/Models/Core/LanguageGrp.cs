using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[Table("language_grp")]
public partial class LanguageGrp
{
    [Key]
    [Column("grp_id")]
    public int GrpId { get; set; }

    [Column("grp_desc")]
    [StringLength(80)]
    public string GrpDesc { get; set; } = null!;

    [Column("grp_seq")]
    public int GrpSeq { get; set; }
}
