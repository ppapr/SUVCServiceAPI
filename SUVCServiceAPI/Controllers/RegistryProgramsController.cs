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
    public class RegistryProgramsController : ApiController
    {
        private SUVCServiceDbEntities db = new SUVCServiceDbEntities();

        // GET: api/RegistryPrograms
        [ResponseType(typeof(List<ResponseRegistry>))]
        public IHttpActionResult GetRegistryPrograms()
        {
            return Ok(db.RegistryPrograms.ToList().ConvertAll(p => new ResponseRegistry(p)));
        }

        // GET: api/RegistryPrograms/5
        [ResponseType(typeof(RegistryPrograms))]
        public IHttpActionResult GetRegistryPrograms(int id)
        {
            RegistryPrograms registryPrograms = db.RegistryPrograms.Find(id);
            if (registryPrograms == null)
            {
                return NotFound();
            }

            return Ok(registryPrograms);
        }

        // PUT: api/RegistryPrograms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistryPrograms(int id, RegistryPrograms registryPrograms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registryPrograms.ID)
            {
                return BadRequest();
            }

            db.Entry(registryPrograms).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistryProgramsExists(id))
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

        // POST: api/RegistryPrograms
        [ResponseType(typeof(RegistryPrograms))]
        public IHttpActionResult PostRegistryPrograms(RegistryPrograms registryPrograms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegistryPrograms.Add(registryPrograms);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registryPrograms.ID }, registryPrograms);
        }

        // DELETE: api/RegistryPrograms/5
        [ResponseType(typeof(RegistryPrograms))]
        public IHttpActionResult DeleteRegistryPrograms(int id)
        {
            RegistryPrograms registryPrograms = db.RegistryPrograms.Find(id);
            if (registryPrograms == null)
            {
                return NotFound();
            }

            db.RegistryPrograms.Remove(registryPrograms);
            db.SaveChanges();

            return Ok(registryPrograms);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistryProgramsExists(int id)
        {
            return db.RegistryPrograms.Count(e => e.ID == id) > 0;
        }
    }
}