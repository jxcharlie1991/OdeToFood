using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class DeleteModel : PageModel
    {
        private readonly IResturantData resturantData;
        public Resturant Resturant { get; set; }

        public DeleteModel(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }

        public IActionResult OnGet(int id)
        {
            Resturant = resturantData.GetById(id);
            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var resturant = resturantData.Delete(id);
            resturantData.SaveChanges();
            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{resturant.Name} Deleted!";
            return RedirectToPage("./List");
        }
    }
}
