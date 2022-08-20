using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using System.Web.Security;

namespace Cv.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            CvEntities c = new CvEntities();
            var login = c.Admin.Where(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre).FirstOrDefault();
            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.KullaniciAdi, false);
                Session["KullaniciAdi"] = login.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Deneyim");
            }
            else
            {
                ViewBag.d1 = "hatalı giriş";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
     }
}