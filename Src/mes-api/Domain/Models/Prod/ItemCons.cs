using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.API.Domain.Models.Prod
{

    [Table("item_cons")]
    public partial class ItemCons
    {
        [Column("wo_id")]
        [StringLength(40)]
        public string? WoId { get; set; }

        [Column("oper_id")]
        [StringLength(40)]
        public string? OperId { get; set; }

        [Column("seq_no")]
        public int? SeqNo { get; set; }

        [Column("shift_start_utc", TypeName = "datetime")]
        public DateTime? ShiftStartUtc { get; set; }

        [Column("shift_start_local", TypeName = "datetime")]
        public DateTime? ShiftStartLocal { get; set; }

        [Column("item_id")]
        [StringLength(40)]
        public string ItemId { get; set; } = null!;

        [Column("lot_no")]
        [StringLength(40)]
        public string? LotNo { get; set; }

        [Column("fg_lot_no")]
        [StringLength(40)]
        public string? FgLotNo { get; set; }

        [Column("sublot_no")]
        [StringLength(40)]
        public string? SublotNo { get; set; }

        [Column("fg_sublot_no")]
        [StringLength(40)]
        public string? FgSublotNo { get; set; }

        [Column("reas_cd")]
        public int? ReasCd { get; set; }

        [Column("user_id")]
        [StringLength(40)]
        public string UserId { get; set; } = null!;

        [Column("item_scrapped")]
        public bool ItemScrapped { get; set; }

        [Column("ent_id")]
        public int? EntId { get; set; }

        [Column("shift_id")]
        public int? ShiftId { get; set; }

        [Column("grade_cd")]
        public int GradeCd { get; set; }

        [Column("status_cd")]
        public int StatusCd { get; set; }

        [Column("from_ent_id")]
        public int? FromEntId { get; set; }

        [Column("qty_cons")]
        public double QtyCons { get; set; }

        [Column("qty_cons_erp")]
        public double QtyConsErp { get; set; }

        [Column("ext_ref")]
        [StringLength(40)]
        public string? ExtRef { get; set; }

        [Column("transaction_type")]
        public int TransactionType { get; set; }

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

        [Column("created_at_utc", TypeName = "datetime")]
        public DateTime CreatedAtUtc { get; set; }

        [Column("created_at_local", TypeName = "datetime")]
        public DateTime CreatedAtLocal { get; set; }

        [Key]
        [Column("row_id")]
        public int RowId { get; set; }
    }
}