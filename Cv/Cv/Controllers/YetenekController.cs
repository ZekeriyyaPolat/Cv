using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using Cv.Repositories;


namespace Cv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        CvEntities c = new CvEntities();
        GenericRepository<Yetenekler> repo = new GenericRepository<Yetenekler>();
        public ActionResult Index()
        {

            //var yetenek = c.Yetenekler.ToList();
            var yetenek = repo.List();
            return View(yetenek);
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YetenekEkle(Yetenekler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }


        public ActionResult YetenekSil(int id)
        {
            var t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            var a = repo.Find(x => x.Id == id);
            return View(a);
        }
        [HttpPost]
        public ActionResult YetenekGuncelle(Yetenekler p)
        {
            var a=repo.Find(x => x.Id == p.Id);
            a.Yetenek = p.Yetenek;
            a.İlerleme = p.İlerleme;
            repo.TUpdate(a);
            return RedirectToAction("Index");
        }
    }
}