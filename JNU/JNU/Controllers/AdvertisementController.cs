﻿using System;
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
    public class AdvertisementController : ApiController
    {
        /// <summary>
        /// Get Advertisement details
        /// </summary>
        /// <param name="AdvertisementID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAdvertisementByEventID(int AdvertisementID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Advertisement_By_AdvertisementIDResult> ContactUSDetails = db.Get_Advertisement_By_AdvertisementID(AdvertisementID).ToList();
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


        /// <summary>
        /// Delete event by event ID
        /// </summary>
        /// <param name="AdvertisementID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteAdvertisement(int AdvertisementID)
        {
            using (var db = new JNVDataContext())
            {
                db.Del_Advertisement_By_AdvertisementID(AdvertisementID);
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
        public HttpResponseMessage Event()
        {
            try
            {
                tbl_advertisement objAdvertisementDetails = new tbl_advertisement();
                objAdvertisementDetails.Advertisement_ID = Convert.ToInt32(HttpContext.Current.Request.Form["Advertisement_ID"]);
                objAdvertisementDetails.Advertisement_Name = Convert.ToString(HttpContext.Current.Request.Form["Advertisement_Name"]);
                objAdvertisementDetails.Position = Convert.ToString(HttpContext.Current.Request.Form["Position"]);
                objAdvertisementDetails.City_ID = Convert.ToString(HttpContext.Current.Request.Form["CityID"]);


                using (var db = new JNVDataContext())
                {
                    if (objAdvertisementDetails.Advertisement_ID > 0)
                    {
                        db.Upd_Advertisement_By_AdvertisementID(objAdvertisementDetails.Advertisement_ID, objAdvertisementDetails.Advertisement_Name, objAdvertisementDetails.Position, objAdvertisementDetails.City_ID);
                    }
                    else
                    {
                        db.Set_Advertisement(objAdvertisementDetails.Advertisement_Name, objAdvertisementDetails.Position, objAdvertisementDetails.City_ID);
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