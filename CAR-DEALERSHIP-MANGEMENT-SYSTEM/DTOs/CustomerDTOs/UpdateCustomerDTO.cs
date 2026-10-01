using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models;
using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.DTOs.CustomerDTOs
{
    public class UpdateCustomerDTO
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(20)]
        public string Phone { get; set; }
        [Required, MaxLength(30)]
        public string DriverLicenseNumber { get; set; }

        public int CustomerProfileId { get; set; }
    }
}
