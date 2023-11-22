using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class adminNoOfSystemsDTO
    {
        public int adminId { get; set; }
        public int sysId { get; set; }
        //public long serial { get; set; }
        public string qrCode { get; set; }
        public string model { get; set; }

    }
}