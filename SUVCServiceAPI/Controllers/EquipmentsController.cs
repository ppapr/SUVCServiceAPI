﻿using System;
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
    public class EquipmentsController : ApiController
    {
        private SUVCServiceDbEntities db = new SUVCServiceDbEntities();

        // GET: api/Equipments
        [ResponseType(typeof(List<ResponseEquipment>))]
        public IHttpActionResult GetEquipment()
        {
            return Ok(db.Equipment.ToList().ConvertAll(p => new ResponseEquipment(p)));
        }

        // GET: api/Equipments/5
        [ResponseType(typeof(Equipment))]
        public IHttpActionResult GetEquipment(int id)
        {
            Equipment equipment = db.Equipment.Find(id);
            if (equipment == null)
            {
                return NotFound();
            }

            return Ok(equipment);
        }

        // PUT: api/Equipments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEquipment(int id, Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipment.ID)
            {
                return BadRequest();
            }

            db.Entry(equipment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
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

        // POST: api/Equipments
        [ResponseType(typeof(Equipment))]
        public IHttpActionResult PostEquipment(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Equipment.Add(equipment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = equipment.ID }, equipment);
        }

        // DELETE: api/Equipments/5
        [ResponseType(typeof(Equipment))]
        public IHttpActionResult DeleteEquipment(int id)
        {
            Equipment equipment = db.Equipment.Find(id);
            if (equipment == null)
            {
                return NotFound();
            }

            db.Equipment.Remove(equipment);
            db.SaveChanges();

            return Ok(equipment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquipmentExists(int id)
        {
            return db.Equipment.Count(e => e.ID == id) > 0;
        }
    }
}