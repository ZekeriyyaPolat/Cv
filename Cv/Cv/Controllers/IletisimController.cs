using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using Cv.Repositories;

namespace Cv.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim

        GenericRepository<İletişim> repo = new GenericRepository<İletişim>();
        public ActionResult Index()
        {
            var mesaj = repo.List();
            return View(mesaj);
        }
    }
}