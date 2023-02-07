using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using VirtualmindCodeChallenge.Models;

namespace VirtualmindCodeChallenge.Controllers
{
    public class UsersController : ApiController
    {
        private UserModel db = new UserModel();

        // GET: api/Users
        public IQueryable<User> GetUsers() {
            return db.users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id) {
            User user = await db.users.FindAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(User user) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.id))
                    return NotFound();
                else
                    throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.users.Add(user);
            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new {id = user.id}, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id) {
            User user = await db.users.FindAsync(id);
            if (user == null)
                return NotFound();

            db.users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        protected override void Dispose(bool disposing) {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        private bool UserExists(int id) {
            return db.users.Find(id) != null;
        }
    }
}
