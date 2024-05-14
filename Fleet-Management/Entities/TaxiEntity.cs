using System.ComponentModel.DataAnnotations.Schema;
namespace Fleet_Managment.Entities
{
    [Table("Taxis")]
    public class TaxiEntity
    {
        public int Id { get; set; }
        public string? Plate { get; set; }
    }
}
