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
    public class TransportsController : ApiController
    {
        private TripContext db = new TripContext();

        // GET: api/Transports
        public IQueryable<Transport> GetTransports()
        {
            return db.Transports;
        }

        // GET: api/Transports/5
        [ResponseType(typeof(Transport))]
        public IHttpActionResult GetTransport(Guid id)
        {
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return NotFound();
            }

            return Ok(transport);
        }

        // PUT: api/Transports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransport(Guid id, Transport transport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transport.Id)
            {
                return BadRequest();
            }

            db.Entry(transport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportExists(id))
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

        // POST: api/Transports
        [ResponseType(typeof(Transport))]
        public IHttpActionResult PostTransport(Transport transport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Transports.Add(transport);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TransportExists(transport.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = transport.Id }, transport);
        }

        // DELETE: api/Transports/5
        [ResponseType(typeof(Transport))]
        public IHttpActionResult DeleteTransport(Guid id)
        {
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return NotFound();
            }

            db.Transports.Remove(transport);
            db.SaveChanges();

            return Ok(transport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransportExists(Guid id)
        {
            return db.Transports.Count(e => e.Id == id) > 0;
        }
    }
}