using Microsoft.AspNetCore.Mvc;

namespace MedicineDonationPortal.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
