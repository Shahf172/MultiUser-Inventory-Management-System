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
    //[Authorize]
    //[Route("api/[controller]/[action]")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class tajmacPrController : ApiController
    {
        private TAJMAC99dbEntities db = new TAJMAC99dbEntities();

        public tajmacPrController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

      
        // GET: api/tajmacPr/id
        //[Route ("{adminId}")]
        [BasicAuthentication]
        public IQueryable<completeDetailDTO> Get(int id)
        {
            var detail = from x in db.customerSystems.Where(y => y.customer.adminID == id)
                         select new completeDetailDTO
                         {

                             adminId = x.customer.adminID,
                             customerId = x.customerId,
                             userName = x.customer.userName,
                             email = x.customer.email,
                             designation = x.customer.designation,
                             sysId = x.systemId,
                             modelNo = x.systemsDetail.modelNo,
                             serial = x.systemsDetail.serial,
                             productId = x.systemsDetail.productId,
                             qrCode = x.systemsDetail.qrCode

                         };

            return detail;
        }

        //[Route("{name}")]
        //public IQueryable<completeDetailDTO> Get(string name)
        //{
        //    var detail = from x in db.customerSystems.Where(y => y.customer.userName == name)
        //                 select new completeDetailDTO
        //                 {
        //                     adminId = x.customer.adminID,
        //                     customerId = x.customerId,
        //                     userName = x.customer.userName,
        //                     email = x.customer.email,
        //                     designation = x.customer.designation,
        //                     sysId = x.systemId,
        //                     modelNo = x.systemsDetail.modelNo,
        //                     serial = x.systemsDetail.serial,
        //                     productId = x.systemsDetail.productId,
        //                     qrCode = x.systemsDetail.qrCode
        //                 };

        //    return detail;
        //}


    }       
     


}