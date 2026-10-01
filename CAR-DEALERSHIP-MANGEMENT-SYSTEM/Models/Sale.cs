using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required, Range(0.1, (double)decimal.MaxValue)]
        public int SalePrice { get; set; }
        [Required, MaxLength(30)]
        public string PaymentMethod { get; set; }
        [MaxLength(300)]
        public string? Notes { get; set; }

        public int CustomerId { get; set; }
        public Customer customer { get; set; } 

        public int EmployeeId { get; set; }
        public Employee employee { get; set; }

        public Vehicle vehicle { get; set; }
    }
}
