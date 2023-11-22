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
    public class customerLogInController : ApiController
    {
        private TAJMAC99dbEntities db = new TAJMAC99dbEntities();

        [BasicAuthenticationAttributeCustomer]
        // GET: api/customerLogIn
        public IQueryable<userDTO> Getcustomers()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            
            if(db.customers.Any(x=> x.userName == username))
            {
                var detail = from x in db.customers.Where(y => y.userName == username)
                             select new userDTO
                             {
                                 firstName = x.firstName,
                                 lastName = x.lastName,
                                 designation = x.designation,
                                 email = x.email
                             };
                return detail;
            }
            else
            {
                Console.Write("error");
                return null;
            }
           
        }

      
    }
}