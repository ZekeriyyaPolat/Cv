using Cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;

namespace Cv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim

        DeneyimRepository dp = new DeneyimRepository();
        GenericRepository<Deneyimler> repo = new GenericRepository<Deneyimler>();  //??
        public ActionResult Index()
        {
            var deger = dp.List();
            return View(deger);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(Deneyimler d)
        {
            dp.TAdd(d);

            return RedirectToAction("Index");
        }


        public ActionResult DeneyimSil(int id)
        {
            var t = dp.Find(x => x.İd == id);
            dp.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Deneyimler t = dp.Find(x => x.İd == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(Deneyimler p)
        {
            Deneyimler t = dp.Find(x => x.İd == p.İd);
            t.Baslik = p.Baslik;
            t.Altbaslik = p.Altbaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            dp.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}