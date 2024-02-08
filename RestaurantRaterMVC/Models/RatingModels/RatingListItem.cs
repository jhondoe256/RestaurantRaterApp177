namespace RestaurantRaterMVC.Models.RatingModels
{
    public class RatingListItem
    {
        public int Id { get; set; }
        public double FoodScore { get; set; }
        public double CleanlinesScore { get; set; }
        public double AtmosphereScore { get; set; }
    }
}
