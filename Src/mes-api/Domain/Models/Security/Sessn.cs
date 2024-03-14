using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Security;

[Table("sessn")]
public partial class Sessn
{
    [Column("client_type")]
    public int ClientType { get; set; }

    [Column("session_start", TypeName = "datetime")]
    public DateTime SessionStart { get; set; }

    [Column("last_heartbeat", TypeName = "datetime")]
    public DateTime LastHeartbeat { get; set; }

    [Column("user_id")]
    [StringLength(40)]
    public string? UserId { get; set; }

    [Column("client_address")]
    [StringLength(40)]
    public string? ClientAddress { get; set; }

    [Column("reqd_events")]
    [StringLength(1700)]
    public string? ReqdEvents { get; set; }

    [Column("tz_bias")]
    public int TzBias { get; set; }

    [Column("std_time")]
    public bool StdTime { get; set; }

    [Key]
    [Column("session_id")]
    public int SessionId { get; set; }
}
