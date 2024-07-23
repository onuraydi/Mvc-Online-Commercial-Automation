using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context context =new Context();
        public ActionResult Index(string parametre)
        {
            var kargolar = from x in context.kargoDetays select x;
            if(!string.IsNullOrEmpty(parametre))
            {
                kargolar = kargolar.Where(x => x.TakipKodu.Contains(parametre));
            }
            return View(kargolar.ToList());
        }
        [HttpGet]
        public ActionResult kargoEkle()
        {
            Random random = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E" };
            int k1, k2, k3;
            k1 = random.Next(0, 5);
            k2 = random.Next(0, 5);
            k3 = random.Next(0, 5);

            int s1,s2,s3;

            s1= random.Next(100,999);
            s2= random.Next(10,99);
            s3= random.Next(10,99);

            string takipKodu = s1.ToString() + karakterler[k1].ToString() + s2.ToString() + karakterler[k2].ToString() + s3.ToString() + karakterler[k3].ToString();
            ViewBag.takipKodu = takipKodu;
            return View();
        }
        [HttpPost]
        public ActionResult kargoEkle(KargoDetay kargo)
        {
            context.kargoDetays.Add(kargo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kargoTakip(string id)
        {
            var kargoDetay = context.kargoTakips.Where(x=>x.KargoTakipKodu == id).ToList();
            return View(kargoDetay);
        }
    }
}