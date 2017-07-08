using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JNU.DAL;

namespace JNU.BAL
{
    public class Login
    {

        public string Token { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int RoleID { get; set; }

        public int CityID { get; set; }  
    }



    
}