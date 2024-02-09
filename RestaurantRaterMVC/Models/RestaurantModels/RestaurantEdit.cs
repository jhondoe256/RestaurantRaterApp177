using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Models.RestaurantModels
{
    public class RestaurantEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100, ErrorMessage = "Cannot exceed 100 characters")]
        public string Location { get; set; } = string.Empty;
    }
}
