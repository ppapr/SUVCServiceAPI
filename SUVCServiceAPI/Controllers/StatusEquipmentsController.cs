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
    public class StatusEquipmentsController : ApiController
    {
        private SUVCServiceDbEntities db = new SUVCServiceDbEntities();

        // GET: api/StatusEquipments
        [ResponseType(typeof(List<ResponseStatusEquipment>))]
        public IHttpActionResult GetStatusEquipment()
        {
            return Ok(db.StatusEquipment.ToList().ConvertAll(p => new ResponseStatusEquipment(p)));
        }

        // GET: api/StatusEquipments/5
        [ResponseType(typeof(StatusEquipment))]
        public IHttpActionResult GetStatusEquipment(int id)
        {
            StatusEquipment statusEquipment = db.StatusEquipment.Find(id);
            if (statusEquipment == null)
            {
                return NotFound();
            }

            return Ok(statusEquipment);
        }

        // PUT: api/StatusEquipments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusEquipment(int id, StatusEquipment statusEquipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusEquipment.ID)
            {
                return BadRequest();
            }

            db.Entry(statusEquipment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusEquipmentExists(id))
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

        // POST: api/StatusEquipments
        [ResponseType(typeof(StatusEquipment))]
        public IHttpActionResult PostStatusEquipment(StatusEquipment statusEquipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusEquipment.Add(statusEquipment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusEquipment.ID }, statusEquipment);
        }

        // DELETE: api/StatusEquipments/5
        [ResponseType(typeof(StatusEquipment))]
        public IHttpActionResult DeleteStatusEquipment(int id)
        {
            StatusEquipment statusEquipment = db.StatusEquipment.Find(id);
            if (statusEquipment == null)
            {
                return NotFound();
            }

            db.StatusEquipment.Remove(statusEquipment);
            db.SaveChanges();

            return Ok(statusEquipment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusEquipmentExists(int id)
        {
            return db.StatusEquipment.Count(e => e.ID == id) > 0;
        }
    }
}