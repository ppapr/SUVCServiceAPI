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
    public class UsersController : ApiController
    {
        private SUVCServiceDbEntities db = new SUVCServiceDbEntities();

        [ResponseType(typeof(List<ResponseUsers>))]
        public IHttpActionResult GetUser()
        {
            return Ok(db.Users.ToList().ConvertAll(p => new ResponseUsers(p)));
        }

        [ResponseType(typeof(List<ResponseUsers>))]
        public IHttpActionResult GetUser(string login, string password)
        {
            Users users = db.Users.FirstOrDefault(p => p.Login == login && p.Password == password);

            if (users == null)
            {
                return NotFound();
            }

            var responseUser = new ResponseUsers(users);

            return Ok(responseUser);
        }

        [ResponseType(typeof(List<ResponseUsers>))]
        public IHttpActionResult GetUsersRole(int idrole)
        {
            List<Users> usersList = db.Users.Where(p => p.IDRole == idrole).ToList();

            if (usersList == null || usersList.Count == 0)
            {
                return NotFound();
            }

            var responseUsersList = usersList.Select(user => new ResponseUsers(user)).ToList();

            return Ok(responseUsersList);
        }



        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.ID)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.ID }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.ID == id) > 0;
        }
    }
}