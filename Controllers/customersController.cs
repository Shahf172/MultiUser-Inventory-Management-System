using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using webApi.Models;

namespace webApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class customersController : ApiController
    {
        private TAJMAC99dbEntities db = new TAJMAC99dbEntities();

        public customersController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/customers
        [BasicAuthenticationAttributeAdmin]
       // [BasicAuthenticationAttributeCustomer]
        public IQueryable<customerDTO> Getcustomers()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            var detail = from b in db.customers .Where(y => y.customersAdmin.userName == username)
                          select new customerDTO
                          {

                              Id = b.Id,
                              userName = b.userName,
                              designation = b.designation,
                              adminId = b.customersAdmin.Id,
                              adminUserName = b.customersAdmin.userName

                          };

            return detail;
        }

        // GET: api/customers/5
        [BasicAuthenticationAttributeAdmin]
        public IQueryable<customerDTO> Getcustomers(int id)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            var detail = from b in db.customers.Where(x => x.customersAdmin.userName == username)
                         select new customerDTO
                         {

                             Id = b.Id,
                             userName = b.userName,
                             designation = b.designation,
                             adminId = b.customersAdmin.Id,
                             adminUserName = b.customersAdmin.userName

                         };

            return detail;
        }

        // PUT: api/customers/5
        [BasicAuthenticationAttributeAdmin]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcustomer(int id, customer customer)
        {
           
            if (id != customer.Id)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customerExists(id))
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

        // POST: api/customers
        [BasicAuthenticationAttributeAdmin]
        [ResponseType(typeof(customer))]
        public IHttpActionResult Postcustomer(customer customer)
        {
           

            db.customers.Add(customer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (customerExists(customer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/customers/5
        [BasicAuthenticationAttributeAdmin]
        [ResponseType(typeof(customer))]
        public IHttpActionResult Deletecustomer(int id)
        {
            customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool customerExists(int id)
        {
            return db.customers.Count(e => e.Id == id) > 0;
        }
    }
}