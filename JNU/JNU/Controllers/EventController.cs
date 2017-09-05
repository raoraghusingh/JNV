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
    public class EventController : ApiController
    {
        /// <summary>
        /// Get all events by City ID
        /// </summary>
        /// <param name="CityID">City ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetEventsByCityID(int CityID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Events_By_CityIDResult> lstEvents = db.Get_Events_By_CityID(CityID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(lstEvents).ToString(), Encoding.UTF8, "application/json")
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
        /// Get Event details
        /// </summary>
        /// <param name="EventID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetEventByID(int EventID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_event_By_eventIDResult> lstEvents = db.Get_event_By_eventID(EventID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(lstEvents).ToString(), Encoding.UTF8, "application/json")
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
        /// Delete event by event ID
        /// </summary>
        /// <param name="EventID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteEvent(int EventID)
        {
            using (var db = new JNVDataContext())
            {
                db.Del_event_By_eventID(EventID);
                return new HttpResponseMessage()
                {
                    Content = new StringContent("User Delete Successfully", Encoding.UTF8, "application/json")
                };

            }
        }

        /// <summary>
        /// Add update Event
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddUpdateEvent()
        {
            try
            {
                tbl_event objEventDetails = new tbl_event();
                objEventDetails.Event_ID = Convert.ToInt32(HttpContext.Current.Request.Form["Event_ID"]);
                objEventDetails.Event_Name = Convert.ToString(HttpContext.Current.Request.Form["Event_Name"]);
                objEventDetails.Event_Date = Convert.ToDateTime(HttpContext.Current.Request.Form["Event_Date"]);
                objEventDetails.City_ID = Convert.ToInt32(HttpContext.Current.Request.Form["City_ID"]);


                using (var db = new JNVDataContext())
                {
                    if (objEventDetails.Event_ID > 0)
                    {
                        db.Upd_Event_By_EventID(objEventDetails.Event_ID, objEventDetails.Event_Name, objEventDetails.Event_Date, objEventDetails.City_ID);
                    }
                    else
                    {
                        db.Set_Event(objEventDetails.Event_Name, objEventDetails.Event_Date, objEventDetails.City_ID);
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


    }
}
