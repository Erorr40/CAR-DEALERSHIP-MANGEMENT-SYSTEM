using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
