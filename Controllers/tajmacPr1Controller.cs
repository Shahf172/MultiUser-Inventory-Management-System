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
    public class tajmacPr1Controller : ApiController
    {

        private TAJMAC99dbEntities db = new TAJMAC99dbEntities();

        public tajmacPr1Controller()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        //[Route("{sysId}")]
        [BasicAuthentication]
        public IQueryable<detailBySysIdDTO> GetcompleteDetail(int id)
        {
            var detail = from x in db.customerSystems.Where(y => y.systemId == id)
                         select new detailBySysIdDTO
                         {
                             sysId = x.systemId,
                             modelNo = x.systemsDetail.modelNo,
                             productId = x.systemsDetail.productId,
                             serial = x.systemsDetail.serial,
                             partType = x.systemsDetail.partType,
                             qrCode = x.systemsDetail.qrCode,
                             adminId = x.customer.adminID,
                             customerId = x.customerId,
                             firstName = x.customer.firstName,
                             lastName = x.customer.lastName,
                             designation = x.customer.designation,
                             userName = x.customer.userName,
                             email = x.customer.email
                         };
            return detail;
        }

    }
}
