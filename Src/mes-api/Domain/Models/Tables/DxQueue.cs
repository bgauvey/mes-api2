using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("dx_queue")]
public partial class DxQueue
{
    [Column("activity_type")]
    public int ActivityType { get; set; }

    [Column("details")]
    [StringLength(4000)]
    public string Details { get; set; } = null!;

    [Column("inserted_at", TypeName = "datetime")]
    public DateTime InsertedAt { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }
}
