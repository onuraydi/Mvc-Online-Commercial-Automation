using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context context = new Context();
        public ActionResult Index()
        {
            var toplamUrunSayisi = context.Uruns.Count().ToString();
            ViewBag.toplamUrunSayisi = toplamUrunSayisi;

            var toplamCariSayisi = context.Caris.Count().ToString();
            ViewBag.toplamCariSayisi = toplamCariSayisi;

            var toplamSehir = (from x in context.Caris select x.CariSehir).Distinct().Count().ToString();
            ViewBag.toplamSehir = toplamSehir;

            var toplamKategori = context.Kategoris.Count().ToString();
            ViewBag.toplamKategori =toplamKategori;

            var yapilacaklar = context.yapilacaklarListesis.ToList();
            return View(yapilacaklar);
        }
    }
}