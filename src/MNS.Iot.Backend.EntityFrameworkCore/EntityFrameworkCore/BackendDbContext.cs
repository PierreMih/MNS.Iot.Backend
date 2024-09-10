using Microsoft.EntityFrameworkCore;
using MNS.Iot.Backend.Magasins;
using MNS.Iot.Backend.Magasins.Machines;
using MNS.Iot.Backend.Magasins.Passerelles;
using MNS.Iot.Backend.Magasins.Sondes;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace MNS.Iot.Backend.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class BackendDbContext :
    AbpDbContext<BackendDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    public DbSet<Magasin> Magasins { get; set; }
    public DbSet<Passerelle> Passerelles { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<Sonde> Sondes { get; set; }
    

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public BackendDbContext(DbContextOptions<BackendDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Magasin>(magasin =>
        {
            magasin.ToTable(BackendConsts.DbTablePrefix + "Magasins", BackendConsts.DbSchema);
            magasin.ConfigureByConvention();
            magasin.HasMany(m => m.MagasinPasserelleJoinEntities).WithOne().IsRequired();
        });
        builder.Entity<MagasinPasserelleJoinEntity>(mpje =>
        {
            mpje.ToTable(BackendConsts.DbTablePrefix + "MagasinPasserelleJoinEntities", BackendConsts.DbSchema);
            mpje.ConfigureByConvention();
            mpje.HasKey(je => je.MagasinId);
            mpje.HasKey(je => je.PasserelleId);
        });
        
        builder.Entity<Passerelle>(passerelle =>
        {
            passerelle.ToTable(BackendConsts.DbTablePrefix + "Passerelles", BackendConsts.DbSchema);
            passerelle.ConfigureByConvention();
            passerelle.HasMany(p => p.MachinePasserelleJoinEntities).WithOne().IsRequired();
        });
        builder.Entity<PasserelleMachineJoinEntity>(mpje =>
        {
            mpje.ToTable(BackendConsts.DbTablePrefix + "MachinePasserelleJoinEntities", BackendConsts.DbSchema);
            mpje.ConfigureByConvention();
            mpje.HasKey(je => je.PasserelleId);
            mpje.HasKey(je => je.MachineId);
        });
        
        builder.Entity<Machine>(machine =>
        {
            machine.ToTable(BackendConsts.DbTablePrefix + "Machines", BackendConsts.DbSchema);
            machine.ConfigureByConvention();
            machine.HasMany(m => m.MachineSondeJoinEntities).WithOne().IsRequired();
        });
        builder.Entity<MachineSondeJoinEntity>(msje =>
        {
            msje.ToTable(BackendConsts.DbTablePrefix + "MachineSondeJoinEntities", BackendConsts.DbSchema);
            msje.ConfigureByConvention();
            msje.HasKey(je => je.MachineId);
            msje.HasKey(je => je.SondeId);
        });
        
        builder.Entity<Sonde>(sonde =>
        {
            sonde.ToTable(BackendConsts.DbTablePrefix + "Sondes", BackendConsts.DbSchema);
            sonde.ConfigureByConvention();
            sonde.HasMany(s => s.Mesures)
                .WithOne()
                .HasForeignKey(m => m.SondeId)
                .IsRequired();
        });

        builder.Entity<Mesure>(mesure =>
        {
            mesure.ToTable(BackendConsts.DbTablePrefix + "Mesures", BackendConsts.DbSchema);
            mesure.ConfigureByConvention();
        });
    }
}
