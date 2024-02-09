using RestaurantRaterMVC.Models.RatingModels;

namespace RestaurantRaterMVC.Services.Contracts
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingItem>> GetRatings();
        Task<RatingItem> GetRating(int id);
        Task<IEnumerable<RatingItem>> GetRatingsByRestaurantById(int restaurantId);
        Task<bool> CreateRating(RatingCreate model);
        Task<bool> EditRating(RatingEdit model);
        Task<bool> DeleteRating(int id);
    }
}
