using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("InvLotItemIdH", "InvLotLotNoH")]
[Table("inv_lot_attr")]
public partial class InvLotAttr
{
    [Key]
    [Column("inv_lot_item_id_h")]
    [StringLength(40)]
    public string InvLotItemIdH { get; set; } = null!;

    [Key]
    [Column("inv_lot_lot_no_h")]
    [StringLength(40)]
    public string InvLotLotNoH { get; set; } = null!;

    [ForeignKey("InvLotItemIdH, InvLotLotNoH")]
    [InverseProperty("InvLotAttr")]
    public virtual Lot Lot { get; set; } = null!;
}
