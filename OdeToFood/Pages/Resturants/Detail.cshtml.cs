using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class DetailModel : PageModel
    {
        private readonly IResturantData resturantData;
        public  Resturant Resturant { get; set; }

        [TempData]
        public string Message { get; set; }

        public DetailModel(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }
        public IActionResult OnGet(int id)
        {
            Resturant = resturantData.GetById(id);
            if(Resturant == null)
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
