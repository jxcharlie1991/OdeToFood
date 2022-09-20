using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class EditModel : PageModel
    {
        private readonly IResturantData resturantData;
        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        [BindProperty]
        public Resturant Resturant { get; set; }


        public EditModel(IResturantData resturantData, IHtmlHelper htmlHelper)
        {
            this.resturantData = resturantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? id)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (id.HasValue)
            {
                Resturant = resturantData.GetById(id.Value);                
            }
            else
            {
                Resturant = new Resturant();
            }
            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Resturant.Id > 0)
            {
                Resturant = resturantData.Update(Resturant);
 
            }
            else
            {
                Resturant = resturantData.Add(Resturant);
            }
            resturantData.SaveChanges();
            TempData["Message"] = "Resturant Saved!";
            return RedirectToPage("./Detail", new { id = Resturant.Id });

        }
    }
}
