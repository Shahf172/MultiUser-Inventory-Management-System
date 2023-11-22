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
    public class customerSystemsController : ApiController
    {
        private TAJMAC99dbEntities db = new TAJMAC99dbEntities();

        public customerSystemsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [BasicAuthenticationAttributeCustomer]
        public IQueryable<userSystem> GetcustomerSystems()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;


            if (db.customerSystems.Any(x => x.customerAccess == "full" && x.customer.userName == username))
            {
                var detail2 = from x in db.customerSystems.Where(y => y.customer.userName == username )
                              select new userSystem
                              {

                                  customerId = x.customerId,
                                  userName = x.customer.userName,
                                  designation = x.customer.designation,
                                  Id = x.systemsDetail.Id,
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
                                  model = x.systemsDetail.model,
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
                                  qrCode = x.systemsDetail.qrCode,
                                  qrImage = x.systemsDetail.qrImage,
                                  serial = x.systemsDetail.serial,
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
                                  winReqId = x.systemsDetail.winReqId,
                                  winProduct = x.systemsDetail.winProduct,
                                  winXCoaId = x.systemsDetail.winXCoaId

                              }; ;

                return detail2;
            }

            else
            {
                var detail = from x in db.customerSystems.Where(y => y.customer.userName == username )
                             select new userSystem
                             {
                                 userName = x.customer.userName,
                                 customerId = x.customerId,
                                 designation = x.customer.designation,
                                 Id = x.Id,
                                 accessTime = x.systemsDetail.accessTime,
                                 bootStages = x.systemsDetail.bootStages,
                                 burstRate = x.systemsDetail.burstRate,
                                 cpuUsage = x.systemsDetail.cpuUsage,
                                 damageBlock = x.systemsDetail.damageBlock,
                                 diskwipe = x.systemsDetail.diskwipe,
                                 expressCode = x.systemsDetail.expressCode,
                                 maxTemp = x.systemsDetail.maxTemp,
                                 mfgDate = x.systemsDetail.mfgDate,
                                 moboChipset = x.systemsDetail.moboChipset,
                                 moboModel = x.systemsDetail.moboModel,
                                 model = x.systemsDetail.model,
                                 noOfCpus = x.systemsDetail.noOfCpus,
                                 partType = x.systemsDetail.partType,
                                 PG = x.systemsDetail.PG,
                                 qrCode = x.systemsDetail.qrCode,
                                 serial = x.systemsDetail.serial,
                                 service = x.systemsDetail.service,
                                 SVSB = x.systemsDetail.SVSB,
                                 testedSpeed = x.systemsDetail.testedSpeed,
                                 timeSpent = x.systemsDetail.timeSpent,
                                 tRateAvg = x.systemsDetail.tRateAvg,
                                 tRateMax = x.systemsDetail.tRateMax,
                                 tRateMin = x.systemsDetail.tRateMin
                             };

                return detail;
            }

        }



        [BasicAuthenticationAttributeCustomer]
        public IQueryable<userSystem> GetcustomerSystems(string qrCode)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;


            if (db.customerSystems.Any(x => x.customerAccess == "full" && x.customer.userName == username))
            {
                var detail2 = from x in db.customerSystems.Where(y => y.customer.userName == username && y.systemsDetail.qrCode == qrCode)
                              select new userSystem
                              {

                                  customerId = x.customerId,
                                  userName = x.customer.userName,
                                  designation = x.customer.designation,
                                  Id = x.systemsDetail.Id,
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
                                  model = x.systemsDetail.model,
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
                                  qrCode = x.systemsDetail.qrCode,
                                  qrImage = x.systemsDetail.qrImage,
                                  serial = x.systemsDetail.serial,
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
                                  winReqId = x.systemsDetail.winReqId,
                                  winProduct = x.systemsDetail.winProduct,
                                  winXCoaId = x.systemsDetail.winXCoaId

                              }; ;

                return detail2;
            }

            else 
            {
                var detail = from x in db.customerSystems.Where(y => y.customer.userName == username && y.systemsDetail.qrCode == qrCode)
                             select new userSystem
                             {
                                 userName = x.customer.userName,
                                 customerId = x.customerId,
                                 designation = x.customer.designation,
                                 Id = x.Id,
                                 accessTime = x.systemsDetail.accessTime,
                                 bootStages = x.systemsDetail.bootStages,
                                 burstRate = x.systemsDetail.burstRate,
                                 cpuUsage = x.systemsDetail.cpuUsage,
                                 damageBlock = x.systemsDetail.damageBlock,
                                 diskwipe = x.systemsDetail.diskwipe,
                                 expressCode = x.systemsDetail.expressCode,
                                 maxTemp = x.systemsDetail.maxTemp,
                                 mfgDate = x.systemsDetail.mfgDate,
                                 moboChipset = x.systemsDetail.moboChipset,
                                 moboModel = x.systemsDetail.moboModel,
                                 model = x.systemsDetail.model,
                                 noOfCpus = x.systemsDetail.noOfCpus,
                                 partType = x.systemsDetail.partType,
                                 PG = x.systemsDetail.PG,
                                 qrCode = x.systemsDetail.qrCode,
                                 serial = x.systemsDetail.serial,
                                 service = x.systemsDetail.service,
                                 SVSB = x.systemsDetail.SVSB,
                                 testedSpeed = x.systemsDetail.testedSpeed,
                                 timeSpent = x.systemsDetail.timeSpent,
                                 tRateAvg = x.systemsDetail.tRateAvg,
                                 tRateMax = x.systemsDetail.tRateMax,
                                 tRateMin = x.systemsDetail.tRateMin
                             };

                return detail;
            }

        }

        // PUT: api/customerSystems/5
        [BasicAuthenticationAttributeAdmin]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutcustomerSystem(int id, customerSystem customerSystem)
        {
           
            if (id != customerSystem.Id)
            {
                return BadRequest();
            }

            db.Entry(customerSystem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customerSystemExists(id))
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

        // POST: api/customerSystems
        [BasicAuthenticationAttributeAdmin]
        [ResponseType(typeof(customerSystem))]
        public IHttpActionResult PostcustomerSystem(customerSystem customerSystem)
        {
           
            db.customerSystems.Add(customerSystem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (customerSystemExists(customerSystem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = customerSystem.Id }, customerSystem);
        }

        // DELETE: api/customerSystems/5
        [BasicAuthenticationAttributeAdmin]
        [ResponseType(typeof(customerSystem))]
        public IHttpActionResult DeletecustomerSystem(int id)
        {
            customerSystem customerSystem = db.customerSystems.Find(id);
            if (customerSystem == null)
            {
                return NotFound();
            }

            db.customerSystems.Remove(customerSystem);
            db.SaveChanges();

            return Ok(customerSystem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool customerSystemExists(int id)
        {
            return db.customerSystems.Count(e => e.Id == id) > 0;
        }
    }
}