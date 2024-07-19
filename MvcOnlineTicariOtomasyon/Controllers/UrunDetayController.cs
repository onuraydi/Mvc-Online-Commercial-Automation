using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{

    public class UrunDetayController : Controller
    {
        Context context = new Context();    // GET: UrunDetay
        public ActionResult Index()
        {
            Detay2 detay2 = new Detay2();

            detay2.Deger1 = context.Uruns.Where(x=>x.UrunID == 9).ToList();
            detay2.Deger2 = context.detays.Where(y=> y.DetayID== 1).ToList();

           // var detaylar = context.Uruns.Where(x=> x.UrunID == 9).ToList();
            return View(detay2);
        }
    }
}