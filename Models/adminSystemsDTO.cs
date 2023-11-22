using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class adminSystemsDTO
    {

        public int adminId { get; set; }
        public int sysId { get; set; }
        public long serial { get; set; }
        public string qrCode { get; set; }
        public string model { get; set; }
        public Nullable<long> partType { get; set; }
        public byte[] qrImage { get; set; }
        public Nullable<int> pcNo { get; set; }
        public Nullable<double> dc_3v { get; set; }
        public Nullable<double> dc_5v { get; set; }
        public Nullable<double> dc_12v { get; set; }
        public Nullable<double> dc12v { get; set; }
        public Nullable<double> C_12v { get; set; }
        public string SVSB { get; set; }
        public string PG { get; set; }
        public string service { get; set; }
        public string expressCode { get; set; }
        public string mfgDate { get; set; }
        public string noOfCpus { get; set; }
        public string codeName { get; set; }
        public string cache1_1 { get; set; }
        public string cache1_2 { get; set; }
        public string bootStages { get; set; }
        public string moboModel { get; set; }
        public string moboChipset { get; set; }
        public string biosVersion { get; set; }
        public string diskModel { get; set; }
        public string capacity { get; set; }
        public string diskSerial { get; set; }
        public string damageBlock { get; set; }
        public string maxTemp { get; set; }
        public string testedSpeed { get; set; }
        public string timeSpent { get; set; }
        public string tRateMin { get; set; }
        public string tRateMax { get; set; }
        public string tRateAvg { get; set; }
        public string accessTime { get; set; }
        public string burstRate { get; set; }
        public string cpuUsage { get; set; }
        public string diskwipe { get; set; }
        public string winMemDiag { get; set; }
        public string dimm1PartNo { get; set; }
        public string dimm1SerialNo { get; set; }
        public string dimm2PartNo { get; set; }
        public string dimm2serialNo { get; set; }
        public string dimm3PartNo { get; set; }
        public string dimm3SerialNo { get; set; }
        public string dimm4PartNo { get; set; }
        public string dimm4SerialNo { get; set; }
        public string modelNo { get; set; }
        public string productId { get; set; }
        public string serialNo { get; set; }
        public string mfg { get; set; }
        public Nullable<long> winReqId { get; set; }
        public Nullable<long> winCoaId { get; set; }
        public string winProduct { get; set; }
        public Nullable<long> winXCoaId { get; set; }
        public string winLicType { get; set; }
        public string winProdKey { get; set; }
        public Nullable<long> offReqId { get; set; }
        public Nullable<long> offCoaId { get; set; }
        public string offProd { get; set; }
        public Nullable<long> offXCoaId { get; set; }
        public string offLicType { get; set; }
        public string offProdKey { get; set; }

    }
}