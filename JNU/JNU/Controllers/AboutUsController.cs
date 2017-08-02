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
    public class AboutUsController : ApiController
    {

        /// <summary>
        /// Add update About us
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AboutUs()
        {
            try
            {
                tbl_about_us objAboutUsDetails = new tbl_about_us();
                objAboutUsDetails.About_Us_ID = Convert.ToInt32(HttpContext.Current.Request.Form["AboutUsID"]);
                objAboutUsDetails.About_Us = Convert.ToString(HttpContext.Current.Request.Form["AboutUs"]);
                objAboutUsDetails.City_ID = Convert.ToInt32(HttpContext.Current.Request.Form["CityID"]);

                if (objAboutUsDetails.About_Us_ID == 0)
                {
                    using (var db = new JNVDataContext())
                    {
                        var checkAboutus = db.tbl_about_us.Where(a => a.City_ID == objAboutUsDetails.City_ID).FirstOrDefault();
                        if (checkAboutus != null)
                        {
                            return new HttpResponseMessage()
                            {
                                Content = new StringContent("About Us Already Exits.", Encoding.UTF8, "application/json")
                            };
                        }
                    }
                }

                using (var db = new JNVDataContext())
                {
                    if (objAboutUsDetails.About_Us_ID > 0)
                    {
                        db.Upd_AboutUs_By_CityID(objAboutUsDetails.City_ID, objAboutUsDetails.About_Us);
                    }
                    else
                    {
                        db.Set_AboutUs(objAboutUsDetails.About_Us, objAboutUsDetails.City_ID);
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
        /// Get AboutUs details
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAboutUsByCityID(int CityID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {   
                    List<Get_AboutUS_By_CityIDResult> AboutUSDetails = db.Get_AboutUS_By_CityID(CityID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(AboutUSDetails).ToString(), Encoding.UTF8, "application/json")
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
