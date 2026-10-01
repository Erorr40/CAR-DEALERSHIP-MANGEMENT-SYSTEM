using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models;
using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
