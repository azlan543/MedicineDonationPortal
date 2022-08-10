using Microsoft.AspNetCore.Mvc;
using MedicineDonationPortal.Models;
namespace MedicineDonationPortal.Controllers;

public class NGOController : Controller
{
   

    public IActionResult NGODet()
    {
        using (OMMSContext db = new OMMSContext())
        {
            TempData["ngos"] = db.NGOModel.ToList();
        }
        return View();
    }
    public IActionResult OnlyNgo()
    {
        using (OMMSContext db = new OMMSContext())
        {
            TempData["ngos"] = db.NGOModel.ToList();
        }
        return View();
    }
    public IActionResult NGO()
    {
        return View();
    }
    [HttpPost]
    public IActionResult NGO(NGOModel ng)
    {

        if (!ModelState.IsValid)
        {
            using (OMMSContext db = new OMMSContext())
            {

                db.NGOModel.Add(ng);
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

    public IActionResult Edit(int id)
    {
        NGOModel ss = new NGOModel();
        using (OMMSContext db = new OMMSContext())
        {
            ss = db.NGOModel.Where(x => x.NGOId == id).FirstOrDefault();
        }
        return View(ss);
    }

    [HttpPost]
    public IActionResult Edit(NGOModel s)
    {
        using (OMMSContext db = new OMMSContext())
        {
            var Result= db.NGOModel.Find(s.NGOId);
            Result.Name= s.Name;
            Result.EmailId= s.EmailId;
            Result.Address= s.Address;
            Result.MobileNumber= s.MobileNumber;
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
        return RedirectToAction("NGODet", "NGO");
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        NGOModel ss = new NGOModel();
        using (OMMSContext db = new OMMSContext())
        {
            ss = db.NGOModel.Where(x => x.NGOId == id).FirstOrDefault();
            db.NGOModel.Remove(ss);
            int count = db.SaveChanges();
            if (count > 0)
            {
                TempData["DeleteMsg"] = "1";
                ModelState.Clear();
            }

        }
        return RedirectToAction("NGODet", "NGO");
    }

}

