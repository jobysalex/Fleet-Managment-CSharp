using System.ComponentModel.DataAnnotations.Schema;

namespace Fleet_Managment.Entities
{
    [Table("Trajectories")]
    public class TrajectoryEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("taxi_id")]
        public int TaxiId { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("latitude")]
        public double Latitude { get; set; }
        [Column("longitude")]
        public double Longitude { get; set; }
        // Navigation property
        [ForeignKey("TaxiId")]
        public virtual TaxiEntity Taxi { get; set; }
    }
}