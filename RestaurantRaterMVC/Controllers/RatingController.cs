using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantRaterMVC.Models.RatingModels;
using RestaurantRaterMVC.Services.Contracts;

namespace RestaurantRaterMVC.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;
        private IRestaurantService _restaurantService;
        public RatingController(IRatingService ratingService, IRestaurantService restaurantService)
        {
            _ratingService = ratingService;
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var ratings = await _ratingService.GetRatings();
            return View(ratings);
        }

        [HttpGet]
        public async Task<IActionResult> RatingsByRestaurant(int id) 
        {
            var restaruants = await _ratingService.GetRatingsByRestaurantById(id);
            if(restaruants == null) return RedirectToAction("Index");
            return View(restaruants);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<SelectListItem> restaurantOptions = 
                _restaurantService
                .GetAllRestaurants().Result.Select(r=>new SelectListItem 
                {
                    Text = r.Name,
                    Value = r.Id.ToString(),
                }).ToList();
            
            RatingCreate model = new RatingCreate();
            model.RestaurantOptions = restaurantOptions;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RatingCreate model)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            if (await _ratingService.CreateRating(model)) return RedirectToAction(nameof(Index));
           
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var rating = await _ratingService.GetRating(id.Value);
            if (rating == null) return RedirectToAction(nameof(Index));
            return View(rating);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _ratingService.DeleteRating(id)) return RedirectToAction(nameof(Index));
            return View();
        }

    }
}
