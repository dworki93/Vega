using Microsoft.EntityFrameworkCore;
using Vega.Domain;

namespace Vega.Data
{
    public class VegaDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }

        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {          
        }
    }
}