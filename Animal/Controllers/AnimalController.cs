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
    public class AnimalController : Controller
    {
        private bancoAnimalEntities db = new bancoAnimalEntities();

        // GET: Animal
        public ActionResult Index()
        {
            var animal = db.Animal.Include(a => a.Especie).Include(a => a.Sexo).Include(a => a.StatusAnimal);
            return View(animal.ToList());
        }

        // GET: Animal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal.Models.Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            ViewBag.Esp_idEspecie = new SelectList(db.Especie, "idEspecie", "nomeVulgar");
            ViewBag.sex_idSexo = new SelectList(db.Sexo, "idSexo", "descricao");
            ViewBag.StA_idStatusAnimal = new SelectList(db.StatusAnimal, "idStatusAnimal", "descricao");
            ViewBag.TpI_idTipoIdentificador = new SelectList(db.TipoIdentificador, "idTipoIdentificador", "descricao");
            return View();
        }

        // POST: Animal/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAnimal,Esp_idEspecie,sex_idSexo,StA_idStatusAnimal")] Animal.Models.Animal animal, [Bind(Include = "codigoIdentificador,TpI_idTipoIdentificador")] IdentificadorAnimal identificadorAnimal)
        {
            if (ModelState.IsValid)
            {
                db.Animal.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Esp_idEspecie = new SelectList(db.Especie, "idEspecie", "nomeVulgar", animal.Esp_idEspecie);
            ViewBag.sex_idSexo = new SelectList(db.Sexo, "idSexo", "descricao", animal.sex_idSexo);
            ViewBag.StA_idStatusAnimal = new SelectList(db.StatusAnimal, "idStatusAnimal", "descricao", animal.StA_idStatusAnimal);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal.Models.Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.Esp_idEspecie = new SelectList(db.Especie, "idEspecie", "nomeVulgar", animal.Esp_idEspecie);
            ViewBag.sex_idSexo = new SelectList(db.Sexo, "idSexo", "descricao", animal.sex_idSexo);
            ViewBag.StA_idStatusAnimal = new SelectList(db.StatusAnimal, "idStatusAnimal", "descricao", animal.StA_idStatusAnimal);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAnimal,Esp_idEspecie,sex_idSexo,StA_idStatusAnimal")] Animal.Models.Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Esp_idEspecie = new SelectList(db.Especie, "idEspecie", "nomeVulgar", animal.Esp_idEspecie);
            ViewBag.sex_idSexo = new SelectList(db.Sexo, "idSexo", "descricao", animal.sex_idSexo);
            ViewBag.StA_idStatusAnimal = new SelectList(db.StatusAnimal, "idStatusAnimal", "descricao", animal.StA_idStatusAnimal);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal.Models.Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal.Models.Animal animal = db.Animal.Find(id);
            db.Animal.Remove(animal);
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
