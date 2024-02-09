using Microsoft.EntityFrameworkCore;
using RestaurantRaterMVC.Data;
using RestaurantRaterMVC.Models.RatingModels;
using RestaurantRaterMVC.Models.RestaurantModels;
using RestaurantRaterMVC.Services.Contracts;

namespace RestaurantRaterMVC.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _context;

        public RestaurantService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRestaurant(RestaurantCreate model)
        {
            Restaurant restaurant = new Restaurant()
            {
               Name =model.Name,
               Location = model.Location,
            };
            await _context.Restaurants.AddAsync(restaurant);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteRestaurant(int id)
        {
            var restaruant =
               await
               _context
               .Restaurants
              .SingleOrDefaultAsync(x => x.Id == id);

            if (restaruant == null) return false;

            _context.Restaurants.Remove(restaruant);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<RestaurantListItem>> GetAllRestaurants()
        {
            List<RestaurantListItem> restaurants = 
                                 await 
                                 _context.Restaurants
                                //.Include(r=>r.Ratings)  //inner join
                                .Select(r=> new RestaurantListItem { 
                                    Id = r.Id,
                                    Name = r.Name,
                                    Location = r.Location,
                                    Score = r.Score,
                                }).ToListAsync();

            return restaurants;
        }

        public async Task<RestaurantDetail> GetRestaurant(int id)
        {
            var restaruant = await _context.Restaurants
                .Include(r=>r.Ratings)
                .SingleOrDefaultAsync(x=>x.Id == id);

            if (restaruant == null) return new RestaurantDetail();
            return new RestaurantDetail 
            {
                Id = restaruant.Id,
                Name = restaruant.Name,
                Location = restaruant.Location,
                //Ratings = restaruant.Ratings.Select(r=>new RatingListItem 
                //{
                //    Id = r.Id,
                //    AtmosphereScore = r.AtmosphereScore,
                //    CleanlinesScore = r.CleanlinesScore,
                //    FoodScore = r.FoodScore,
                //}).ToList(),
                Score = restaruant.Score,
                AverageAtmosphereScore = restaruant.AverageAtmosphereScore,
                AverageCleanlinessScore = restaruant.AverageCleanlinessScore,
                AverageFoodScore = restaruant.AverageFoodScore
            };
        }

        public async Task<bool> UpdateRestaurant(RestaurantEdit model)
        {
            var restaruant = 
                await 
                _context
                .Restaurants
               .SingleOrDefaultAsync(x => x.Id == model.Id);

            if (restaruant == null) return false;

            restaruant.Name = model.Name;
            restaruant .Location = model.Location;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
