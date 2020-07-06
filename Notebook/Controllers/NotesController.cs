using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Notebook.Models;

namespace Notebook.Controllers
{
    //Контролер для работы с БД и отправки данных на Vue
    public class NotesController : Controller
    {
        private NotebookDbContext db = new NotebookDbContext();

        // GET: Notes
        public async Task<ActionResult> Index()
        {
            return Json(await db.Notes.ToListAsync(),JsonRequestBehavior.AllowGet);
        }

        // GET: Notes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = await db.Notes.FindAsync(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return Json(note,JsonRequestBehavior.AllowGet);
        }

        // POST: Notes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FirstName,LastName,Phone,Email")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(note);
                await db.SaveChangesAsync();
                return new HttpStatusCodeResult(200);
                //return CreatedAtRoute("DefaultApi", new { id = note.Id }, note);
            }

            return HttpNotFound();
        }

        // POST: Notes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Phone,Email")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return new HttpStatusCodeResult(200);
            }
            return HttpNotFound();
        }

        // POST: Notes/Delete/5
        [HttpDelete, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Note note = await db.Notes.FindAsync(id);
            db.Notes.Remove(note);
            await db.SaveChangesAsync();
            return new HttpStatusCodeResult(200);
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
