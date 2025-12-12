using Microsoft.EntityFrameworkCore;
using PCkatalogi.Models;

namespace PCkatalogi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<CompatibilityRule> CompatibilityRules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Component>()
                .Property(c => c.Price)
                .HasPrecision(18, 2); 

            modelBuilder.Entity<Component>()
                .HasMany(c => c.Protocols)
                .WithMany(p => p.Components)
                .UsingEntity<Dictionary<string, object>>(
                    "ComponentProtocol",
                    j => j.HasOne<Protocol>().WithMany().HasForeignKey("ProtocolId"),
                    j => j.HasOne<Component>().WithMany().HasForeignKey("ComponentId")
                );

            modelBuilder.Entity<CompatibilityRule>()
                .HasOne(cr => cr.SourceComponent)
                .WithMany(c => c.SourceComponents)
                .HasForeignKey(cr => cr.SourceComponentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompatibilityRule>()
                .HasOne(cr => cr.TargetComponent)
                .WithMany(c => c.TargetComponents)
                .HasForeignKey(cr => cr.TargetComponentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompatibilityRule>()
                .HasOne(cr => cr.Category)
                .WithMany(c => c.CompatibilityRules)
                .HasForeignKey(cr => cr.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Manufacturer>()
                .HasIndex(m => m.Name)
                .IsUnique();

            modelBuilder.Entity<Protocol>()
                .HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}