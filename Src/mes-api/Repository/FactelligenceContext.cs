using BOL.API.Domain.Models.Core;
using BOL.API.Domain.Models.EnProd;
using BOL.API.Domain.Models.Prod;
using BOL.API.Domain.Models.Security;
using BOL.API.Domain.Models.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

    // EnProd Models
    public DbSet<ItemInv> ItemInvs { get; set; }
    public DbSet<StorageExec> StorageExecs { get; set; }

    //Prod Models
    public DbSet<Item> Items { get; set; }
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

