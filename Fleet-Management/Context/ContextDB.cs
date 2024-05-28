using Microsoft.EntityFrameworkCore;
using Fleet_Managment.Entities;

namespace Fleet_Managment.Context
{
    public class ContextDB : DbContext
    {
        private readonly IConfiguration _configuration;
        public ContextDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<TaxiEntity> Taxis { get; set; }
        public DbSet<TrajectoryEntity> Trajectories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxiEntity>()
                .ToTable("taxis")
                .Property(t => t.Id)
                .HasColumnName("id");
            modelBuilder.Entity<TaxiEntity>()
                .Property(t => t.Plate)
                .HasColumnName("plate");
            modelBuilder.Entity<TrajectoryEntity>()
                .ToTable("trajectories")
                .HasKey(t => t.Id);
            modelBuilder.Entity<TrajectoryEntity>()
                .Property(t => t.TaxiId)
                .HasColumnName("taxi_id");
            modelBuilder.Entity<TrajectoryEntity>()
                .Property(t => t.Date)
                .HasColumnName("date");
            modelBuilder.Entity<TrajectoryEntity>()
                .Property(t => t.Latitude)
                .HasColumnName("latitude");
            modelBuilder.Entity<TrajectoryEntity>()
                .Property(t => t.Longitude)
                .HasColumnName("longitude");
            modelBuilder.Entity<TrajectoryEntity>()
                .HasOne(t => t.Taxi)
                .WithMany(t => t.Trajectories)
                .HasForeignKey(t => t.TaxiId);
            base.OnModelCreating(modelBuilder);
        }
    }
}


