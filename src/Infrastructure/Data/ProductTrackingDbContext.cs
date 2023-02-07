using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using ProductTracking.Core.Entities;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Entities.Settings;
using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Seeds;

namespace ProductTracking.Infrastructure.Data;
public class ProductTrackingDbContext : IdentityDbContext<User, Role, Guid>, IDbContext
{
    private DbTransaction? _transaction;
    private ICurrentUserService _currentUserService;

    public ProductTrackingDbContext(
        DbContextOptions<ProductTrackingDbContext> options,
        ICurrentUserService currentUserService
    ) : base(options)
    {
        _currentUserService = currentUserService;
    }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<ModuleFunction> Functions { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<RoleModuleFunction> RoleModuleFunctions { get; set; }
    public DbSet<UserModuleFunction> UserModuleFunctions { get; set; }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserStatus> UserStatuses { get; set; }
    public DbSet<Password> Passwords { get; set; }
    public DbSet<LoginLog> LoginLogs { get; set; }
    public DbSet<Checkpoint> Checkpoints { get; set; }
    public DbSet<Container> Containers { get; set; }
    public DbSet<Consignment> Consignments { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemGroup> ItemGroups { get; set; }
    public DbSet<ConsignmentItem> ConsignmentItems { get; set; }
    public DbSet<HeaderContactDetail> HeaderContactDetails { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<ContainerConsignment> ContainerConsignments { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("Users").HasKey(m => m.Id);
        builder.Entity<Role>().ToTable("Roles").HasKey(m => m.Id);
        builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(m => new { m.UserId, m.RoleId });
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(m => new { m.LoginProvider, m.ProviderKey });
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims").HasKey(m => m.Id);
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims").HasKey(m => m.Id);
        builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(m => new { m.UserId, m.LoginProvider, m.Name });

        //builder.Entity<Module>().HasMany(x => x.Roles).WithMany(y => y.Modules).UsingEntity(join => join.ToTable("RoleModule"));

        //builder.Entity<RoleModuleFunction>().HasKey(sc => new { sc.RoleId, sc.ModuleFunctionId });
        //builder.Entity<UserModuleFunction>().HasKey(sc => new { sc.UserId, sc.ModuleFunctionId });
        builder.Entity<Application>()
                .HasIndex(x => x.Name)
                .IsUnique();

        builder.Entity<Module>()
            .HasOne(x => x.Application)
            .WithMany(x => x.Modules)
            .HasForeignKey(x => x.ApplicationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Office>()
            .HasMany(x => x.Users)
            .WithOne(x => x.Office)
            .HasForeignKey(x => x.OfficeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Office>()
            .HasOne(x => x.EntryBy)
            .WithMany()
            .HasForeignKey(x => x.EntryById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<User>()
            .HasOne(x => x.Office)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.OfficeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Checkpoint>()
          .HasMany(x => x.Consignments)
          .WithOne(x => x.CurrentLocation)
          .HasForeignKey(x => x.CurrentLocationId)
          .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Consignment>()
           .HasOne(x => x.Destination)
           .WithMany()
           .HasForeignKey(x => x.DestinationId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Consignment>()
           .HasOne(x => x.StartingStation)
           .WithMany()
           .HasForeignKey(x => x.StartingStationId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Checkpoint>()
            .HasOne(x => x.EntryBy)
            .WithMany()
            .HasForeignKey(x => x.EntryById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<User>()
            .HasOne(x => x.Checkpoint)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.CheckpointId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Container>()
            .HasOne(x => x.Source)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Container>()
            .HasOne(x => x.Destination)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Password>()
            .HasOne(x => x.user)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<UserStatus>()
            .HasOne(x => x.User)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Item>()
            .HasOne(x => x.ItemGroup)
            .WithMany(x => x.Items)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Module>()
            .HasIndex(x => new { x.ApplicationId, x.Name })
            .IsUnique();

        builder.Entity<Module>().HasMany(x => x.Roles).WithMany(y => y.Modules).UsingEntity(join => join.ToTable("RoleModule"));

        builder.Entity<RoleModuleFunction>().HasKey(sc => new { sc.RoleId, sc.ModuleFunctionId });
        builder.Entity<UserModuleFunction>().HasKey(sc => new { sc.UserId, sc.ModuleFunctionId });

        

        builder.Entity<Office>()
            .HasData(SecuritySeed.Offices);

        builder.Entity<Application>()
            .HasData(SecuritySeed.Applications);

        builder.Entity<Menu>()
             .HasData(SecuritySeed.Menus);

        builder.Entity<Module>()
            .HasData(SecuritySeed.Modules);

        builder.Entity<ModuleFunction>()
            .HasData(SecuritySeed.ModuleFunctions);

    }

    public void BeginTransaction()
    {
        if (Database.GetDbConnection().State == ConnectionState.Open)
        {
            return;
        }
        Database.GetDbConnection().Open();
        _transaction = Database.GetDbConnection().BeginTransaction();
    }

    public int Commit()
    {
        var saveChanges = SaveChanges();
        _transaction.Commit();
        return saveChanges;
    }

    public Task<int> CommitAsync()
    {
        var saveChangesAsync = SaveChangesAsync();
        _transaction.Commit();
        return saveChangesAsync;
    }

    public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : new()
    {
        throw new NotImplementedException();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        => base.Set<TEntity>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.EntryById = _currentUserService.UserId;
                    entry.Entity.EntryDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Property(nameof(entry.Entity.EntryById)).IsModified = false;
                    entry.Property(nameof(entry.Entity.EntryDate)).IsModified = false;
                    entry.Entity.UpdatedById = _currentUserService.UserId;
                    entry.Entity.UpdatedDate = DateTime.Now;
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters) where TElement : class
        => base.Set<TElement>().FromSqlRaw(sql, parameters).AsEnumerable();
}
