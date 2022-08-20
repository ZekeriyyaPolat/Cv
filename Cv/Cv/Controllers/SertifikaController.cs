using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Repositories;
using Cv.Models.Entity;

namespace Cv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika

        GenericRepository<Sertifika> repo = new GenericRepository<Sertifika>();
        public ActionResult Index()
        {
            var sertifika=repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
             var sertifika=repo.Find(x => x.Id == id);
            return View(sertifika);  
        }

        [HttpPost]
        public ActionResult SertifikaGetir(Sertifika p)
        {
            var sertifika = repo.Find(x => x.Id == p.Id);

            sertifika.Tarih = p.Tarih;
            sertifika.Aciklama= p.Aciklama;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(Sertifika p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }


        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.Id == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }

    }
}