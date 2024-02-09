using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Models.RatingModels
{
    public class RatingCreate
    {
        [Required]
        [Display(Name="Restaurant")]
        public int RestaurantId { get; set; }
        
        [Required]
        [Range(0,10,ErrorMessage ="You can only go from 0 to 10")]
        public double FoodScore { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "You can only go from 0 to 10")]
        public double CleanlinesScore { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "You can only go from 0 to 10")]
        public double AtmosphereScore { get; set; }

        public IEnumerable<SelectListItem> RestaurantOptions { get; set; } = new List<SelectListItem>();
    }
}
