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
    }
}