using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TarifBlog.Models;

namespace TarifBlog.Controllers
{
    public class AdminTarifController : Controller
    {
        TarifContext db = new TarifContext();
        // GET: AdminTarif
        public ActionResult Index()
        {
            var tarifs = db.Tarif.ToList();
            return View(tarifs);
        }

        // GET: AdminTarif/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminTarif/Create
        //ılk acıldıgında yapılan ıslemler burda yapılıyor
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAdi");
            return View();
        }

        // POST: AdminTarif/Create
        [HttpPost]
        public ActionResult Create(Tarif tarif,string etiketler,HttpPostedFileBase Foto)
        {
            
                if(ModelState.IsValid)
                { if(Foto!=null)
                {
                    WebImage img = new WebImage(Foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(Foto.FileName);
                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;//uzantısı demek extensıon
                    img.Resize (800, 350);
                    img.Save("~/Uploads/TarifFoto/" + newfoto);
                    tarif.Foto = "/Uploads/TarifFoto/" + newfoto;
                ViewBag.KategoriId = new SelectList(db.Kategori, "KategoriId", "KategoriAdi");
               
               

                }

                if (etiketler != null)
                {
                    string[] etiketdizi = etiketler.Split(',');
                    foreach (var i in etiketdizi)
                    {
                        var yenietiket = new Etiket { EtiketAdi = i };
                        db.Etiket.Add(yenietiket);
                        //tarif.Etikets.Add(yenietiket);
                    }

                }
                    db.Tarif.Add(tarif);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
               

               
           
                return View(tarif);
            
        }

        // GET: AdminTarif/Edit/5
        public ActionResult Edit(int id)
        {
            var tarif = db.Tarif.Where(x => x.TarifID == id).SingleOrDefault();
            if(tarif==null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategori, "KategoriId", "KategoriAdi",tarif.KategoriID);
            return View(tarif);
        }

        // POST: AdminTarif/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase Foto,Tarif tarif)
        {
            try
            {
                var tarifs = db.Tarif.Where(x => x.TarifID == id).SingleOrDefault();
                if(Foto!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(tarif.Foto))) 
                    {
                        System.IO.File.Delete(Server.MapPath(tarif.Foto));
                    }
                    WebImage img = new WebImage(Foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(Foto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;//uzantısı demek extensıon
                    img.Resize(800, 350);
                    img.Save("~/Uploads/TarifFoto/" + newfoto);
                    tarifs.Foto = "/Uploads/TarifFoto/" + newfoto;
                    tarifs.Malzemeler = tarif.Malzemeler;
                    tarifs.Yapilis = tarif.Yapilis;
                    tarifs.KategoriID = tarif.KategoriID;
                    tarifs.TarifAdi = tarif.TarifAdi;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                ViewBag.KategoriId = new SelectList(db.Kategori, "KategoriId", "KategoriAdi", tarif.KategoriID);
                return View(tarif);
            }
        }

        // GET: AdminTarif/Delete/5
        public ActionResult Delete(int id)
        {
            var tarifs = db.Tarif.Where(x => x.TarifID == id).SingleOrDefault();
            if(tarifs==null)
            {
                return HttpNotFound();
            }
            return View(tarifs);
        }

        // POST: AdminTarif/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var tarifs = db.Tarif.Where(x => x.TarifID == id).SingleOrDefault();
                if(tarifs==null)
                {
                    return HttpNotFound();
                }
                if (System.IO.File.Exists(Server.MapPath(tarifs.Foto))) 
                {
                    System.IO.File.Delete(Server.MapPath(tarifs.Foto));
                }
                foreach (var i in tarifs.Yorum.ToList())
                {
                    db.Yorum.Remove(i);
                }
                foreach (var s in tarifs.Etikets.ToList())
                {
                    db.Etiket.Remove(s);
                }
                db.Tarif.Remove(tarifs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
