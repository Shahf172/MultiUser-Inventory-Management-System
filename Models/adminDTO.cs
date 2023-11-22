using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class adminDTO
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
     //   public long cellNo { get; set; }
    //    public Nullable<long> phNo { get; set; }
        public string companyName { get; set; }
   //     public string userName { get; set; }
   //     public string password { get; set; }
        public string designation { get; set; }

    }
}