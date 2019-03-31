using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyClass.Backend.Models;
using EasyClass.Common.Models;

namespace EasyClass.Backend.Controllers
{
    public class RubricsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Rubrics
        public async Task<ActionResult> Index()
        {
            return View(await db.Rubrics.ToListAsync());
        }

        // GET: Rubrics/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rubric rubric = await db.Rubrics.FindAsync(id);
            if (rubric == null)
            {
                return HttpNotFound();
            }
            return View(rubric);
        }

        // GET: Rubrics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rubrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RubricId,RubricTitle,RubricDescription,RubricDate")] Rubric rubric)
        {
            if (ModelState.IsValid)
            {
                db.Rubrics.Add(rubric);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rubric);
        }

        // GET: Rubrics/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rubric rubric = await db.Rubrics.FindAsync(id);
            if (rubric == null)
            {
                return HttpNotFound();
            }
            return View(rubric);
        }

        // POST: Rubrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RubricId,RubricTitle,RubricDescription,RubricDate")] Rubric rubric)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rubric).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rubric);
        }

        // GET: Rubrics/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rubric rubric = await db.Rubrics.FindAsync(id);
            if (rubric == null)
            {
                return HttpNotFound();
            }
            return View(rubric);
        }

        // POST: Rubrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rubric rubric = await db.Rubrics.FindAsync(id);
            db.Rubrics.Remove(rubric);
            await db.SaveChangesAsync();
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
