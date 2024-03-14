using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[PrimaryKey("EntId", "JobPos")]
[Table("job_exec")]
public partial class JobExec
{
    [Key]
    [Column("ent_id")]
    public int EntId { get; set; }

    [Key]
    [Column("job_pos")]
    public int JobPos { get; set; }

    [Column("next_job_only")]
    public bool NextJobOnly { get; set; }

    [Column("item_based_desc")]
    public bool ItemBasedDesc { get; set; }

    [Column("job_end_confirm_msg")]
    [StringLength(80)]
    public string? JobEndConfirmMsg { get; set; }

    [Column("def_to_ent_id")]
    public int? DefToEntId { get; set; }

    [Column("def_reject_ent_id")]
    public int? DefRejectEntId { get; set; }

    [Column("def_from_ent_id")]
    public int? DefFromEntId { get; set; }

    [Column("def_prod_reas_cd")]
    public int DefProdReasCd { get; set; }

    [Column("def_cons_reas_cd")]
    public int? DefConsReasCd { get; set; }

    [Column("def_lot_no")]
    [StringLength(40)]
    public string? DefLotNo { get; set; }

    [Column("def_sublot_no")]
    [StringLength(40)]
    public string? DefSublotNo { get; set; }

    [Column("autoload_job_specs")]
    public bool AutoloadJobSpecs { get; set; }

    [Column("auto_seq_start_option")]
    public int AutoSeqStartOption { get; set; }

    [Column("auto_job_start_option")]
    public int AutoJobStartOption { get; set; }

    [Column("auto_job_end_option")]
    public int AutoJobEndOption { get; set; }

    [Column("incl_class_reas")]
    public bool InclClassReas { get; set; }

    [Column("must_complete_steps")]
    public bool MustCompleteSteps { get; set; }

    [Column("must_prod_reqd_qty")]
    public bool MustProdReqdQty { get; set; }

    [Column("local_movable_cons_ent")]
    public bool LocalMovableConsEnt { get; set; }

    [Column("local_movable_prod_ent")]
    public bool LocalMovableProdEnt { get; set; }

    [Column("run_without_operator")]
    public bool RunWithoutOperator { get; set; }

    [Column("apply_post_exec_fc_counts")]
    public bool ApplyPostExecFcCounts { get; set; }

    [Column("suppress_start_qty_prompt")]
    public bool SuppressStartQtyPrompt { get; set; }

    [Column("allow_zero_qty_split")]
    public bool AllowZeroQtySplit { get; set; }

    [Column("auto_alloc_qty_to_running_job")]
    public bool AutoAllocQtyToRunningJob { get; set; }

    [Column("cur_wo_id")]
    [StringLength(40)]
    public string? CurWoId { get; set; }

    [Column("cur_oper_id")]
    [StringLength(40)]
    public string? CurOperId { get; set; }

    [Column("cur_seq_no")]
    public int? CurSeqNo { get; set; }

    [Column("cur_step_no")]
    public int? CurStepNo { get; set; }

    [Column("cur_step_start", TypeName = "datetime")]
    public DateTime? CurStepStart { get; set; }

    [Column("spare1")]
    [StringLength(1000)]
    public string? Spare1 { get; set; }

    [Column("spare2")]
    [StringLength(1000)]
    public string? Spare2 { get; set; }

    [Column("spare3")]
    [StringLength(1000)]
    public string? Spare3 { get; set; }

    [Column("spare4")]
    [StringLength(1000)]
    public string? Spare4 { get; set; }

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
}
