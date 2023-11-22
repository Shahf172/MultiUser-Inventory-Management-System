using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class userSystemLimited
    {
        public int customerId { get; set; }
        public string userName { get; set; }
        public string designation { get; set; }
        //public string customerAccess { get; set; }
        public int Id { get; set; }
        public string qrCode { get; set; }
        public Nullable<long> partType { get; set; }
        public Nullable<long> serial { get; set; }
        //public string qrCode { get; set; }
        
        
        public string SVSB { get; set; }
        public string PG { get; set; }
        public string service { get; set; }
        public string expressCode { get; set; }
        public string mfgDate { get; set; }
        public string model { get; set; }
        public string noOfCpus { get; set; }
        
        public string bootStages { get; set; }
        public string moboModel { get; set; }
        public string moboChipset { get; set; }
        
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
        
    }
}