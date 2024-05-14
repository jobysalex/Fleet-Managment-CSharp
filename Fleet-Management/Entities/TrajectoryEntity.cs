using System;
namespace Fleet_Managment.Entities
{
    public class TrajectoryEntity
    {
        public int Id { get; set; }
        public int TaxiId { get; set; }
        public DateTime Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
