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
    public class AlunoController : Controller
    {
        private sistemaMatriculaDesktop db = new sistemaMatriculaDesktop();

        // GET: Aluno
        public ActionResult Index()
        {
            var aluno = db.aluno.Include(a => a.contato).Include(a => a.endereco).Include(a => a.turma);
            return View(aluno.ToList());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno aluno = db.aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            ViewBag.contato_id = new SelectList(db.contato, "id", "fone1");
            ViewBag.endereco_id = new SelectList(db.endereco, "id", "cep");
            ViewBag.turma_id = new SelectList(db.turma, "id", "nome");
            return View();
        }

        // POST: Aluno/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,turma_id,endereco_id,contato_id,nomeAluno,nomeResponsavel,cpfAluno,cpfResponsavel,sexo,dataNascimento,dataMatricula,dataSaida,matricula,beneficios,restricoes,situacao")] aluno aluno, contato contato, endereco endereco)
        {
            if (ModelState.IsValid)
            {

                List<aluno> alunoLista = new List<aluno>();
                string queryAluno = "SELECT * FROM aluno WHERE cpfAluno = '" + aluno.cpfAluno + "'";
                var alunoBanco = db.aluno.SqlQuery(queryAluno).ToList();

                foreach (var item in alunoBanco)
                {
                    alunoLista.Add(item);
                }

                if(alunoLista.Count == 0)
                {
                    List<endereco> enderecoLista = new List<endereco>();
                    db.endereco.Add(endereco);
                    db.SaveChanges();
                    string enderecoQuery = "SELECT * FROM endereco WHERE cep = '" + endereco.cep + "' AND descricao = '" + endereco.descricao + "' AND numero = '" + endereco.numero + "' ";
                    var enderecoBanco = db.endereco.SqlQuery(enderecoQuery).ToList();

                    foreach (var item in enderecoBanco)
                    {
                        enderecoLista.Add(item);
                    }

                    List<contato> contatoLista = new List<contato>();
                    db.contato.Add(contato);
                    db.SaveChanges();
                    string contatoQuery = "SELECT * FROM contato WHERE contato1 = '" + contato.contato1 + "' AND contato2 = '" + contato.contato2 + "' ";
                    var contatoBanco = db.contato.SqlQuery(contatoQuery).ToList();

                    foreach (var item in contatoBanco)
                    {
                        contatoLista.Add(item);
                    }

                    aluno.situacao = true;
                    aluno.contato_id = contatoLista[0].id;
                    aluno.endereco_id = enderecoLista[0].id;

                    db.aluno.Add(aluno);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                
            }

            ViewBag.contato_id = new SelectList(db.contato, "id", "fone1", aluno.contato_id);
            ViewBag.endereco_id = new SelectList(db.endereco, "id", "cep", aluno.endereco_id);
            ViewBag.turma_id = new SelectList(db.turma, "id", "nome", aluno.turma_id);
            return View(aluno);
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno aluno = db.aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.contato_id = new SelectList(db.contato, "id", "fone1", aluno.contato_id);
            ViewBag.endereco_id = new SelectList(db.endereco, "id", "cep", aluno.endereco_id);
            ViewBag.turma_id = new SelectList(db.turma, "id", "nome", aluno.turma_id);
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,turma_id,endereco_id,contato_id,nomeAluno,nomeResponsavel,cpfAluno,cpfResponsavel,sexo,dataNascimento,dataMatricula,dataSaida,matricula,beneficios,restricoes,situacao")] aluno aluno, endereco endereco, contato contato)
        {
            if (ModelState.IsValid)
            {
                contato.id = aluno.contato_id;
                endereco.id = aluno.endereco_id;
                db.Entry(contato).State = EntityState.Modified;
                db.Entry(endereco).State = EntityState.Modified;
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contato_id = new SelectList(db.contato, "id", "fone1", aluno.contato_id);
            ViewBag.endereco_id = new SelectList(db.endereco, "id", "cep", aluno.endereco_id);
            ViewBag.turma_id = new SelectList(db.turma, "id", "nome", aluno.turma_id);
            return View(aluno);
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno aluno = db.aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aluno aluno = db.aluno.Find(id);
            db.aluno.Remove(aluno);
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
