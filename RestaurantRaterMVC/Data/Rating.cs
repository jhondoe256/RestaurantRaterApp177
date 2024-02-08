namespace RestaurantRaterMVC.Data
{
    public class Rating
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public double FoodScore { get; set; }
        public double CleanlinesScore { get; set; }
        public double AtmosphereScore { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
