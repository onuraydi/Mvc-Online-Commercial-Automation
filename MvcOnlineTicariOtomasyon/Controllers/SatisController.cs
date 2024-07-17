using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context context = new Context();
        public ActionResult Index()
        {
            var satislar = context.SatisHarekets.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult yeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniSatis(SatisHareket satisHareket)
        {
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}