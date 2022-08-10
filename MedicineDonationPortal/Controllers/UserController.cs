using MedicineDonationPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicineDonationPortal.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserDet()
        {
            using (OMMSContext db = new OMMSContext())
            {
                TempData["users"] = db.UserReg.ToList();
            }
            return View();
        }


        public IActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegistration(UserReg ur)
        {
            if (!ModelState.IsValid)
            {
                using (OMMSContext db = new OMMSContext())
                {

                    db.UserReg.Add(ur);
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["AddMsg"] = "1";
                        ModelState.Clear();


                    }
                    else
                    {
                        TempData["AddMsg"] = "0";
                    }
                }

            }

            return View();
        }
        [HttpPost]
        public IActionResult MyOrder()
        {
            using (OMMSContext db = new OMMSContext())
            {
                TempData["users"] = db.UserReg.ToList();
            }
            return View();
        }
    }
}
