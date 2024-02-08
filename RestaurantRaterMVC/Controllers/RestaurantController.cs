using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Models.RestaurantModels;
using RestaurantRaterMVC.Services.Contracts;

namespace RestaurantRaterMVC.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantService _rService;

        public RestaurantController(IRestaurantService rService)
        {
            _rService = rService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RestaurantListItem> restaurants = await _rService.GetAllRestaurants();
            return View(restaurants);
        }

        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create(RestaurantCreate model) 
        {
            if(await _rService.CreateRestaurant(model))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
