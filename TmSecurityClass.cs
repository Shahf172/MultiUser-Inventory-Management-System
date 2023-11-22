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
using webApi.Models;
namespace webApi
{
    public class TmSecurityClass
    {
        
        public static bool LogIn (string userName, string password)
            {
                using (TAJMAC99dbEntities db = new TAJMAC99dbEntities())
            {
                return db.Log_In.Any(x => x.userName.Equals(userName, StringComparison.OrdinalIgnoreCase) && x.password.Equals(password));
            }
         
            }

        public static bool AdminLogIn(string userName, string password)
        {
            using (TAJMAC99dbEntities db = new TAJMAC99dbEntities())

                return db.customersAdmins.Any(x => x.userName.Equals(userName, StringComparison.OrdinalIgnoreCase) && x.password.Equals(password));
        }

        public static bool UserLogIn(string userName, string password)
        {
            using (TAJMAC99dbEntities db = new TAJMAC99dbEntities())
                return db.customers.Any(x => x.userName.Equals(userName, StringComparison.OrdinalIgnoreCase) && x.password.Equals(password));
        }
    }
}