using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class customerDTO
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string designation { get; set; }
        public string customerAccess { get; set; }
        public int adminId { get; set; }
        public string adminUserName {get; set;}
    }
}