using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using webApi.Models;

namespace webApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class customersAdminsController : ApiController
    {
        private TAJMAC99dbEntities db = new TAJMAC99dbEntities();

        public customersAdminsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/customersAdmins
        [BasicAuthentication]
        public IQueryable<customersAdmin> GetcustomersAdmins()
        {
            return db.customersAdmins;
        }

        // GET: api/customersAdmins/5
        [BasicAuthentication]
        [ResponseType(typeof(customersAdmin))]
        public IHttpActionResult GetcustomersAdmin(int id)
        {
            customersAdmin customersAdmin = db.customersAdmins.Find(id);
            if (customersAdmin == null)
            {
                return NotFound();
            }

            return Ok(customersAdmin);
        }

        // PUT: api/customersAdmins/5
        [BasicAuthentication]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutcustomersAdmin(int id, customersAdmin customersAdmin)
        {
           
            if (id != customersAdmin.Id)
            {
                return BadRequest();
            }

            db.Entry(customersAdmin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customersAdminExists(id))
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

        // POST: api/customersAdmins
        [BasicAuthentication]
        [ResponseType(typeof(customersAdmin))]
        public IHttpActionResult PostcustomersAdmin(customersAdmin customersAdmin)
        {
           
            db.customersAdmins.Add(customersAdmin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (customersAdminExists(customersAdmin.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = customersAdmin.Id }, customersAdmin);
        }

        // DELETE: api/customersAdmins/5
        [BasicAuthentication]
        [ResponseType(typeof(customersAdmin))]
        public IHttpActionResult DeletecustomersAdmin(int id)
        {
            customersAdmin customersAdmin = db.customersAdmins.Find(id);
            if (customersAdmin == null)
            {
                return NotFound();
            }

            db.customersAdmins.Remove(customersAdmin);
            db.SaveChanges();

            return Ok(customersAdmin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool customersAdminExists(int id)
        {
            return db.customersAdmins.Count(e => e.Id == id) > 0;
        }
    }
}