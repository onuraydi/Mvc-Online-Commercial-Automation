using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context context = new Context();
        public ActionResult Index()
        {
            var cariSayisi = context.Caris.Count().ToString();
            ViewBag.cariSayisi = cariSayisi;

            var urunSayisi = context.Uruns.Count().ToString();
            ViewBag.urunSayisi = urunSayisi;

            var personelSayisi = context.Personels.Count().ToString();
            ViewBag.personelSayisi = personelSayisi;

            var kategoriSayisi = context.Kategoris.Count().ToString();
            ViewBag.kategoriSayisi = kategoriSayisi;

            
            var stokSayisi = context.Uruns.Sum(x=>x.Stok).ToString();
            ViewBag.stokSayisi = stokSayisi;    

            var markaSayisi = (from x in context.Uruns select x.Marka).Distinct().Count().ToString();  // markayı tekrarsız olarak say
            ViewBag.markaSayisi = markaSayisi;

            var kritikSeviye = context.Uruns.Count(z => z.Stok <=20).ToString();
            ViewBag.kritikSeviye = kritikSeviye;

            var maksFiyat = (from x in context.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.maksFiyat = maksFiyat;

            var minFiyat = (from x in context.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.minFiyat = minFiyat;

            var maksMarka = context.Uruns.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.maksMarka = maksMarka;

            var buzdolabiSayisi = context.Uruns.Count(x=>x.UrunAd == "Buzdolabı").ToString();
            ViewBag.buzdolabiSayisi = buzdolabiSayisi;

            var laptopSayisi = context.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.laptopSayisi = buzdolabiSayisi;

            var enCokSatan = context.Uruns.Where(u=>u.UrunID== (context.SatisHarekets.GroupBy(x => x.UrunID)).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault()).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.enCokSatan = enCokSatan;

            var kasaTutar = context.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.kasaTutar = kasaTutar;

            DateTime bugun = DateTime.Today;

            var bugunkiSatis = context.SatisHarekets.Count(x=>x.Tarih == bugun).ToString();
            ViewBag.bugunkiSatis = bugunkiSatis;


            var tarih = context.SatisHarekets.Select(x => x.Tarih).ToString();
            if (tarih == bugun.ToString())
            {
                var bugunkiKasa = context.SatisHarekets.Where(x => x.Tarih == bugun).Sum(x => x.ToplamTutar).ToString();
                ViewBag.bugunkiKasa = bugunkiKasa;
            }
            else
            {
                var bugunkiKasa = 0;
                ViewBag.bugunkiKasa = bugunkiKasa;
            }
            return View();
        }
    }
}