using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Animal.Models;

namespace Animal.Controllers
{
    public class TipoIdentificadorController : Controller
    {
        private bancoAnimalEntities db = new bancoAnimalEntities();

        // GET: TipoIdentificador
        public ActionResult Index()
        {
            return View(db.TipoIdentificador.ToList());
        }

        // GET: TipoIdentificador/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIdentificador tipoIdentificador = db.TipoIdentificador.Find(id);
            if (tipoIdentificador == null)
            {
                return HttpNotFound();
            }
            return View(tipoIdentificador);
        }

        // GET: TipoIdentificador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoIdentificador/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoIdentificador,descricao")] TipoIdentificador tipoIdentificador)
        {
            if (ModelState.IsValid)
            {
                db.TipoIdentificador.Add(tipoIdentificador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoIdentificador);
        }

        // GET: TipoIdentificador/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIdentificador tipoIdentificador = db.TipoIdentificador.Find(id);
            if (tipoIdentificador == null)
            {
                return HttpNotFound();
            }
            return View(tipoIdentificador);
        }

        // POST: TipoIdentificador/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoIdentificador,descricao")] TipoIdentificador tipoIdentificador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoIdentificador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoIdentificador);
        }

        // GET: TipoIdentificador/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIdentificador tipoIdentificador = db.TipoIdentificador.Find(id);
            if (tipoIdentificador == null)
            {
                return HttpNotFound();
            }
            return View(tipoIdentificador);
        }

        // POST: TipoIdentificador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            TipoIdentificador tipoIdentificador = db.TipoIdentificador.Find(id);
            db.TipoIdentificador.Remove(tipoIdentificador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
