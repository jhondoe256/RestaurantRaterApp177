using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Models.RatingModels
{
    public class RatingItem
    {
        public int Id { get; set; }

        [Display(Name = "Restaurant")]
        public string RestaurantName { get; set; }

        [Display(Name = "Rating")]
        public double Score { get; set; }
    }
}
