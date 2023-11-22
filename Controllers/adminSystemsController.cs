using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using webApi.Models;

namespace webApi.Controllers
{
    
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class adminSystemsController : ApiController
    {

        
        private TAJMAC99dbEntities db = new TAJMAC99dbEntities();

        public adminSystemsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }


        [BasicAuthenticationAttributeAdmin]
        [ResponseType(typeof(void))]
        
        public IQueryable<adminSystemsDTO> Get()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            var detail = from x in db.adminSystems.Where(y => y.customersAdmin.userName == username)
                         select new adminSystemsDTO
                         {
                             adminId = x.adminId,
                             sysId = x.sysId,
                             model = x.systemsDetail.model,
                             qrCode = x.systemsDetail.qrCode,
                             serial = (Int64)x.systemsDetail.serial,
                             accessTime = x.systemsDetail.accessTime,
                             biosVersion = x.systemsDetail.biosVersion,
                             bootStages = x.systemsDetail.bootStages,
                             burstRate = x.systemsDetail.burstRate,
                             cache1_1 = x.systemsDetail.cache1_1,
                             cache1_2 = x.systemsDetail.cache1_2,
                             capacity = x.systemsDetail.capacity,
                             codeName = x.systemsDetail.codeName,
                             cpuUsage = x.systemsDetail.cpuUsage,
                             C_12v = x.systemsDetail.C_12v,
                             damageBlock = x.systemsDetail.damageBlock,
                             dc12v = x.systemsDetail.dc12v,
                             dc_12v = x.systemsDetail.dc_12v,
                             dc_3v = x.systemsDetail.dc_3v,
                             dc_5v = x.systemsDetail.dc_5v,
                             dimm1PartNo = x.systemsDetail.dimm1PartNo,
                             dimm1SerialNo = x.systemsDetail.dimm1SerialNo,
                             dimm2PartNo = x.systemsDetail.dimm2PartNo,
                             dimm2serialNo = x.systemsDetail.dimm2serialNo,
                             dimm3PartNo = x.systemsDetail.dimm3PartNo,
                             dimm3SerialNo = x.systemsDetail.dimm3SerialNo,
                             dimm4PartNo = x.systemsDetail.dimm4PartNo,
                             dimm4SerialNo = x.systemsDetail.dimm4SerialNo,
                             diskModel = x.systemsDetail.diskModel,
                             diskSerial = x.systemsDetail.diskSerial,
                             diskwipe = x.systemsDetail.diskwipe,
                             expressCode = x.systemsDetail.expressCode,
                             maxTemp = x.systemsDetail.maxTemp,
                             mfg = x.systemsDetail.mfg,
                             mfgDate = x.systemsDetail.mfgDate,
                             moboChipset = x.systemsDetail.moboChipset,
                             moboModel = x.systemsDetail.moboModel,
                             modelNo = x.systemsDetail.modelNo,
                             noOfCpus = x.systemsDetail.noOfCpus,
                             offCoaId = x.systemsDetail.offCoaId,
                             offLicType = x.systemsDetail.offLicType,
                             offProd = x.systemsDetail.offProd,
                             offProdKey = x.systemsDetail.offProdKey,
                             offReqId = x.systemsDetail.offReqId,
                             offXCoaId = x.systemsDetail.offXCoaId,
                             partType = x.systemsDetail.partType,
                             pcNo = x.systemsDetail.pcNo,
                             PG = x.systemsDetail.PG,
                             productId = x.systemsDetail.productId,
                             qrImage = x.systemsDetail.qrImage,
                             serialNo = x.systemsDetail.serialNo,
                             service = x.systemsDetail.service,
                             SVSB = x.systemsDetail.SVSB,
                             testedSpeed = x.systemsDetail.testedSpeed,
                             timeSpent = x.systemsDetail.timeSpent,
                             tRateAvg = x.systemsDetail.tRateAvg,
                             tRateMax = x.systemsDetail.tRateMax,
                             tRateMin = x.systemsDetail.tRateMin,
                             winCoaId = x.systemsDetail.winCoaId,
                             winLicType = x.systemsDetail.winLicType,
                             winMemDiag = x.systemsDetail.winMemDiag,
                             winProdKey = x.systemsDetail.winProdKey,
                             winProduct = x.systemsDetail.winProduct,
                             winReqId = x.systemsDetail.winReqId,
                             winXCoaId = x.systemsDetail.winXCoaId
                         };
                return detail;
             
        }
          // GET: api/adminSystems/5
          [ResponseType(typeof(adminSystem))]
          public IHttpActionResult GetadminSystem(int id)
          {
              adminSystem adminSystem = db.adminSystems.Find(id);
              if (adminSystem == null)
              {
                  return NotFound();
              }

              return Ok(adminSystem);
          }

        // PUT: api/adminSystems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutadminSystem(int id, adminSystem adminSystem)
        {
           
            if (id != adminSystem.Id)
            {
                return BadRequest();
            }

            db.Entry(adminSystem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!adminSystemExists(id))
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

        // POST: api/adminSystems
        [ResponseType(typeof(adminSystem))]
        public IHttpActionResult PostadminSystem(adminSystem adminSystem)
        {
             
            db.adminSystems.Add(adminSystem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (adminSystemExists(adminSystem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adminSystem.Id }, adminSystem);
        }

        // DELETE: api/adminSystems/5
        [ResponseType(typeof(adminSystem))]
        public IHttpActionResult DeleteadminSystem(int id)
        {
            adminSystem adminSystem = db.adminSystems.Find(id);
            if (adminSystem == null)
            {
                return NotFound();
            }

            db.adminSystems.Remove(adminSystem);
            db.SaveChanges();

            return Ok(adminSystem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool adminSystemExists(int id)
        {
            return db.adminSystems.Count(e => e.Id == id) > 0;
        }
    }
}