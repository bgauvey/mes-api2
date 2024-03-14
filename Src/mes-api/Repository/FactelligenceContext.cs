using BOL.API.Domain.Models.Security;
using BOL.API.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Repository;

public class FactelligenceContext : DbContext
{
    // Auth Models
    public DbSet<EntLogon> EntLogons { get; set; }
    public DbSet<EntLogonList> EntLogonLists { get; set; }
    public DbSet<GrpName> GrpNames { get; set; }
    public DbSet<Sessn> Sessions { get; set; }
    public DbSet<UserGrpLink> UserGrpLinks { get; set; }
    public DbSet<UserName> UserNames { get; set; }

    //Core Models
    public DbSet<Ent> Ents { get; set; }
    public DbSet<EntAttr> EntAttrs { get; set; }
    public DbSet<EntFile> EntFiles { get; set; }
    public DbSet<EntLink> EntLinks { get; set; }


    public FactelligenceContext(DbContextOptions<FactelligenceContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the entity mappings and relationships here if needed
    }
}

