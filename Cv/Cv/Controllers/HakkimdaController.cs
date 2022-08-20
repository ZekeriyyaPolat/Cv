using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using Cv.Repositories;

namespace Cv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<Hakkimda> repo = new GenericRepository<Hakkimda>();
        [HttpGet]
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }
        [HttpPost]
        public ActionResult Index(Hakkimda p)
        {
            var bul = repo.Find(x => x.Id == 1);
            bul.Ad = p.Ad;
            bul.Soyad = p.Soyad;
            bul.Adres = p.Adres;
            bul.Mail = p.Mail;
            bul.Telefon = p.Telefon;
            bul.Aciklama = p.Aciklama;
            repo.TUpdate(bul);
            return RedirectToAction("Index");
        }
    }
}