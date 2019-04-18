using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifBlog.Models;

namespace TarifBlog.Controllers
{
    public class HomeController : Controller
    {
        TarifContext db = new TarifContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult İletisim()
        {
            return View();
        }
        public ActionResult KategoriPartial()
        {
            return PartialView(db.Kategori.ToList());
        }
    }
}