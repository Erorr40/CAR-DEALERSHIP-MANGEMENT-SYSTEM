using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models;
using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.DTOs.CustomerDTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DriverLicenseNumber { get; set; }
        public int CustomerProfileId { get; set; }
    }
}
