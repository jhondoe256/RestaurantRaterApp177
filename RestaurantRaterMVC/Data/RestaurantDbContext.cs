using Microsoft.EntityFrameworkCore;
using RestaurantRaterMVC.Models.RestaurantModels;

namespace RestaurantRaterMVC.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }
        
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant() 
                {
                    Id=1,
                    Name = "Super Mario Cavern",
                    Location ="1up lane"
                }
                );

            modelBuilder.Entity<Rating>().HasData(
                new Rating 
                {
                    Id =1,
                    AtmosphereScore = 5,
                    CleanlinesScore = 7,
                    FoodScore= 10,
                    RestaurantId = 1,
                },
                new Rating
                {
                    Id = 2,
                    AtmosphereScore = 5,
                    CleanlinesScore = 5,
                    FoodScore = 5,
                    RestaurantId = 1,
                }
             );
        }

    }
}
