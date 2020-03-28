using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sistemaMatricula.Models;

namespace sistemaMatricula.Controllers
{
    public class TurmaController : Controller
    {
        private sistemaMatriculaDesktop db = new sistemaMatriculaDesktop();

        // GET: Turma
        public ActionResult Index()
        {
            var turma = db.turma.Include(t => t.disciplina).Include(t => t.funcionario).OrderBy(a => a.nome));
            return View(turma.ToList());
        }

        // GET: Turma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            turma turma = db.turma.Find(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // GET: Turma/Create
        public ActionResult Create()
        {
            ViewBag.aluno_id = new SelectList(db.aluno, "id", "nomeAluno");
            ViewBag.disciplina_id = new SelectList(db.disciplina, "id", "nome");
            ViewBag.funcionario_id = new SelectList(db.funcionario, "id", "nome");
            return View();
        }

        // POST: Turma/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,disciplina_id,funcionario_id,aluno_id,nome,sala,situacao")] turma turma)
        {
            if (ModelState.IsValid)
            {
                db.turma.Add(turma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.disciplina_id = new SelectList(db.disciplina, "id", "nome", turma.disciplina_id);
            ViewBag.funcionario_id = new SelectList(db.funcionario, "id", "nome", turma.funcionario_id);
            return View(turma);
        }

        // GET: Turma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            turma turma = db.turma.Find(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            ViewBag.disciplina_id = new SelectList(db.disciplina, "id", "nome", turma.disciplina_id);
            ViewBag.funcionario_id = new SelectList(db.funcionario, "id", "nome", turma.funcionario_id);
            return View(turma);
        }

        // POST: Turma/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,disciplina_id,funcionario_id,aluno_id,nome,sala,situacao")] turma turma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.disciplina_id = new SelectList(db.disciplina, "id", "nome", turma.disciplina_id);
            ViewBag.funcionario_id = new SelectList(db.funcionario, "id", "nome", turma.funcionario_id);
            return View(turma);
        }

        // GET: Turma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            turma turma = db.turma.Find(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // POST: Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            turma turma = db.turma.Find(id);
            db.turma.Remove(turma);
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
