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
    public class VideoController : ApiController
    {
        /// <summary>
        /// Select all Videos by CityID
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SelectAllVideos(int CityID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Videos_By_CityIDResult> VideoDetails = db.Get_Videos_By_CityID(CityID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(VideoDetails).ToString(), Encoding.UTF8, "application/json")
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
        /// Select all Videos AlbumID
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SelectAllVideosByAlbumID(int AlbumID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Videos_By_AlbumNameResult> VideoDetails = db.Get_Videos_By_AlbumName(AlbumID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(VideoDetails).ToString(), Encoding.UTF8, "application/json")
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
        /// Delete Video by VideoID
        /// </summary>
        /// <param name="VideoID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteVideoByVideoID(int VideoID)
        {
            using (var db = new JNVDataContext())
            {
                db.Del_Video_By_VideoID(VideoID);
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Video Deleted Successfully", Encoding.UTF8, "application/json")
                };

            }
        }

        /// <summary>
        /// Delete Video by AlbumID
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteVideoByAlbumID(int AlbumID)
        {
            using (var db = new JNVDataContext())
            {
                db.Del_Videos_By_AlbumName(AlbumID);
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Videos Deleted Successfully", Encoding.UTF8, "application/json")
                };

            }
        }

        /// <summary>
        /// Add Video
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Video()
        {
            try
            {
                tbl_video objVideoDetails = new tbl_video();
                objVideoDetails.Video_Name = Convert.ToString(HttpContext.Current.Request.Form["Video_Name"]);
                objVideoDetails.Album_Name = Convert.ToString(HttpContext.Current.Request.Form["Album_Name"]);
                objVideoDetails.City_ID = Convert.ToInt32(HttpContext.Current.Request.Form["City_ID"]);


                using (var db = new JNVDataContext())
                {

                    db.Set_Picture(objVideoDetails.Video_Name, objVideoDetails.Album_Name, objVideoDetails.City_ID);

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
