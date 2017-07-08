using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JNU.BAL;
using JNU.DAL;

namespace JNU.Controllers
{
    public class LoginController : ApiController
    {
        // GET api/<controller>
       
        
        [HttpPost]

        public HttpResponseMessage UserValidate(Login UserDetails)
        {
            HttpResponseMessage response = null;
            tbl_user objUser = new DAL.tbl_user();
            using (var db = new JNVDataContext())
            {
                try
                {
                    objUser = db.tbl_users.Where(a => a.Email == UserDetails.Username && a.Password == a.Password).FirstOrDefault();
                    if(objUser==null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.Forbidden, "UserName Or Password is invalid");
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, objUser);
                    }
                }catch(Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.StackTrace);
                }
            }
            return response;
        }



    }
}