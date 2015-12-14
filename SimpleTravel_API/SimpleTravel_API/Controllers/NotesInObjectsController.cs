using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SimpleTravel.Infrastructure.Entities;
using SimpleTravel.Infrastructure.Repositories.Implementation;

namespace SimpleTravel_API.Controllers
{
    public class NotesInObjectsController : ApiController
    {
        private TripContext db = new TripContext();

        // GET: api/NotesInObjects
        public IQueryable<NotesInObject> GetNotesInObjects()
        {
            return db.NotesInObjects;
        }

        // GET: api/NotesInObjects/5
        [ResponseType(typeof(NotesInObject))]
        public IHttpActionResult GetNotesInObject(Guid id)
        {
            NotesInObject notesInObject = db.NotesInObjects.Find(id);
            if (notesInObject == null)
            {
                return NotFound();
            }

            return Ok(notesInObject);
        }

        // PUT: api/NotesInObjects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNotesInObject(Guid id, NotesInObject notesInObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notesInObject.Id)
            {
                return BadRequest();
            }

            db.Entry(notesInObject).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesInObjectExists(id))
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

        // POST: api/NotesInObjects
        [ResponseType(typeof(NotesInObject))]
        public IHttpActionResult PostNotesInObject(NotesInObject notesInObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NotesInObjects.Add(notesInObject);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NotesInObjectExists(notesInObject.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = notesInObject.Id }, notesInObject);
        }

        // DELETE: api/NotesInObjects/5
        [ResponseType(typeof(NotesInObject))]
        public IHttpActionResult DeleteNotesInObject(Guid id)
        {
            NotesInObject notesInObject = db.NotesInObjects.Find(id);
            if (notesInObject == null)
            {
                return NotFound();
            }

            db.NotesInObjects.Remove(notesInObject);
            db.SaveChanges();

            return Ok(notesInObject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotesInObjectExists(Guid id)
        {
            return db.NotesInObjects.Count(e => e.Id == id) > 0;
        }
    }
}