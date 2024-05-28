using System.ComponentModel.DataAnnotations.Schema;
namespace Fleet_Managment.Entities
{
    [Table("Taxis")]
    public class TaxiEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("plate")]
        public string Plate { get; set; }
        // Navigation property
        public virtual ICollection<TrajectoryEntity> Trajectories { get; set; }
    }
}









