using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Data
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100,ErrorMessage ="Cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100,ErrorMessage ="Cannot exceed 100 characters")]
        public string Location { get; set; } = string.Empty;

        public List<Rating> Ratings { get; set; } = new List<Rating>();

        public double AverageFoodScore 
        {
            get 
            {
                return Math.Round(Ratings.Select(r => r.FoodScore).Sum() / Ratings.Count,2);
            }
        }

        public double AverageCleanlinessScore
        {
            get
            {
                return Math.Round(Ratings.Select(r => r.CleanlinesScore).Sum() / Ratings.Count,2);
            }
        }

        public double AverageAtmosphereScore
        {
            get
            {
                return Math.Round(Ratings.Select(r => r.AtmosphereScore).Sum() / Ratings.Count, 2);
            }
        }

        public double Score
        {
            get 
            {
                return Math.Round((AverageFoodScore + AverageCleanlinessScore + AverageAtmosphereScore) / 3,2);
            }
        }
    }
}
