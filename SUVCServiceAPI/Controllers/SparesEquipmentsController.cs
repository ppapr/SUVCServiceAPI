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
    public class SparesEquipmentsController : ApiController
    {
        private SUVCServiceDbEntities db = new SUVCServiceDbEntities();

        // GET: api/SparesEquipments
        [ResponseType(typeof(List<ResponseSpares>))]
        public IHttpActionResult GetSparesEquipment()
        {
            return Ok(db.SparesEquipment.ToList().ConvertAll(p => new ResponseSpares(p)));
        }

        // GET: api/SparesEquipments/5
        [ResponseType(typeof(SparesEquipment))]
        public IHttpActionResult GetSparesEquipment(int id)
        {
            SparesEquipment sparesEquipment = db.SparesEquipment.Find(id);
            if (sparesEquipment == null)
            {
                return NotFound();
            }

            return Ok(sparesEquipment);
        }

        // PUT: api/SparesEquipments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSparesEquipment(int id, SparesEquipment sparesEquipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sparesEquipment.ID)
            {
                return BadRequest();
            }

            db.Entry(sparesEquipment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SparesEquipmentExists(id))
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

        // POST: api/SparesEquipments
        [ResponseType(typeof(SparesEquipment))]
        public IHttpActionResult PostSparesEquipment(SparesEquipment sparesEquipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SparesEquipment.Add(sparesEquipment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sparesEquipment.ID }, sparesEquipment);
        }

        // DELETE: api/SparesEquipments/5
        [ResponseType(typeof(SparesEquipment))]
        public IHttpActionResult DeleteSparesEquipment(int id)
        {
            SparesEquipment sparesEquipment = db.SparesEquipment.Find(id);
            if (sparesEquipment == null)
            {
                return NotFound();
            }

            db.SparesEquipment.Remove(sparesEquipment);
            db.SaveChanges();

            return Ok(sparesEquipment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SparesEquipmentExists(int id)
        {
            return db.SparesEquipment.Count(e => e.ID == id) > 0;
        }
    }
}