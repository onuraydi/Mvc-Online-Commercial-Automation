using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var cariDegerleri = context.Caris.FirstOrDefault(x => x.CariMail == mailSession);
            ViewBag.MailSession = mailSession;
            return View(cariDegerleri);
        }

        public ActionResult siparislerim()
        {
            var session = (string)Session["CariMail"];
            var id = context.Caris.Where(x => x.CariMail == session.ToString()).Select(y => y.CariID).FirstOrDefault();
            var siparisler = context.SatisHarekets.Where(x=>x.CariID == id).ToList();
            return View(siparisler);
        }
        
        public ActionResult mesajListesi()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = context.mesajs.Where(x=>x.Alici==mail).OrderByDescending(x=>x.Tarih).ToList();
            var gelenMesajSayisi = context.mesajs.Count(x => x.Alici == mail).ToString();
            var gidenMesajSayisi = context.mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;
            return View(mesajlar);
        }

        public ActionResult gidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = context.mesajs.Where(x => x.Gonderici == mail).OrderByDescending(x=>x.Tarih).ToList();
            var gelenMesajSayisi = context.mesajs.Count(x => x.Alici == mail).ToString();
            var gidenMesajSayisi = context.mesajs.Count(x => x.Gonderici== mail).ToString();
            ViewBag.gidenMesajSayisi = gidenMesajSayisi;
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;
            return View(mesajlar);
        }

        public ActionResult mesajDetay(int id)
        {
            var degerler = context.mesajs.Where(x=>x.MesajID == id).ToList();
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
    }
}