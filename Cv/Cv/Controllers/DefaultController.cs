using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;

namespace Cv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        CvEntities db = new CvEntities();

        
        public ActionResult Index()
        {
            var deger = db.Hakkimda.ToList();
            return View(deger);
        }

        public PartialViewResult Deneyim()
        {
            var degerler = db.Deneyimler.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Eğitimlerim()
        {
            var degerler = db.Egitim.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var degerler = db.Yetenekler.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Hobilerim()
        {
            var degerler = db.Hobi.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Sertifikalar()
        {
            var degerler = db.Sertifika.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult SosyalMedya()
        {
            var degerler = db.SosyalMedya.ToList();
            return PartialView(degerler);
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Iletisim(İletişim p)
        {
            p.Tarih = DateTime.Parse(DateTime.Today.ToShortDateString());
            db.İletişim.Add(p);
            db.SaveChanges();
            return PartialView();
        }


    }
}