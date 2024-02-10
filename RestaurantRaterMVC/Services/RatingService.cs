using Microsoft.EntityFrameworkCore;
using RestaurantRaterMVC.Data;
using RestaurantRaterMVC.Models.RatingModels;
using RestaurantRaterMVC.Services.Contracts;

namespace RestaurantRaterMVC.Services
{
    public class RatingService : IRatingService
    {
        private readonly RestaurantDbContext _context;

        public RatingService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRating(RatingCreate model)
        {
            var entity = new Rating()
            {
                AtmosphereScore = model.AtmosphereScore,
                CleanlinesScore = model.CleanlinesScore,
                FoodScore = model.FoodScore,
                RestaurantId = model.RestaurantId,
            };

            await _context.Ratings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRating(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating is null) return false;
            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> EditRating(RatingEdit model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RatingItem>> GetRatings()
        {
            IEnumerable<RatingItem> ratings = await _context.Ratings.Include(r=>r.Restaurant).ThenInclude(x=>x.Ratings).Select(r => new RatingItem
            {
                Id = r.Id,
                RestaurantName = r.Restaurant.Name,
                RestaurantId = r.Restaurant.Id,
                Score = r.Restaurant.Score
            }).ToListAsync();

            return ratings.DistinctBy(x => x.RestaurantName);
        }

        public async Task<RatingItem> GetRating(int id)
        {
            var rating = await _context.Ratings.Include(r=>r.Restaurant).ThenInclude(x => x.Ratings).SingleOrDefaultAsync(x=>x.Id == id);
            if (rating is null) return new RatingItem();
            return new RatingItem 
            { 
                Id = rating.Id,
                RestaurantName= rating.Restaurant.Name, 
                Score = rating.Restaurant.Score 
            };
        }

        //I want all ratings based on restaurantId
        public async Task<IEnumerable<RatingItem>> GetRatingsByRestaurantById(int restaurantId)
        {
            IEnumerable<RatingItem> ratings =
                await
                _context
                .Ratings
                .Include(r => r.Restaurant)
                .ThenInclude(x=>x.Ratings)
                .Where(r => r.Restaurant.Id == restaurantId)
                .Select(r => new RatingItem
                {
                    Id = r.Id,
                    RestaurantId = r.Restaurant.Id,
                    RestaurantName = r.Restaurant.Name,
                    Score = r.Restaurant.Score,
                    AtmosphereScore = r.Restaurant.AverageAtmosphereScore,
                    FoodScore = r.Restaurant.AverageFoodScore,
                    CleanlinesScore = r.CleanlinesScore
                }).ToListAsync();

            return ratings;
        }
    }
}
