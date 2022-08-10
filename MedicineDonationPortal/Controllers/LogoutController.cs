using Microsoft.AspNetCore.Mvc;

namespace MedicineDonationPortal.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult LogoutPage()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
}
