    using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context context = new Context();
        public ActionResult Index()
        {
            var personeller = context.Personels.Where(x => x.PersonelDurum==true).ToList();
            return View(personeller);
        }
        [HttpGet]
        public ActionResult personelEkle()
        {
            List<SelectListItem> departman = (from x in context.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanID.ToString()
                                              }).ToList();
            ViewBag.departman = departman;
            return View();
        }

        [HttpPost]
        public ActionResult personelEkle(Personel personel)
        {
            if(Request.Files.Count>0)   // yaptığımız işlemler içinde bir dosya tutyorsak
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);  // dosya adı aldık
                string uzanti = Path.GetExtension(Request.Files[0].FileName);  // uzantı aldık
                string yol = "~/Image/" +dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelGorsel = "/Image/" + dosyaAdi + uzanti;
            }
            context.Personels.Add(personel);
            personel.PersonelDurum = true;  
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelGetir(int ID)
        {
            var guncellenecekPersonel = context.Personels.Find(ID);
            List<SelectListItem> departman = (from x in context.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanID.ToString()
                                              }).ToList();
            ViewBag.departman = departman;
            return View("personelGetir",guncellenecekPersonel);
        }

        public ActionResult personelGuncelle(Personel personel)
        {
            if (Request.Files.Count > 0)   // yaptığımız işlemler içinde bir dosya tutyorsak
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);  // dosya adı aldık
                string uzanti = Path.GetExtension(Request.Files[0].FileName);  // uzantı aldık
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelGorsel = "/Image/" + dosyaAdi + uzanti;
            }

            var guncellenecekPersonel = context.Personels.Find(personel.PersonelID);
            guncellenecekPersonel.PersonelAd = personel.PersonelAd;
            guncellenecekPersonel.PersonelSoyad= personel.PersonelSoyad;
            guncellenecekPersonel.DepartmanId= personel.DepartmanId;
            guncellenecekPersonel.PersonelGorsel= personel.PersonelGorsel;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelSil(int ID)
        {
            var silinecekPersonel = context.Personels.Find(ID);
            silinecekPersonel.PersonelDurum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelDetayliListe()
        {
            var personelDetay = context.Personels.ToList();
            return View(personelDetay);
        }
    }
}