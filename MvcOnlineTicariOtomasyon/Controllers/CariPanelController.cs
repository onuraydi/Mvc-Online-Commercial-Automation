using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel

        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mailSession = (string)Session["CariMail"];
            var cariDegerleri = context.mesajs.Where(x => x.Alici == mailSession).ToList();
            ViewBag.MailSession = mailSession;

            var mailID = context.Caris.Where(x=>x.CariMail == mailSession).Select(y=>y.CariID).FirstOrDefault();
            ViewBag.MailID = mailID;

            var toplamSatis = context.SatisHarekets.Where(x=> x.CariID == mailID).Count();
            ViewBag.toplamSatis = toplamSatis;

            var toplamOdeme = context.SatisHarekets.Where(x => x.CariID == mailID).Sum(y => y.ToplamTutar);
            ViewBag.toplamOdeme = toplamOdeme;

            var toplamUrun = context.SatisHarekets.Where(x => x.CariID == mailID).Sum(y => y.Adet);
            ViewBag.toplamUrun = toplamUrun;

            var adSoyad = context.Caris.Where(x=>x.CariMail == mailSession).Select(y=> y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adSoyad = adSoyad;

            var sehir = context.Caris.Where(x => x.CariMail == mailSession).Select(y => y.CariSehir).FirstOrDefault();
            ViewBag.sehir = sehir;
            return View(cariDegerleri);
        }

        public ActionResult siparislerim()
        {
            var session = (string)Session["CariMail"];
            var id = context.Caris.Where(x => x.CariMail == session.ToString()).Select(y => y.CariID).FirstOrDefault();
            var siparisler = context.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(siparisler);
        }

        public ActionResult mesajListesi()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = context.mesajs.Where(x => x.Alici == mail).OrderByDescending(x => x.Tarih).ToList();
            var gelenMesajSayisi = context.mesajs.Count(x => x.Alici == mail).ToString();
            var gidenMesajSayisi = context.mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;
            return View(mesajlar);
        }

        public ActionResult gidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = context.mesajs.Where(x => x.Gonderici == mail).OrderByDescending(x => x.Tarih).ToList();
            var gelenMesajSayisi = context.mesajs.Count(x => x.Alici == mail).ToString();
            var gidenMesajSayisi = context.mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesajSayisi = gidenMesajSayisi;
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;
            return View(mesajlar);
        }

        public ActionResult mesajDetay(int id)
        {
            var degerler = context.mesajs.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelenMesajSayisi = context.mesajs.Count(x => x.Alici == mail).ToString();
            var gidenMesajSayisi = context.mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesajSayisi = gidenMesajSayisi;
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult yeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelenMesajSayisi = context.mesajs.Count(x => x.Alici == mail).ToString();
            var gidenMesajSayisi = context.mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesajSayisi = gidenMesajSayisi;
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;
            return View();
        }
        [HttpPost]
        public ActionResult yeniMesaj(Mesaj mesaj)
        {
            var mail = (string)Session["CariMail"];
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesaj.Gonderici = mail;
            context.mesajs.Add(mesaj);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kargoTakip(string parametre)
        {
            var kargolar = from x in context.kargoDetays select x;

            kargolar = kargolar.Where(x => x.TakipKodu.Contains(parametre));

            return View(kargolar.ToList());
        }

        public ActionResult kargoTakipDetay(string id)
        {
            var kargoDetay = context.kargoTakips.Where(x => x.KargoTakipKodu == id).ToList();
            return View(kargoDetay);
        }

        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

        public PartialViewResult cariAyarlari()
        {
            var mailSession = (string)Session["CariMail"];
            var cariId = context.Caris.Where(x=>x.CariMail == mailSession).Select(y=>y.CariID).FirstOrDefault();
            var cariBul = context.Caris.Find(cariId);
            return PartialView("cariAyarlari",cariBul);   
        }

        public PartialViewResult duyurular()
        {
            var veriler = context.mesajs.Where(x =>x.Gonderici =="Admin").ToList();
            return PartialView(veriler);
        }

        public ActionResult cariBilgiGuncelle(Cari cari)
        {
            var guncellenecekCari = context.Caris.Find(cari.CariID);
            guncellenecekCari.CariAd = cari.CariAd;
            guncellenecekCari.CariSoyad = cari.CariSoyad;
            guncellenecekCari.CariSehir = cari.CariSehir;
            guncellenecekCari.CariMail = cari.CariMail;
            guncellenecekCari.CariSifre = cari.CariSifre;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}