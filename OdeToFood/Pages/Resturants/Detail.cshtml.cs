using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public  Restaurant Restaurant { get; set; }

        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int id)
        {
            Restaurant = restaurantData.GetById(id);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");             
            }
            else
            {
                return Page();
            }
            
        }
        
    }
}
