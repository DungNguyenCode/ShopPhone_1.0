using AppView.Extensions;
using AppView.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppView.Views.NumberCarts
{
    public class NumberCart :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.GetObject<List<GioHangViewModel>>("GioHang");
            return View(cart.Count);
        }
    }
}
