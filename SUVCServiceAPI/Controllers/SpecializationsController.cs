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
    public class SpecializationsController : ApiController
    {
        private SUVCServiceDbEntities db = new SUVCServiceDbEntities();

        // GET: api/Specializations
        [ResponseType(typeof(List<ResponseSpecialization>))]
        public IHttpActionResult GetSpecialization()
        {
            return Ok(db.Specialization.ToList().ConvertAll(p => new ResponseSpecialization(p)));
        }

        // GET: api/Specializations/5
        [ResponseType(typeof(Specialization))]
        public IHttpActionResult GetSpecialization(int id)
        {
            Specialization specialization = db.Specialization.Find(id);
            if (specialization == null)
            {
                return NotFound();
            }

            return Ok(specialization);
        }

        // PUT: api/Specializations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpecialization(int id, Specialization specialization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specialization.ID)
            {
                return BadRequest();
            }

            db.Entry(specialization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializationExists(id))
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

        // POST: api/Specializations
        [ResponseType(typeof(Specialization))]
        public IHttpActionResult PostSpecialization(Specialization specialization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Specialization.Add(specialization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = specialization.ID }, specialization);
        }

        // DELETE: api/Specializations/5
        [ResponseType(typeof(Specialization))]
        public IHttpActionResult DeleteSpecialization(int id)
        {
            Specialization specialization = db.Specialization.Find(id);
            if (specialization == null)
            {
                return NotFound();
            }

            db.Specialization.Remove(specialization);
            db.SaveChanges();

            return Ok(specialization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecializationExists(int id)
        {
            return db.Specialization.Count(e => e.ID == id) > 0;
        }
    }
}