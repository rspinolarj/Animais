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
    public class StatusAnimalController : Controller
    {
        private bancoAnimalEntities db = new bancoAnimalEntities();

        // GET: StatusAnimal
        public ActionResult Index()
        {
            return View(db.StatusAnimal.ToList());
        }

        // GET: StatusAnimal/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusAnimal statusAnimal = db.StatusAnimal.Find(id);
            if (statusAnimal == null)
            {
                return HttpNotFound();
            }
            return View(statusAnimal);
        }

        // GET: StatusAnimal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusAnimal/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idStatusAnimal,descricao")] StatusAnimal statusAnimal)
        {
            if (ModelState.IsValid)
            {
                db.StatusAnimal.Add(statusAnimal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusAnimal);
        }

        // GET: StatusAnimal/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusAnimal statusAnimal = db.StatusAnimal.Find(id);
            if (statusAnimal == null)
            {
                return HttpNotFound();
            }
            return View(statusAnimal);
        }

        // POST: StatusAnimal/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStatusAnimal,descricao")] StatusAnimal statusAnimal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusAnimal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusAnimal);
        }

        // GET: StatusAnimal/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusAnimal statusAnimal = db.StatusAnimal.Find(id);
            if (statusAnimal == null)
            {
                return HttpNotFound();
            }
            return View(statusAnimal);
        }

        // POST: StatusAnimal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            StatusAnimal statusAnimal = db.StatusAnimal.Find(id);
            db.StatusAnimal.Remove(statusAnimal);
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
