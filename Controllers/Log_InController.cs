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
using System.Web.Mvc;
using webApi.Models;
using System.Security.Claims;
using System.Threading;
using System.Web.Http.Cors;

namespace webApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Log_InController : ApiController
    {
        private TAJMAC99dbEntities db = new TAJMAC99dbEntities();


        [BasicAuthenticationAttributeAdmin]
        public IQueryable<adminDTO> GetCustAdmin()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            
            if(db.customersAdmins.Any(x => x.userName == username))
            {
                var detail = from x in db.customersAdmins.Where(y => y.userName == username)
                             select new adminDTO
                             {
                                 Id = x.Id,
                                 firstName =x.firstName,
                                 lastName = x.lastName,
                                 companyName = x.companyName,
                                 designation = x.designation,
                                 email = x.email
                                 
                                 
                             };
                return detail;
            }
            else
            {
                Console.Write("Error");
                return null;
            }
            
            
        }


    }
}