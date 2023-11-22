using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class systemIdDTO
    {
        public int systemId { get; set; }
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string designation { get; set; }
        public string email { get; set; }
        public int adminID { get; set; }

    }
}