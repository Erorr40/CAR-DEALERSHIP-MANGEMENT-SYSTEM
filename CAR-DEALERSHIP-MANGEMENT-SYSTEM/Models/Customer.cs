using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(20)]
        public string Phone { get; set; }
        [Required, MaxLength(30)]
        public string DriverLicenseNumber { get; set; }

        public IEnumerable<Sale> Sales { get; set; } = new List<Sale>();
        public int CustomerProfileId { get; set; }
        public CustomerProfile customerProfile { get; set; }
    }
}
