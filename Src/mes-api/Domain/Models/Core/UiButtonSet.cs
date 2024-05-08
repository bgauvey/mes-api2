using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Core;

[PrimaryKey("Screen", "ButtonId")]
[Table("ui_button_set")]
public partial class UiButtonSet
{
    [Key]
    [Column("screen")]
    [StringLength(40)]
    public string Screen { get; set; } = null!;

    [Key]
    [Column("button_id")]
    public int ButtonId { get; set; }

    [Column("display_seq")]
    public int DisplaySeq { get; set; }

    [Column("incl_by_default")]
    public bool InclByDefault { get; set; }
}
