using BD.Business.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using System;
using BD.Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using BD.Business.Services;

namespace BD.Data.Context
{
    public class DataDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DataDbContext(DbContextOptions<DataDbContext> options, UserResolverService userService) : base(options) 
        {
            _userId = userService.GetUserId();
        }

        private int _userId;

        public DbSet<Item> Items { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<ReserveItem> ReserveItems { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<CashFlow> CashFlows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureDefaultColumns(modelBuilder);
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
            modelBuilder.Entity<AppRole>().ToTable("Roles");
            modelBuilder.Entity<AppUser>().ToTable("Users");
        }
              

        private void ConfigureDefaultColumns(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties()).Where(p => p.ClrType == typeof(string)))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if(entry.Entity is ITrackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                            entry.Property("CreatedBy").CurrentValue = _userId;
                            break;
                        case EntityState.Modified:
                            entry.Property("CreatedAt").IsModified = false;
                            entry.Property("CreatedBy").IsModified = false;
                            break;
                    }
                    entry.Property("LastUpdatedAt").CurrentValue = DateTime.Now;
                    entry.Property("UpdatedBy").CurrentValue = _userId;
                }
            }
        }
    }
}
