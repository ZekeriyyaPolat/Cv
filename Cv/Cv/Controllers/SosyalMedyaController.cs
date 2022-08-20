using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using Cv.Repositories;

namespace Cv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya

        GenericRepository<SosyalMedya> repo = new GenericRepository<SosyalMedya>();
        public ActionResult Index()
        {
            var medya = repo.List();
            return View(medya);
        }

        public ActionResult SosyalMedyaEkle(SosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult SosyalMedyaGetir(int id)
        {
            var getir = repo.Find(x => x.Id == id);
            return View(getir);
        }

        [HttpPost]
         public ActionResult SosyalMedyaGetir(SosyalMedya p)
        {
            var getir = repo.Find(x => x.Id == p.Id);
            getir.Ad = p.Ad;
            getir.Link = p.Link;
            getir.İkon = p.İkon;
            repo.TUpdate(getir);
            return RedirectToAction("Index");
        }


        public ActionResult SosyalMedyaSil(int id)
        {
            var sil = repo.Find(x => x.Id == id);
            repo.TDelete(sil);

            return RedirectToAction("Index");
        }

    }
}