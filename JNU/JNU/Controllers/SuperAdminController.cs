using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JNU.BAL;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using JNU.DAL;
using Newtonsoft.Json.Linq;
using System.Text;

namespace JNU.Controllers
{
    public class SuperAdminController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage AdminRegistration()
         {
            try
            {
                var files = HttpContext.Current.Request.Files;
                tbl_user objadmindetails = new tbl_user();
                objadmindetails.UserID= Convert.ToInt32(HttpContext.Current.Request.Form["UserID"]);
                objadmindetails.Name = HttpContext.Current.Request.Form["Name"];
                objadmindetails.Nick_name = HttpContext.Current.Request.Form["Nick_name"];
                objadmindetails.Email = HttpContext.Current.Request.Form["Email"];
                //check userid already exits or not 
                if (objadmindetails.UserID == 0)
                {
                    using (var db = new JNVDataContext())
                    {
                        var checkuser = db.tbl_users.Where(a => a.Email == objadmindetails.Email && a.IsActive == true).FirstOrDefault();
                        if (checkuser != null)
                        {
                            return new HttpResponseMessage()
                            {
                                Content = new StringContent("Email ID Already Exits.", Encoding.UTF8, "application/json")
                            };
                        }
                    }
                }
                    //
                    objadmindetails.Password = HttpContext.Current.Request.Form["Password"];
                objadmindetails.Phone = HttpContext.Current.Request.Form["Phone"];
                objadmindetails.WhatsApp_Number = HttpContext.Current.Request.Form["WhatsApp_Number"];
                objadmindetails.City_ID = Convert.ToInt32(HttpContext.Current.Request.Form["City_ID"]);
                objadmindetails.Birthday = Convert.ToDateTime(HttpContext.Current.Request.Form["Birthday"]);
                objadmindetails.Gender = HttpContext.Current.Request.Form["Gender"];
                objadmindetails.Marital_Status = HttpContext.Current.Request.Form["Marital_Status"];
                objadmindetails.Village = HttpContext.Current.Request.Form["village"];
                objadmindetails.Hobbies = HttpContext.Current.Request.Form["Hobbies"];
                objadmindetails.Profession_Detail = HttpContext.Current.Request.Form["Profession_Detail"];
                objadmindetails.Home_Address = HttpContext.Current.Request.Form["Home_Address"];
                objadmindetails.Current_Address = HttpContext.Current.Request.Form["Current_Address"];
                objadmindetails.Facebook_ID = HttpContext.Current.Request.Form["Facebook_ID"];
                objadmindetails.LinkedIn_ID = HttpContext.Current.Request.Form["LinkedIn_ID"];
                objadmindetails.Twitter_ID = HttpContext.Current.Request.Form["Twitter_ID"];

                string path = HttpContext.Current.Server.MapPath("~/AdminProfile/");
                string fileName = string.Empty;
                if (files.Count > 0)
                {
                    fileName = "/AdminProfile/";
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        fileName += Common.UploadFile(file, path);
                        //dbContext.Deal_Image.Add(new Deal_Image { Id = Guid.NewGuid(), DealId = deal.Id, ImageUrl = "/Files/" + fileName });
                    }
                }
                objadmindetails.Photo = fileName;
                int RoleID= Convert.ToInt32(HttpContext.Current.Request.Form["RoleID"]);
                if (RoleID == 0) { RoleID = 1; }else { RoleID = 2; }
                using (var db = new JNVDataContext())
                {
                    if (objadmindetails.UserID > 0)
                    {
                        db.Upd_Admin_By_ID(objadmindetails.UserID, objadmindetails.Name, objadmindetails.Nick_name, objadmindetails.Email, objadmindetails.Password, RoleID, objadmindetails.Phone, objadmindetails.WhatsApp_Number, objadmindetails.City_ID, 1, null,true,true, objadmindetails.Birthday, "", objadmindetails.Gender, objadmindetails.Marital_Status, objadmindetails.Village, "", objadmindetails.Hobbies, "", null, null, null, "", "", objadmindetails.Profession_Detail, objadmindetails.Home_Address, objadmindetails.Current_Address, objadmindetails.Facebook_ID, objadmindetails.LinkedIn_ID, objadmindetails.Twitter_ID, objadmindetails.Photo);
                    }
                    else
                    {
                        db.Set_Registration(objadmindetails.Name, objadmindetails.Nick_name, objadmindetails.Email, objadmindetails.Password, RoleID, objadmindetails.Phone, objadmindetails.WhatsApp_Number, objadmindetails.City_ID, 1, null, true, true, objadmindetails.Birthday, "", objadmindetails.Gender, objadmindetails.Marital_Status, objadmindetails.Village, "", objadmindetails.Hobbies, "", null, null, null, "", "", objadmindetails.Profession_Detail, objadmindetails.Home_Address, objadmindetails.Current_Address, objadmindetails.Facebook_ID, objadmindetails.LinkedIn_ID, objadmindetails.Twitter_ID, objadmindetails.Photo);
                    }
                }
                return new HttpResponseMessage()
                {
                    Content = new StringContent("OK.", Encoding.UTF8, "application/json")
                };
            }
            catch(Exception ex)
            {
                 return new HttpResponseMessage()
                {
                    Content = new StringContent("Something went wrong please try after some time.", Encoding.UTF8, "application/json")
                };
            }
               

        }


        [HttpGet]
        public HttpResponseMessage GetAdminDetails()
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_AdminResult> AdminDetails = db.Get_Admin().ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(AdminDetails).ToString(), Encoding.UTF8, "application/json")
                    };
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Something went wrong please try after some time.", Encoding.UTF8, "application/json")
                };
            }
        }


        [HttpGet]
        public HttpResponseMessage GetAdminDetailsByID(int ID)
        {
            using (var db = new JNVDataContext())
            {
               List<Get_Admin_By_IDResult> AdminDetails = db.Get_Admin_By_ID(ID).ToList();
                return new HttpResponseMessage()
                {
                    Content = new StringContent(JArray.FromObject(AdminDetails).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet]

        public HttpResponseMessage DeleteAdmin(int ID)
        {
            using (var db = new JNVDataContext())
            {
                db.Del_Admin_By_ID(ID);
                return new HttpResponseMessage()
                {
                    Content = new StringContent("User Delete Successfully", Encoding.UTF8, "application/json")
                };

            }
        }

    }
}