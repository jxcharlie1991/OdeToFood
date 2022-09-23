using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    public class ResturantCountViewComponent : ViewComponent
    {
        private readonly IResturantData resturantData;

        public ResturantCountViewComponent(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = resturantData.GetCountOfResturants();
            return View("ResturantCount", count);
        }
    }
}
