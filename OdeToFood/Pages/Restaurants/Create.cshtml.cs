using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class CreateModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
      
        public Restaurant Restaurant { get; set; }

        public CreateModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(Restaurant restaurant)
        {

            Restaurant = _restaurantData.CreateRestaurant(restaurant);
            if(!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("./Details", new { restaurantId = Restaurant.Id });
        }
    }
}