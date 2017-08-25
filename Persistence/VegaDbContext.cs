using Microsoft.EntityFrameworkCore;
using Vega.Domain;

namespace Vega.Persistence
{
    public class VegaDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {          
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VehicleFeature>()
                .HasKey(vf => new {vf.VehicleId, vf.FeatureId});

            builder.Entity<VehicleFeature>()
                .HasOne(vf => vf.Vehicle)
                .WithMany(v => v.Features)
                .HasForeignKey(vf => vf.VehicleId);

            builder.Entity<VehicleFeature>()
                .HasOne(vf => vf.Feature)
                .WithMany()
                .HasForeignKey(vf => vf.FeatureId);
        }
    }
}