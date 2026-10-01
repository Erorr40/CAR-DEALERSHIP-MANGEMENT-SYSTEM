using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models
{
    public class CustomerProfile
    {
        public int CustomerProfileId { get; set; }
        [Required, MaxLength(250)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Customer customer { get; set; }

    }
}
