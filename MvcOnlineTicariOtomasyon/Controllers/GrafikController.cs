using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult kategoriUrun()    //dinamikleştir
        {
            var grafik = new Chart(width: 600, height: 600);
            grafik.AddTitle("Kategori-Ürün Stok").AddLegend("Stok").AddSeries("Değerler",xValue: new[]
            {
                "","","",""
            },
            yValues: new[] {15,80,55,55}).Write();

            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult UrunStok()
        {
            return View();
        }
        public ActionResult VisualizeUrunStok()
        {
            return Json(urunListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<UrunStokSayisi> urunListesi()
        {
            List<UrunStokSayisi> urunStok = new List<UrunStokSayisi>();
            urunStok.Add(new UrunStokSayisi()
            {
                UrunAd = "Bilgisayar",
                UrunStok = 150
            });
            urunStok.Add(new UrunStokSayisi()
            {
                UrunAd = "Bilgisayar",
                UrunStok = 150
            });
            urunStok.Add(new UrunStokSayisi()
            {
                UrunAd = "Bilgisayar",
                UrunStok = 150
            });
            urunStok.Add(new UrunStokSayisi()
            {
                UrunAd = "Bilgisayar",
                UrunStok = 150
            });
            return urunStok;
        }

        public ActionResult UrunStok2()
        {
            return View();
        }
        public ActionResult VisualizeUrunStok2()
        {
            return Json(urunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<Class1> urunListesi2()
        {
            List<Class1> snf = new List<Class1>();
            using (var context = new Context())
            {
                snf = context.Uruns.Select(x => new Class1
                {
                    urn = x.UrunAd,
                    stk = x.Stok
                }).ToList();
            }
            return snf;
        }
    }
}