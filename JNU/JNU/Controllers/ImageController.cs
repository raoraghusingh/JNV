using JNU.DAL;

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
    public class ImageController : ApiController
    {
        /// <summary>
        /// Get all Pictures by City ID
        /// </summary>
        /// <param name="CityID">City ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetPicturesByAlbumID(int AlbumID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Pictures_By_AlbumIDResult> lstPictures = db.Get_Pictures_By_AlbumID(AlbumID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(lstPictures).ToString(), Encoding.UTF8, "application/json")
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
        /// Delete Picture by Picture ID
        /// </summary>
        /// <param name="PictureID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeletePicture(int PictureID)
        {
            using (var db = new JNVDataContext())
            {
                db.Del_Picture_By_PictureID(PictureID);
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Picture Delete Successfully", Encoding.UTF8, "application/json")
                };

            }
        }

        /// <summary>
        /// Add update Picture
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddPicture()
        {
            try
            {
                tbl_picture objPictureDetails = new tbl_picture();
                objPictureDetails.Picture_Name = Convert.ToString(HttpContext.Current.Request.Form["Picture_Name"]);
                objPictureDetails.Album_ID = Convert.ToInt32(HttpContext.Current.Request.Form["Album_ID"]);
                objPictureDetails.City_ID = Convert.ToInt32(HttpContext.Current.Request.Form["City_ID"]);


                using (var db = new JNVDataContext())
                {
                    db.Set_Picture(objPictureDetails.Picture_Name, objPictureDetails.Album_ID, objPictureDetails.City_ID);
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
