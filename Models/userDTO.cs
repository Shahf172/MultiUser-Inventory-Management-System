﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class userDTO
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
   //     public string userName { get; set; }
        public string designation { get; set; }
        public string email { get; set; }
   //     public string password { get; set; }
        public int adminID { get; set; }

    }
}