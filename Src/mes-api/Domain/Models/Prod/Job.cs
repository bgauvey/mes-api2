using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Domain.Models.Prod;

[PrimaryKey("WoId", "OperId", "SeqNo")]
[Table("job")]
public partial class Job
{
    [Key]
    [Column("wo_id")]
    [StringLength(40)]
    public string WoId { get; set; } = null!;

    [Key]
    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Key]
    [Column("seq_no")]
    public int SeqNo { get; set; }

    [Column("job_desc")]
    [StringLength(80)]
    public string? JobDesc { get; set; }

    [Column("item_id")]
    [StringLength(40)]
    public string ItemId { get; set; } = null!;

    [Column("state_cd")]
    public int StateCd { get; set; }

    [Column("job_priority")]
    public int JobPriority { get; set; }

    [Column("req_finish_time_utc", TypeName = "datetime")]
    public DateTime? ReqFinishTimeUtc { get; set; }

    [Column("req_finish_time_local", TypeName = "datetime")]
    public DateTime? ReqFinishTimeLocal { get; set; }

    [Column("init_sched_ent_id")]
    public int InitSchedEntId { get; set; }

    [Column("target_sched_ent_id")]
    public int TargetSchedEntId { get; set; }

    [Column("run_ent_id")]
    public int? RunEntId { get; set; }

    [Column("qty_reqd")]
    public double QtyReqd { get; set; }

    [Column("qty_prod")]
    public double QtyProd { get; set; }

    [Column("qty_prod_erp")]
    public double? QtyProdErp { get; set; }

    [Column("qty_rejected")]
    public double QtyRejected { get; set; }

    [Column("qty_rejected_erp")]
    public double? QtyRejectedErp { get; set; }

    [Column("qty_at_start")]
    public double QtyAtStart { get; set; }

    [Column("deviation_above")]
    public double DeviationAbove { get; set; }

    [Column("deviation_below")]
    public double DeviationBelow { get; set; }

    [Column("batch_size")]
    public double BatchSize { get; set; }

    [Column("first_job")]
    public bool FirstJob { get; set; }

    [Column("final_job")]
    public bool FinalJob { get; set; }

    [Column("sched_pinned")]
    public bool SchedPinned { get; set; }

    [Column("check_inv")]
    public bool CheckInv { get; set; }

    [Column("est_fixed_lab")]
    public double? EstFixedLab { get; set; }

    [Column("est_lab_rate")]
    public double? EstLabRate { get; set; }

    [Column("est_setup_time")]
    public double? EstSetupTime { get; set; }

    [Column("est_teardown_time")]
    public double? EstTeardownTime { get; set; }

    [Column("est_prod_rate")]
    public double EstProdRate { get; set; }

    [Column("prod_uom")]
    public int ProdUom { get; set; }

    [Column("est_transfer_time")]
    public double? EstTransferTime { get; set; }

    [Column("sched_start_time_utc", TypeName = "datetime")]
    public DateTime? SchedStartTimeUtc { get; set; }

    [Column("sched_start_time_local", TypeName = "datetime")]
    public DateTime? SchedStartTimeLocal { get; set; }

    [Column("latest_start_time_utc", TypeName = "datetime")]
    public DateTime? LatestStartTimeUtc { get; set; }

    [Column("latest_start_time_local", TypeName = "datetime")]
    public DateTime? LatestStartTimeLocal { get; set; }

    [Column("sched_finish_time_utc", TypeName = "datetime")]
    public DateTime? SchedFinishTimeUtc { get; set; }

    [Column("sched_finish_time_local", TypeName = "datetime")]
    public DateTime? SchedFinishTimeLocal { get; set; }

    [Column("act_start_time_utc", TypeName = "datetime")]
    public DateTime? ActStartTimeUtc { get; set; }

    [Column("act_start_time_local", TypeName = "datetime")]
    public DateTime? ActStartTimeLocal { get; set; }

    [Column("act_finish_time_utc", TypeName = "datetime")]
    public DateTime? ActFinishTimeUtc { get; set; }

    [Column("act_finish_time_local", TypeName = "datetime")]
    public DateTime? ActFinishTimeLocal { get; set; }

    [Column("concurrent_link")]
    public int ConcurrentLink { get; set; }

    [Column("job_cost")]
    public double? JobCost { get; set; }

    [Column("parent_contingent_job")]
    public bool ParentContingentJob { get; set; }

    [Column("child_contingent_job")]
    public bool ChildContingentJob { get; set; }

    [Column("notes", TypeName = "ntext")]
    public string? Notes { get; set; }

    [Column("assoc_file")]
    [StringLength(254)]
    public string? AssocFile { get; set; }

    [Column("assoc_file_type")]
    [StringLength(20)]
    public string? AssocFileType { get; set; }

    [Column("status_notes")]
    [StringLength(1700)]
    public string? StatusNotes { get; set; }

    [Column("display_seq")]
    public int DisplaySeq { get; set; }

    [Column("folder_ver_id")]
    [StringLength(40)]
    public string? FolderVerId { get; set; }

    [Column("rework")]
    public bool Rework { get; set; }

    [Column("rework_cd")]
    [StringLength(40)]
    public string? ReworkCd { get; set; }

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

    [Column("edited_by")]
    [StringLength(40)]
    public string? EditedBy { get; set; }

    [Column("edit_time", TypeName = "datetime")]
    public DateTime EditTime { get; set; }

    [Column("row_id")]
    public int RowId { get; set; }
}
