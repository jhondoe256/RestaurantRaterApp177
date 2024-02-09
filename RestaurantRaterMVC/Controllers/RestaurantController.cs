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

        [HttpGet]
        public async Task<IActionResult> Details(int id) 
        {
            var restaurant = await _rService.GetRestaurant(id);
            return View(restaurant);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            //heres the problem...
            var restaruant = await _rService.GetRestaurant(id);
            
            //well...we have to manually map.... to make it a "RestaurantEdit" object'
            RestaurantEdit restaurantEdit = new RestaurantEdit
            {
                Id = restaruant.Id, 
                Name = restaruant.Name,
                Location = restaruant.Location
            };

            return View(restaurantEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RestaurantEdit model)
        {
            if (!ModelState.IsValid) return View(ModelState);

            if (await _rService.UpdateRestaurant(model)) return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            //heres the problem...
            var restaruant = await _rService.GetRestaurant(id!.Value);
            return View(restaruant);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _rService.DeleteRestaurant(id)) return RedirectToAction(nameof(Index));
            return View();
        }
    }
}
