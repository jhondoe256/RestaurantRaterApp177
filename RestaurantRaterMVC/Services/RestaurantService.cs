using Microsoft.EntityFrameworkCore;
using RestaurantRaterMVC.Data;
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

        public Task<bool> DeleteRestaurant(int id)
        {
            throw new NotImplementedException();
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

        public Task<RestaurantDetail> GetRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRestaurant(RestaurantEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
