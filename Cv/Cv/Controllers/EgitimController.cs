using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Repositories;
using Cv.Models.Entity;


namespace Cv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim

        GenericRepository<Egitim> repo = new GenericRepository<Egitim>();
        CvEntities c = new CvEntities();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(Egitim p)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.d1 = "zorunlu alan";
                return View();
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {

            var t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGuncelle(int id)
        {
            var egitim = repo.Find(x => x.Id == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimGuncelle(Egitim p)
        {
            var a = repo.Find(x => x.Id == p.Id);
            a.Baslik = p.Baslik;
            a.Altbaslik1 = p.Altbaslik1;
            a.Altbaslik2 = p.Altbaslik2;
            a.GenelNotOrt = p.GenelNotOrt;
            a.Tarih = p.Tarih;
            repo.TUpdate(a);
            return RedirectToAction("Index");
        }
    }
}