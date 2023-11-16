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
using SUVCServiceAPI.Entities;
using SUVCServiceAPI.Models;

namespace SUVCServiceAPI.Controllers
{
    public class RequestsController : ApiController
    {
        private SUVCServiceDbEntities db = new SUVCServiceDbEntities();

        // GET: api/Requests
        [ResponseType(typeof(List<ResponseRequests>))]
        public IHttpActionResult GetRequests()
        {
            return Ok(db.Requests.ToList().ConvertAll(p => new ResponseRequests(p)));
        }

        // GET: api/Requests/5
        [ResponseType(typeof(Requests))]
        public IHttpActionResult GetRequests(int id)
        {
            Requests requests = db.Requests.Find(id);
            if (requests == null)
            {
                return NotFound();
            }

            return Ok(requests);
        }

        // PUT: api/Requests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequests(int id, Requests requests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requests.ID)
            {
                return BadRequest();
            }

            db.Entry(requests).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestsExists(id))
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

        // POST: api/Requests
        [ResponseType(typeof(Requests))]
        public IHttpActionResult PostRequests(Requests requests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Requests.Add(requests);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = requests.ID }, requests);
        }

        // DELETE: api/Requests/5
        [ResponseType(typeof(Requests))]
        public IHttpActionResult DeleteRequests(int id)
        {
            Requests requests = db.Requests.Find(id);
            if (requests == null)
            {
                return NotFound();
            }

            db.Requests.Remove(requests);
            db.SaveChanges();

            return Ok(requests);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestsExists(int id)
        {
            return db.Requests.Count(e => e.ID == id) > 0;
        }
    }
}