using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("error_log")]
public partial class ErrorLog
{
    [Column("logged_at", TypeName = "datetime")]
    public DateTime LoggedAt { get; set; }

    [Column("severity")]
    public int Severity { get; set; }

    [Column("instance_info")]
    [StringLength(254)]
    public string? InstanceInfo { get; set; }

    [Column("object_name")]
    [StringLength(80)]
    public string ObjectName { get; set; } = null!;

    [Column("object_section")]
    [StringLength(80)]
    public string ObjectSection { get; set; } = null!;

    [Column("description")]
    [StringLength(254)]
    public string Description { get; set; } = null!;

    [Column("system_msg", TypeName = "ntext")]
    public string? SystemMsg { get; set; }

    [Key]
    [Column("log_id")]
    public int LogId { get; set; }
}
