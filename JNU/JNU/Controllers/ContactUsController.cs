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
    public class ContactUsController : ApiController
    {

        /// <summary>
        /// Add update Contact us
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ContactUs()
        {
            try
            {
                tbl_contact_us objContactUsDetails = new tbl_contact_us();
                objContactUsDetails.Contact_Us_ID = Convert.ToInt32(HttpContext.Current.Request.Form["Contact_Us_ID"]);
                objContactUsDetails.Contact_Us = Convert.ToString(HttpContext.Current.Request.Form["Contact_Us"]);
                objContactUsDetails.City_ID = Convert.ToInt32(HttpContext.Current.Request.Form["CityID"]);

                if (objContactUsDetails.Contact_Us_ID == 0)
                {
                    using (var db = new JNVDataContext())
                    {
                        var checkcontactus = db.tbl_contact_us.Where(a => a.City_ID == objContactUsDetails.City_ID).FirstOrDefault();
                        if (checkcontactus != null)
                        {
                            return new HttpResponseMessage()
                            {
                                Content = new StringContent("ContactUs Already Exits.", Encoding.UTF8, "application/json")
                            };
                        }
                    }
                }

                using (var db = new JNVDataContext())
                {
                    if (objContactUsDetails.Contact_Us_ID > 0)
                    {
                        db.Upd_Contact_By_CityID(objContactUsDetails.City_ID, objContactUsDetails.Contact_Us);
                    }
                    else
                    {
                        db.Set_ContatcUs(objContactUsDetails.Contact_Us, objContactUsDetails.City_ID);
                    }
                }

                return new HttpResponseMessage()
                {
                    Content = new StringContent("OK.", Encoding.UTF8, "application/json")
                };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Something went wrong please try after some time.", Encoding.UTF8, "application/json")
                };
            }
        }


        /// <summary>
        /// Get ContactUs details
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetContactUsByCityID(int CityID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_ContactUS_By_CityIDResult> ContactUSDetails = db.Get_ContactUS_By_CityID(CityID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(ContactUSDetails).ToString(), Encoding.UTF8, "application/json")
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
    }
}
