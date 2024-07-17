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
            // Id'ye göre ürün çekme
            List<SelectListItem> urun = (from x in context.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()
                                         }).ToList();
            ViewBag.Urun = urun;

            // ID'ye göre Cari çekme
            List<SelectListItem> cari = (from y in context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = y.CariAd + " " + y.CariSoyad,
                                             Value = y.CariID.ToString()
                                         }).ToList();
            ViewBag.cari = cari;

            // ID'ye göre personel çekme
            List<SelectListItem> personel = (from z in context.Personels.ToList() select new SelectListItem
            {
                Text= z.PersonelAd + " " + z.PersonelSoyad,
                Value= z.PersonelID.ToString()
            }).ToList();
            ViewBag.personel = personel;

            return View();
        }
        [HttpPost]
        public ActionResult yeniSatis(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult satisGetir(int ID)
        {
            // Id'ye göre ürün çekme
            List<SelectListItem> urun = (from x in context.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()
                                         }).ToList();
            ViewBag.Urun = urun;

            // ID'ye göre Cari çekme
            List<SelectListItem> cari = (from y in context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = y.CariAd + " " + y.CariSoyad,
                                             Value = y.CariID.ToString()
                                         }).ToList();
            ViewBag.cari = cari;

            // ID'ye göre personel çekme
            List<SelectListItem> personel = (from z in context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = z.PersonelAd + " " + z.PersonelSoyad,
                                                 Value = z.PersonelID.ToString()
                                             }).ToList();
            ViewBag.personel = personel;
            var guncellenecekSatis = context.SatisHarekets.Find(ID);
            return View("satisGetir",guncellenecekSatis);
        }
        public ActionResult satisGuncelle(SatisHareket satisHareket)
        {
            var guncellenecekSatis = context.SatisHarekets.Find(satisHareket.SatisHareketID);
            guncellenecekSatis.Tarih = satisHareket.Tarih;
            guncellenecekSatis.Adet = satisHareket.Adet;
            guncellenecekSatis.Fiyat = satisHareket.Fiyat;
            guncellenecekSatis.ToplamTutar = satisHareket.ToplamTutar;
            guncellenecekSatis.CariID = satisHareket.CariID;
            guncellenecekSatis.PersonelID = satisHareket.PersonelID;
            guncellenecekSatis.UrunID = satisHareket.UrunID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult satisDetay(int ID)
        {
            var detay = context.SatisHarekets.Where(x=>x.SatisHareketID==ID).ToList();
            return View(detay);
        }
    }
}