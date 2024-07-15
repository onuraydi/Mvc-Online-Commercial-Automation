using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context context = new Context();
        public ActionResult Index()
        {
            var urunler = context.Uruns.Where(x => x.Durum==true).ToList();
            return View(urunler);  
        }
        [HttpGet]
        public ActionResult yeniUrun()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniUrun(Urun urun)
        {
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult urunSil(int? urunId)
        {
            if (urunId.HasValue)
            {
                var silinecekId = context.Uruns.Find(urunId.Value);
                if (silinecekId != null)
                {
                    silinecekId.Durum = false;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }


    }
}