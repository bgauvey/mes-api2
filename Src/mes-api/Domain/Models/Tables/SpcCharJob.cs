using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("spc_char_job")]
public partial class SpcCharJob
{
    [Column("wo_id")]
    [StringLength(40)]
    public string WoId { get; set; } = null!;

    [Column("oper_id")]
    [StringLength(40)]
    public string OperId { get; set; } = null!;

    [Column("seq_no")]
    public int SeqNo { get; set; }

    [Column("step_no")]
    public int StepNo { get; set; }

    [Column("char_id")]
    public int CharId { get; set; }

    [Column("char_name")]
    [StringLength(40)]
    public string CharName { get; set; } = null!;

    [Column("ver_id")]
    [StringLength(40)]
    public string VerId { get; set; } = null!;

    [Column("lvl")]
    public double? Lvl { get; set; }

    [Column("uvl")]
    public double? Uvl { get; set; }

    [Column("lcl")]
    public double? Lcl { get; set; }

    [Column("ucl")]
    public double? Ucl { get; set; }

    [Column("lsl")]
    public double? Lsl { get; set; }

    [Column("usl")]
    public double? Usl { get; set; }

    [Column("lrl")]
    public double? Lrl { get; set; }

    [Column("url")]
    public double? Url { get; set; }

    [Column("target_v")]
    public double? TargetV { get; set; }

    [Column("target_rs")]
    public double? TargetRs { get; set; }

    [Column("lcpk")]
    public double? Lcpk { get; set; }

    [Column("ucpk")]
    public double? Ucpk { get; set; }

    [Column("est_sigma")]
    public bool EstSigma { get; set; }

    [Column("units")]
    [StringLength(40)]
    public string? Units { get; set; }

    [Column("decimals")]
    public int Decimals { get; set; }

    [Column("prefill")]
    [StringLength(20)]
    public string? Prefill { get; set; }

    [Column("meas_desc", TypeName = "ntext")]
    public string? MeasDesc { get; set; }

    [Column("assoc_file")]
    [StringLength(254)]
    public string? AssocFile { get; set; }

    [Column("assoc_file_type")]
    [StringLength(20)]
    public string? AssocFileType { get; set; }

    [Column("note_ok")]
    public bool NoteOk { get; set; }

    [Column("samp_int")]
    public double SampInt { get; set; }

    [Column("samp_mins")]
    public bool SampMins { get; set; }

    [Column("samp_size")]
    public int SampSize { get; set; }

    [Column("recalc")]
    public int Recalc { get; set; }

    [Column("cost")]
    public double Cost { get; set; }

    [Column("run_chart")]
    public int RunChart { get; set; }

    [Column("variable")]
    public bool Variable { get; set; }

    [Column("counted")]
    public bool Counted { get; set; }

    [Column("ind_lots")]
    public bool IndLots { get; set; }

    [Column("keyboard")]
    public bool Keyboard { get; set; }

    [Column("gage_cfg")]
    [StringLength(40)]
    public string? GageCfg { get; set; }

    [Column("channel")]
    public int? Channel { get; set; }

    [Column("grp_id")]
    public int GrpId { get; set; }

    [Column("sequence")]
    public int Sequence { get; set; }

    [Column("grp_seq")]
    public int GrpSeq { get; set; }

    [Column("last_prod")]
    public double LastProd { get; set; }

    [Column("value_tag_desc")]
    [StringLength(254)]
    public string? ValueTagDesc { get; set; }

    [Column("int_trigger")]
    public int IntTrigger { get; set; }

    [Column("nview")]
    public int Nview { get; set; }

    [Column("trg_tag_desc")]
    [StringLength(254)]
    public string? TrgTagDesc { get; set; }

    [Column("trg_tag_value")]
    [StringLength(254)]
    public string? TrgTagValue { get; set; }

    [Column("last_edit_comment")]
    [StringLength(254)]
    public string? LastEditComment { get; set; }

    [Column("last_edit_by")]
    [StringLength(40)]
    public string LastEditBy { get; set; } = null!;

    [Column("created_by")]
    [StringLength(40)]
    public string CreatedBy { get; set; } = null!;

    [Column("last_edit_at", TypeName = "datetime")]
    public DateTime LastEditAt { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Key]
    [Column("row_id")]
    public int RowId { get; set; }
}
