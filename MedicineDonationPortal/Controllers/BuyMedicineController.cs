using Microsoft.AspNetCore.Mvc;
using MedicineDonationPortal.Models;

namespace MedicineDonationPortal.Controllers
{
    public class BuyMedicineController : Controller
    {
        public IActionResult BuyMedDet()
        {
            using (OMMSContext db = new OMMSContext())
            {
                TempData["MedBuy"] = db.MedBuy.ToList();
            }
            return View();
        }

        public IActionResult BuyMed()
        {

             return View();
        }
        [HttpPost]
        public IActionResult BuyMed(MedBuy md)
        {

            if (!ModelState.IsValid)
            {
                using (OMMSContext db = new OMMSContext())
                {

                    db.MedBuy.Add(md);
                    
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["MedBuy"] = "1";
                        ModelState.Clear();


                    }
                    else
                    {
                        TempData["MedBuy"] = "0";
                    }
                }

            }
            return View();

            }
        }
}
