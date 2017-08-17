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
    public class BirthdayController : ApiController
    {
        /// <summary>
        /// Get all birthday by cityID
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetBirthdayByCityID(int CityID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Birthday_By_CityIDResult> BirthdayDetails = db.Get_Birthday_By_CityID(CityID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(BirthdayDetails).ToString(), Encoding.UTF8, "application/json")
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

        /// <summary>
        /// Get Birthday by Date
        /// </summary>
        /// <param name="BirthDate"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetBirthdayByDate(DateTime BirthDate)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Birthday_By_CurrentDateResult> BirthdayDetails = db.Get_Birthday_By_CurrentDate(BirthDate).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(BirthdayDetails).ToString(), Encoding.UTF8, "application/json")
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
