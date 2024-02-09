using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Models.RatingModels
{
    public class RatingEdit
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Restaurant")]
        public int RestaurantId { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "You can only go from 0 to 10")]
        public double Score { get; set; }
    }
}
