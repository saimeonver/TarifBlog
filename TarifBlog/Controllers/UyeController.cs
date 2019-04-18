using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifBlog.Models;

namespace TarifBlog.Controllers
{
    public class UyeController : Controller
    {
        TarifContext db = new TarifContext();
        // GET: Uye
        public ActionResult Index(int id)
        {
            var uye = db.Uye.Where(x => x.UyeID == id).SingleOrDefault();
            if (Convert.ToInt32(Session["UyeID"]) != uye.UyeID)
            { return HttpNotFound(); }
            return View(uye);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Uye uye)
        {
            var login = db.Uye.Where(x => x.KullaniciAdi == uye.KullaniciAdi).SingleOrDefault();
            if(login.KullaniciAdi==uye.KullaniciAdi&&login.Email==uye.Email&&login.Sifre==uye.Sifre)
            {
                Session["KullaniciID"] = login.KullaniciAdi;
                Session["YetkiID"] = login.YetkiID;
                Session["UyeID"] = login.UyeID;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Uyari = "Kullanici Adi,Email veya Sifreyi yanlis girdiniz!!!";
                return View();

            }
           
        }
        public ActionResult Logout()
        {
            Session["UyeID"] = null;
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Uye uye)
        {
            if(ModelState.IsValid)
            {
                uye.YetkiID = 2;
                db.Uye.Add(uye);
                db.SaveChanges();
                Session["UyeID"] = uye.UyeID;
                Session["KullaniciAdi"] = uye.KullaniciAdi;
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public ActionResult Edit(int id)
        {
            var uye = db.Uye.Where(x => x.UyeID == id).SingleOrDefault();
            if (Convert.ToInt32(Session["UyeID"]) != uye.UyeID)
            {
                return HttpNotFound();
            }

            return View(uye);
            
        }
        [HttpPost]
        public ActionResult Edit(Uye uye,int id)
        {
            if(ModelState.IsValid)
            {
                var uyes = db.Uye.Where(x => x.UyeID == id).SingleOrDefault();
                uyes.AdSoyad = uye.AdSoyad;
                uyes.KullaniciAdi = uye.KullaniciAdi;
                uyes.Email = uye.Email;
                uyes.Sifre = uye.Sifre;
                db.SaveChanges();
                Session["KullaniciAdi"] = uye.KullaniciAdi;
                return RedirectToAction("Index", "Home", new { id = uyes.UyeID });
            }
            
            return View();
        }
    }
}