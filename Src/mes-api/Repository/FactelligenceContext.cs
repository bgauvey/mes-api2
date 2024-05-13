//
// FactelligenceContext.cs
//
// Author:
//       Bill Gauvey <Bill.Gauvey@barretteoutdoorliving.com>
//
// Copyright (c) 2024 Barrette Outdoor Living
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using BOL.API.Domain.Models.Core;
using BOL.API.Domain.Models.EnProd;
using BOL.API.Domain.Models.Prod;
using BOL.API.Domain.Models.Security;
using BOL.API.Domain.Models.Util;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Repository;

public class FactelligenceContext : DbContext
{
    #region Models
    //Core Models
    public DbSet<Attr> Attrs { get; set; }
    public DbSet<AttrSet> AttrSets { get; set; }
    public DbSet<Ent> Ents { get; set; }
    public DbSet<EntAttr> EntAttrs { get; set; }
    public DbSet<EntFile> EntFiles { get; set; }
    public DbSet<EntLink> EntLinks { get; set; }
    public DbSet<FileType> FileTypes { get; set; }
    public DbSet<FileDesc> FileDescs { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageGrp> LanguageGrps { get; set; }
    public DbSet<MgrDataConfig> MgrDataConfigs { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<SystemAttr> SystemAttrs { get; set; }
    public DbSet<SystemAttrGrp> SystemAttrGrps { get; set; }
    public DbSet<UiButton> UiButtons { get; set; }
    public DbSet<UiButtonSet> UiButtonSets { get; set; }
    public DbSet<UiConfig> UiConfigs { get; set; }
    public DbSet<UiConfigDefault> UiConfigDefaults { get; set; }

    // EnProd Models
    public DbSet<ItemInv> ItemInvs { get; set; }
    public DbSet<JobSpec> JobSpecs { get; set; }
    public DbSet<JobStep> JobSteps { get; set; }
    public DbSet<StorageExec> StorageExecs { get; set; }

    //Prod Models
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemAttr> ItemAttrs { get; set; }
    public DbSet<ItemCons> ItemConumptions { get; set; }
    public DbSet<ItemFile> ItemFiles { get; set; }
    public DbSet<ItemProd> ItemProds { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobEvent> JobEvents { get; set; }
    public DbSet<JobExec> JobExecs { get; set; }

    // Security Models
    public DbSet<EntLogon> EntLogons { get; set; }
    public DbSet<EntLogonList> EntLogonLists { get; set; }
    public DbSet<GrpEntLink> GrpEntLinks { get; set; }
    public DbSet<GrpName> GrpNames { get; set; }
    public DbSet<GrpPrivLink> GrpPrivLinks { get; set; }
    public DbSet<Priv> Privileges { get; set; }
    public DbSet<Sessn> Sessions { get; set; }
    public DbSet<UserGrpLink> UserGrpLinks { get; set; }
    public DbSet<UserName> UserNames { get; set; }

    //Util Models
    public DbSet<UtilExec> UtilExecs { get; set; }
    public DbSet<UtilLog> UtilLogs { get; set; }
    public DbSet<UtilRawReas> UtilRawReasons { get; set; }
    public DbSet<UtilReas> UtilReasons { get; set; }
    public DbSet<UtilReasCorrActionLink> UtilReasCorrActionLinks { get; set; }
    public DbSet<UtilReasGrp> UtilReasGrps { get; set; }
    public DbSet<UtilReasGrpClass> UtilReasGrpClasses { get; set; }
    public DbSet<UtilReasLink> UtilReasLinks { get; set; }
    public DbSet<UtilState> UtilStates { get; set; }
    #endregion

    public FactelligenceContext(DbContextOptions<FactelligenceContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the entity mappings and relationships here if needed
    }
}

