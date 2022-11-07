using Microsoft.EntityFrameworkCore;

namespace HalfboardStats.Core.ObjectRelationalMappers
{
    public class HalfboardContext : DbContext
    {
        public HalfboardContext(DbContextOptions<HalfboardContext> options) : base(options) { }
        public HalfboardContext() { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<RegularSeasonStats> RegularSeasonStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<RegularSeasonStats>().ToTable("RegularSeasonStats");
        }
    }
}
