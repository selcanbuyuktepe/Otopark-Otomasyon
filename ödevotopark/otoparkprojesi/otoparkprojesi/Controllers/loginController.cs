using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using otoparkprojesi.DAL;



namespace otoparkprojesi.Controllers
{
    public class loginController : Controller
    {
        private otoparkEntities db = new otoparkEntities();
        // GET: login
        public ActionResult GİRİS()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GİRİS(yonetici model)
        {
            var yonetici = db.yonetici.FirstOrDefault(x => x.yoneticiAdSoyad == model.yoneticiAdSoyad && x.parola == model.parola);
            if(yonetici != null)
            {
                Session["yoneticiAdSoyad"] = yonetici;
                return RedirectToAction("Index", "musteris");
            }
            ViewBag.HATA("yoneticiAdSoyad veya parola hatalı");
            return View();
        }
    }
}