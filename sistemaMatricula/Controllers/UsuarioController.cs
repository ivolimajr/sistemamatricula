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
    public class UsuarioController : Controller
    {
        private sistemaMatriculaDesktop db = new sistemaMatriculaDesktop();

        // GET: Usuario
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.funcionario).OrderBy(a => a.nome));
            return View(usuario.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.funcionario_id = new SelectList(db.funcionario, "id", "nome");
            return View();
        }

        // POST: Usuario/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,funcionario_id,login,senha,dataCriacao,situacao")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.senha = Crypt.Hash(usuario.senha);
                usuario.situacao = true;
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.funcionario_id = new SelectList(db.funcionario, "id", "nome", usuario.funcionario_id);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.funcionario_id = new SelectList(db.funcionario, "id", "nome", usuario.funcionario_id);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,funcionario_id,login,senha,dataCriacao,situacao")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.senha = Crypt.Hash(usuario.senha);
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.funcionario_id = new SelectList(db.funcionario, "id", "nome", usuario.funcionario_id);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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
