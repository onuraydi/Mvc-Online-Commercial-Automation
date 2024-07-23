using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult cariKayit()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult cariKayit(Cari cari)
        {
            context.Caris.Add(cari);
            cari.CariDurum = true;
            context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult cariGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult cariGiris(Cari cari)
        {
            var cariBilgileri = context.Caris.FirstOrDefault(x => x.CariMail == cari.CariMail && x.CariSifre == cari.CariSifre);
            if(cariBilgileri != null)
            {
                FormsAuthentication.SetAuthCookie(cariBilgileri.CariMail, false);
                Session["CariMail"] = cariBilgileri.CariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            return RedirectToAction("Index","Login");
        }

        [HttpGet]
        public ActionResult personelGirisi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult personelGirisi(Admin admin)
        {
            var personelBilgileri = context.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
            if (personelBilgileri != null)
            {
                FormsAuthentication.SetAuthCookie(personelBilgileri.KullaniciAd, false);
                Session["KullaniciAd"] = personelBilgileri.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}