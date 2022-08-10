using Microsoft.AspNetCore.Mvc;
using MedicineDonationPortal.Models;

namespace MedicineDonationPortal.Controllers
{
    public class MedicineController : Controller
    {

        public IActionResult Add()
        {
            using (OMMSContext db = new OMMSContext())
            {
                TempData["medicine"] = db.Medicines.ToList();
            }
            return View();
        }
        public IActionResult OnlyUser()
        {
            using (OMMSContext db = new OMMSContext())
            {
                TempData["medicine"] = db.Medicines.ToList();
            }
            return View();
        }
        public IActionResult AddMedicine()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddMedicine(Medicine md)
        {
            
            if (!ModelState.IsValid)
            {
                using (OMMSContext db = new OMMSContext())
                {

                    db.Medicines.Add(md);
                    int count= db.SaveChanges();
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
        public IActionResult Edit(int id)
        {
            Medicine ss = new Medicine();
            using (OMMSContext db = new OMMSContext())
            {
                ss = db.Medicines.Where(x => x.MedicineId == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult Edit(Medicine s)
        {
            using (OMMSContext db = new OMMSContext())
            {
                var Result = db.Medicines.Find(s.MedicineId);
                Result.MedicineName=s.MedicineName;
                Result.Price=s.Price;
                Result.MfgDate=s.MfgDate;
                Result.ExpDate=s.ExpDate;
                Result.Quantity=s.Quantity;
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["EditMsg"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["EditMsg"] = "0";
                }

            }
            return RedirectToAction("AddMedicine", "Medicine");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Medicine ss = new Medicine();
            using (OMMSContext db = new OMMSContext())
            {
                ss = db.Medicines.Where(x => x.MedicineId  == id).FirstOrDefault();
                db.Medicines.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("AddMedicine", "Medicine");
        }

    }
}
