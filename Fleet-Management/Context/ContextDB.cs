using Fleet_Managment.Entities;
using Microsoft.EntityFrameworkCore;
namespace Fleet_Managment.Context;

public class ContextDB : DbContext
{
    private readonly Connection _connection;
    public ContextDB(Connection connection)
    {
        _connection = connection;
    }
    public DbSet<TaxiEntity> Taxis { get; set; }
    public DbSet<TrajectoryEntity> Trajectories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaxiEntity>()
            .ToTable("taxis") // Nombre de la tabla en la base de datos
            .Property(t => t.Id)
            .HasColumnName("id"); // Nombre de la columna "Id" en la base de datos
        modelBuilder.Entity<TaxiEntity>()
            .Property(t => t.Plate)
            .HasColumnName("plate"); // Nombre de la columna "Plate" en la base de datos
        // Si necesitas hacer lo mismo para la entidad TrajectoryEntity, aquí es donde lo harías
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = _connection.OpenConnection();
        optionsBuilder.UseNpgsql(connection);
        _connection.CloseConnection(connection);
    }
}
