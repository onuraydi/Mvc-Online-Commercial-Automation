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
            List<SelectListItem> deger = (from x in context.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriID.ToString()
                                          }).ToList();
            ViewBag.deger = deger;

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
            var silinecekId = context.Uruns.Find(urunId);
            if(silinecekId.Durum == true)
            {
                silinecekId.Durum = false;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult urunGetir(int ID)
        {
            List<SelectListItem> deger = (from x in context.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriID.ToString()
                                          }).ToList();
            ViewBag.deger = deger;
            var guncellenecekUrun = context.Uruns.Find(ID);
            return View("urunGetir", guncellenecekUrun);
        }
        public ActionResult urunGuncelle(Urun urun)
        {
            var guncellenecekUrun = context.Uruns.Find(urun.UrunID);
            guncellenecekUrun.UrunAd = urun.UrunAd;
            guncellenecekUrun.Marka = urun.Marka;
            guncellenecekUrun.Stok = urun.Stok;
            guncellenecekUrun.AlisFiyat = urun.AlisFiyat;
            guncellenecekUrun.SatisFiyat = urun.SatisFiyat;
            guncellenecekUrun.KategoriID = urun.KategoriID;
            guncellenecekUrun.UrunGorsel = urun.UrunGorsel;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}