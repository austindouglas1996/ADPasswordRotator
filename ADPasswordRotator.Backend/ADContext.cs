using ADPasswordRotator.Shared.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ADPasswordRotator.Backend
{
    public class ADContext : IdentityDbContext<Admin>
    {
        public ADContext(DbContextOptions options) : base(options) { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<DomainController> DomainControllers { get; set; }
        public DbSet<ServiceAccount> ServiceAccounts { get; set; }
        public DbSet<SettingsOption> SettingsOptions { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServiceAccount>()
                .HasOne(a => a.Location)
                .WithMany(l => l.Accounts)
                .HasForeignKey(a => a.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DomainController>()
                .HasOne(dc => dc.Location)
                .WithMany(l => l.Controllers)
                .HasForeignKey(dc => dc.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
