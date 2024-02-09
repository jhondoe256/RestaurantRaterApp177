using RestaurantRaterMVC.Data;
using RestaurantRaterMVC.Models.RatingModels;
using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Models.RestaurantModels
{
    public class RestaurantDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public string Location { get; set; }= string.Empty;
        
        [Display(Name="Average Score")]
        public double Score { get; set; }

        public double AverageFoodScore { get; set; }

        public double AverageCleanlinessScore { get; set; }

        public double AverageAtmosphereScore { get; set; }
        public List<RatingListItem> Ratings { get; set; } = new List<RatingListItem>();

    }
}
