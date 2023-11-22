using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webApi.Controllers
{
    public class testingController : ApiController
    {
        [BasicAuthenticationAttributeAdmin]
        //[RoutePrefix('GetData')]
        public IHttpActionResult GetData()
        {
            string val1 = "Fahad";
            string val2 = "Muhammad Iqbal";

            return Ok(val2 + val1);
        }


    }
}
