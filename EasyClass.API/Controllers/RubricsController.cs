using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EasyClass.Common.Models;
using EasyClass.Domain.Models;

namespace EasyClass.API.Controllers
{
    public class RubricsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Rubrics
        public IQueryable<Rubric> GetRubrics()
        {
            return db.Rubrics;
        }

        // GET: api/Rubrics/5
        [ResponseType(typeof(Rubric))]
        public async Task<IHttpActionResult> GetRubric(int id)
        {
            Rubric rubric = await db.Rubrics.FindAsync(id);
            if (rubric == null)
            {
                return NotFound();
            }

            return Ok(rubric);
        }

        // PUT: api/Rubrics/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRubric(int id, Rubric rubric)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rubric.RubricId)
            {
                return BadRequest();
            }

            db.Entry(rubric).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RubricExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Rubrics
        [ResponseType(typeof(Rubric))]
        public async Task<IHttpActionResult> PostRubric(Rubric rubric)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rubrics.Add(rubric);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rubric.RubricId }, rubric);
        }

        // DELETE: api/Rubrics/5
        [ResponseType(typeof(Rubric))]
        public async Task<IHttpActionResult> DeleteRubric(int id)
        {
            Rubric rubric = await db.Rubrics.FindAsync(id);
            if (rubric == null)
            {
                return NotFound();
            }

            db.Rubrics.Remove(rubric);
            await db.SaveChangesAsync();

            return Ok(rubric);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RubricExists(int id)
        {
            return db.Rubrics.Count(e => e.RubricId == id) > 0;
        }
    }
}