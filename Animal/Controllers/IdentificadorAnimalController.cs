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
    public class IdentificadorAnimalController : Controller
    {
        private bancoAnimalEntities db = new bancoAnimalEntities();

        // GET: IdentificadorAnimal
        public ActionResult Index()
        {
            var identificadorAnimal = db.IdentificadorAnimal.Include(i => i.Animal).Include(i => i.TipoIdentificador);
            return View(identificadorAnimal.ToList());
        }

        // GET: IdentificadorAnimal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentificadorAnimal identificadorAnimal = db.IdentificadorAnimal.Find(id);
            if (identificadorAnimal == null)
            {
                return HttpNotFound();
            }
            return View(identificadorAnimal);
        }

        // GET: IdentificadorAnimal/Create
        public ActionResult Create()
        {
            ViewBag.Ani_idAnimal = new SelectList(db.Animal, "idAnimal", "idAnimal");
            ViewBag.TpI_idTipoIdentificador = new SelectList(db.TipoIdentificador, "idTipoIdentificador", "descricao");
            return View();
        }

        // POST: IdentificadorAnimal/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idIdentificadorAnimal,codigoIdentificador,Ani_idAnimal,TpI_idTipoIdentificador")] IdentificadorAnimal identificadorAnimal)
        {
            if (ModelState.IsValid)
            {
                db.IdentificadorAnimal.Add(identificadorAnimal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ani_idAnimal = new SelectList(db.Animal, "idAnimal", "idAnimal", identificadorAnimal.Ani_idAnimal);
            ViewBag.TpI_idTipoIdentificador = new SelectList(db.TipoIdentificador, "idTipoIdentificador", "descricao", identificadorAnimal.TpI_idTipoIdentificador);
            return View(identificadorAnimal);
        }

        // GET: IdentificadorAnimal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentificadorAnimal identificadorAnimal = db.IdentificadorAnimal.Find(id);
            if (identificadorAnimal == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ani_idAnimal = new SelectList(db.Animal, "idAnimal", "idAnimal", identificadorAnimal.Ani_idAnimal);
            ViewBag.TpI_idTipoIdentificador = new SelectList(db.TipoIdentificador, "idTipoIdentificador", "descricao", identificadorAnimal.TpI_idTipoIdentificador);
            return View(identificadorAnimal);
        }

        // POST: IdentificadorAnimal/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idIdentificadorAnimal,codigoIdentificador,Ani_idAnimal,TpI_idTipoIdentificador")] IdentificadorAnimal identificadorAnimal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(identificadorAnimal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ani_idAnimal = new SelectList(db.Animal, "idAnimal", "idAnimal", identificadorAnimal.Ani_idAnimal);
            ViewBag.TpI_idTipoIdentificador = new SelectList(db.TipoIdentificador, "idTipoIdentificador", "descricao", identificadorAnimal.TpI_idTipoIdentificador);
            return View(identificadorAnimal);
        }

        // GET: IdentificadorAnimal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentificadorAnimal identificadorAnimal = db.IdentificadorAnimal.Find(id);
            if (identificadorAnimal == null)
            {
                return HttpNotFound();
            }
            return View(identificadorAnimal);
        }

        // POST: IdentificadorAnimal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdentificadorAnimal identificadorAnimal = db.IdentificadorAnimal.Find(id);
            db.IdentificadorAnimal.Remove(identificadorAnimal);
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
