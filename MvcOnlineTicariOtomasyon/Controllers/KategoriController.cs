using MvcOnlineTicariOtomasyon.Models.Siniflar;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context context = new Context();  // Database tablolarını context içersinde tutarız.
        public ActionResult Index(int sayfa = 1)
        {
            var kategoriler = context.Kategoris.ToList().ToPagedList(sayfa,10);
            return View(kategoriler);
        }
        [HttpGet]                     
        public ActionResult kategoriEkle()   // Burası çalıştığında sadece boş bir sayfa gelecek    
        {
            return View();
        }
        [HttpPost]
        public ActionResult kategoriEkle(Kategori kategori)  //Bir butona tıklayınca burayı çalıştırır.
        {
            context.Kategoris.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kategoriSil(int ID)
        {
            var silinecekKategori = context.Kategoris.Find(ID);
            context.Kategoris.Remove(silinecekKategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult kategoriGetir(int ID)
        {
            var kategori = context.Kategoris.Find(ID);
            return View("kategoriGetir",kategori);
        }
        public ActionResult kategoriGuncelle(Kategori kategori)
        {
            var bulunacakKategori = context.Kategoris.Find(kategori.KategoriID);
            bulunacakKategori.KategoriAd = kategori.KategoriAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}