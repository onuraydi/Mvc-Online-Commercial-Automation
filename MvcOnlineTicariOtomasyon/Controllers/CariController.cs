using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context context = new Context();
        public ActionResult Index()
        {
            var cariler = context.Caris.Where(x=>x.CariDurum==true).ToList();
            return View(cariler);
        }
        [HttpGet]
        public ActionResult cariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult cariEkle(Cari cari)
        {
            cari.CariDurum = true;
            context.Caris.Add(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult cariSil(int ID)
        {
            var silinecekCari = context.Caris.Find(ID);
            silinecekCari.CariDurum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult cariGetir(int ID)
        {
            var guncellenecekCari = context.Caris.Find(ID);
            return View("cariGetir",guncellenecekCari);
        }
        public ActionResult cariGuncelle(Cari cari)
        {
            var guncellenecekCari = context.Caris.Find(cari.CariID);
            guncellenecekCari.CariAd = cari.CariAd;
            guncellenecekCari.CariSoyad = cari.CariSoyad;
            guncellenecekCari.CariSehir = cari.CariSehir;
            guncellenecekCari.CariMail = cari.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult musteriSatinAlim(int ID)
        {
            var satinAlim = context.SatisHarekets.Where(x => x.CariID == ID).ToList();
            var ad = context.Caris.Where(x=> x.CariID==ID).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.Cari = ad;
            return View(satinAlim);
        }
    }
}