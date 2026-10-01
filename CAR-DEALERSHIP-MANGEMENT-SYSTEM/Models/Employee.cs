using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, MaxLength(100)]
        public string Position { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [Required]
        public DateTime? HireDate { get; set; }


        public IEnumerable<Sale> sales { get; set; } = new List<Sale>();
    }
}
