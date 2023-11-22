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
    [BasicAuthentication]
    public class systemsDetailsController : ApiController
    {
        private TAJMAC99dbEntities db = new TAJMAC99dbEntities();

        public systemsDetailsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [BasicAuthentication]
        // GET: api/systemsDetails
        public IQueryable<systemsDetail> GetsystemsDetails()
        {
            return db.systemsDetails;
        }

        // GET: api/systemsDetails/5
        [ResponseType(typeof(systemsDetail))]
        public IHttpActionResult GetsystemsDetail(int id)
        {
            systemsDetail systemsDetail = db.systemsDetails.Find(id);
            if (systemsDetail == null)
            {
                return NotFound();
            }

            return Ok(systemsDetail);
        }

        // PUT: api/systemsDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutsystemsDetail(int id, systemsDetail systemsDetail)
        {
           
            if (id != systemsDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(systemsDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!systemsDetailExists(id))
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

        // POST: api/systemsDetails
        [ResponseType(typeof(systemsDetail))]
        public IHttpActionResult PostsystemsDetail(systemsDetail systemsDetail)
        {
           
            db.systemsDetails.Add(systemsDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (systemsDetailExists(systemsDetail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = systemsDetail.Id }, systemsDetail);
        }

        // DELETE: api/systemsDetails/5
        [ResponseType(typeof(systemsDetail))]
        public IHttpActionResult DeletesystemsDetail(int id)
        {
            systemsDetail systemsDetail = db.systemsDetails.Find(id);
            if (systemsDetail == null)
            {
                return NotFound();
            }

            db.systemsDetails.Remove(systemsDetail);
            db.SaveChanges();

            return Ok(systemsDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool systemsDetailExists(int id)
        {
            return db.systemsDetails.Count(e => e.Id == id) > 0;
        }
    }
}