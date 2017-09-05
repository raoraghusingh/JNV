﻿using JNU.DAL;

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace JNU.Controllers
{
    public class VideoController : ApiController
    {
        /// <summary>
        /// Get all videos by City ID
        /// </summary>
        /// <param name="CityID">City ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetVideosByAlbumID(int AlbumID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Videos_By_AlbumIDResult> lstVideos = db.Get_Videos_By_AlbumID(AlbumID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(lstVideos).ToString(), Encoding.UTF8, "application/json")
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
        /// Delete Video by Video ID
        /// </summary>
        /// <param name="VideoID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteVideo(int VideoID)
        {
            using (var db = new JNVDataContext())
            {
                db.Del_Video_By_VideoID(VideoID);
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Video Delete Successfully", Encoding.UTF8, "application/json")
                };

            }
        }

        /// <summary>
        /// Add update Video
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddVideo()
        {
            try
            {
                tbl_video objVideoDetails = new tbl_video();                
                objVideoDetails.Video_Name = Convert.ToString(HttpContext.Current.Request.Form["Video_Name"]);
                objVideoDetails.Album_ID = Convert.ToInt32(HttpContext.Current.Request.Form["Album_ID"]);
                objVideoDetails.City_ID = Convert.ToInt32(HttpContext.Current.Request.Form["City_ID"]);


                using (var db = new JNVDataContext())
                {
                    db.Set_Video(objVideoDetails.Video_Name, objVideoDetails.Album_ID, objVideoDetails.City_ID);
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
