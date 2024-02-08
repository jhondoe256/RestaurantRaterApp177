using RestaurantRaterMVC.Models.RestaurantModels;

namespace RestaurantRaterMVC.Services.Contracts
{
    public interface IRestaurantService
    {
        Task<bool> CreateRestaurant(RestaurantCreate model);
        Task<List<RestaurantListItem>> GetAllRestaurants();
        Task<RestaurantDetail> GetRestaurant(int id);
        Task<bool> UpdateRestaurant(RestaurantEdit model);
        Task<bool> DeleteRestaurant(int id);
    }
}
