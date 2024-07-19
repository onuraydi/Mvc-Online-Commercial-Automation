using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context context = new Context();
        public ActionResult Index()
        {
            var faturalar = context.Faturalars.ToList();
            return View(faturalar);
        }
        [HttpGet]
        public ActionResult faturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult faturaEkle(Faturalar fatura)
        {
            context.Faturalars.Add(fatura);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult faturaGetir(int id)
        {
            var guncellenecekFatura = context.Faturalars.Find(id);
            return View("faturaGetir",guncellenecekFatura);
        }

        public ActionResult faturaGuncelle(Faturalar fatura)
        {
            var guncellenecekFatura = context.Faturalars.Find(fatura.FaturaID);
            guncellenecekFatura.FaturaSıraNo = fatura.FaturaSıraNo;
            guncellenecekFatura.FaturaSeriNo = fatura.FaturaSeriNo;
            guncellenecekFatura.FaturaTarih = fatura.FaturaTarih;
            guncellenecekFatura.Saat = fatura.Saat;
            guncellenecekFatura.TeslimAlan = fatura.TeslimAlan;
            guncellenecekFatura.TeslimEden = fatura.TeslimEden;
            guncellenecekFatura.Toplam = fatura.Toplam;
            guncellenecekFatura.VergiDairesi = fatura.VergiDairesi;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult faturaDetay(int ID)
        {
            var faturalar = context.FaturaKalems.Where(x => x.FaturaID == ID).ToList();
            return View(faturalar);
        }
        [HttpGet]
        public ActionResult yeniFaturaKalem()
        {
            // fatura ID otomatik olarak çekilebilir
            return View();
        }
        [HttpPost]
        public ActionResult yeniFaturaKalem(FaturaKalem faturaKalem)
        {
            context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}