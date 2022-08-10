using Microsoft.AspNetCore.Mvc;
using MedicineDonationPortal.Models;

namespace MedicineDonationPortal.Controllers
{
    public class OMMSController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Login(LoginModel lg)
        {
            using (OMMSContext db = new OMMSContext())
            {
                var users = db.Users.Where(x => x.UserId == lg.UserId && x.Password == lg.Password);
                      if(users.Count()>0)
                {
                    var user = users.FirstOrDefault();
                    HttpContext.Session.SetInt32("role", user.RoleId);
                    HttpContext.Session.SetString("name", user.Name);


                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["msg"] = "Incorrect UserId/Password";
                }
            }

            return View();
        }
     
    }
}
