using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        [Required, MaxLength(100)]
        public string Make { get; set; }
        [Required, MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [MaxLength(50)]
        public string? Color { get; set; }
        [Required, Range(0.1, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Mileage { get; set; }
        [Required, MaxLength(17)]
        public string VIN {  get; set; }
        [MaxLength(30)]
        public string? FuelType { get; set; }
        [MaxLength(30)]
        public string? Transmission { get; set; }
        [Required]
        public string Status { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category category { get; set; }

        public int SalesId { get; set; }
        public Sale sale { get; set; }
    }
}
