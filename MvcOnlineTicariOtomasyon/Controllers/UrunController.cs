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
        public ActionResult Index(string parametre)
        {
            var urunler = from x in context.Uruns select x;
            if(!string.IsNullOrEmpty(parametre))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(parametre));  // büyük küçük harf duyarlılığı ??
            }
            return View(urunler.ToList());  
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
            urun.Durum = true;
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

        public ActionResult urunListesi()
        {
            var degerler = context.Uruns.ToList();
            return View(degerler);  
        }
        [HttpGet]
        public ActionResult satisYap(int ID)
        {
            List<SelectListItem> personel = (from z in context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = z.PersonelAd + " " + z.PersonelSoyad,
                                                 Value = z.PersonelID.ToString()
                                             }).ToList();
            ViewBag.personel = personel;

            List<SelectListItem> cari = (from y in context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = y.CariAd + " " + y.CariSoyad,
                                             Value = y.CariID.ToString()
                                         }).ToList();
            ViewBag.cari = cari;


            var urun = context.Uruns.Find(ID);
            ViewBag.urun = urun.UrunID;
            ViewBag.fiyat = urun.SatisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult satisYap(SatisHareket satis)
        {
            satis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(satis);
            context.SaveChanges();
            return RedirectToAction("Index","Satis");

        }
    }
}