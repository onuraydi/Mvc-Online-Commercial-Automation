using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context context = new Context();
        public ActionResult Index()
        {
            var departmanlar = context.Departmans.Where(d=>d.DepartmanDurum==true).ToList();
            return View(departmanlar);
        }
        [HttpGet]
        public ActionResult departmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult departmanEkle(Departman departman)
        {
            context.Departmans.Add(departman);
            departman.DepartmanDurum = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult departmanSil(int ID)
        {
            var silinecekDepartman = context.Departmans.Find(ID);
            silinecekDepartman.DepartmanDurum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult departmanGetir(int ID)
        {
            var guncellenecekDepartman = context.Departmans.Find(ID);
            return View("departmanGetir", guncellenecekDepartman);
        }
        public ActionResult departmanGuncelle(Departman departman)
        {
            var guncellenecekDepartman = context.Departmans.Find(departman.DepartmanID);
            guncellenecekDepartman.DepartmanAd = departman.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult departmanDetay(int ID)
        {
            var getirilecekPersonel = context.Personels.Where(x => x.DepartmanId == ID).ToList();
            var departmanAdi = context.Departmans.Where(x => x.DepartmanID == ID).Select(y => y.DepartmanAd).FirstOrDefault(); 
            // bu kullanımda normalde bir liste yapısı çekilir ancak bize tek değer lazım olduğu için FirstOrDefault kullandık.
            ViewBag.DepartmanAd = departmanAdi;
            return View(getirilecekPersonel);
        }
        public ActionResult DepartmanIcınPersonelSatis(int ID)
        {
            var degerler = context.SatisHarekets.Where(x => x.PersonelID == ID).ToList();
            var personel = context.Personels.Where(x => x.PersonelID == ID).Select(y=> y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.Personel = personel;
            return View(degerler);
        }
    }
}