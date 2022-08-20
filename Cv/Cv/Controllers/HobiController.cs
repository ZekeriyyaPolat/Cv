using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using Cv.Repositories;


namespace Cv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<Hobi> repo = new GenericRepository<Hobi>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }

        [HttpPost]
        public ActionResult Index(Hobi p)
        {
            var bul = repo.Find(x => x.Id == 1);
            bul.Aciklama1 = p.Aciklama2;
            bul.Aciklama2 = p.Aciklama2;
            repo.TUpdate(bul);
            return RedirectToAction("Index");
        }
    }
}