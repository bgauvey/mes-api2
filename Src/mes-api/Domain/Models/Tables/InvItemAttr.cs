using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("inv_item_attr")]
public partial class InvItemAttr
{
    [Key]
    [Column("inv_item_item_id_h")]
    [StringLength(40)]
    public string InvItemItemIdH { get; set; } = null!;
}
