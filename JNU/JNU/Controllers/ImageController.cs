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
    public class ImageController : ApiController
    {

        /// <summary>
        /// Select all pictures by CityID
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SelectAllPictures(int CityID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Pictures_By_CityIDResult> PictureDetails = db.Get_Pictures_By_CityID(CityID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(PictureDetails).ToString(), Encoding.UTF8, "application/json")
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
        /// Select all pictures AlbumID
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SelectAllPicturesByAlbumID(int AlbumID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Pictures_By_AlbumNameResult> PictureDetails = db.Get_Pictures_By_AlbumName(AlbumID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(PictureDetails).ToString(), Encoding.UTF8, "application/json")
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
        /// Delete Picture by PictureID
        /// </summary>
        /// <param name="PictureID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeletePictureByPictureID(int PictureID)
        {
            using (var db = new JNVDataContext())
            {
                db.Del_Picture_By_PictureID(PictureID);
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Picture Deleted Successfully", Encoding.UTF8, "application/json")
                };

            }
        }

        /// <summary>
        /// Delete Picture by AlbumID
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeletePictureByAlbumID(int AlbumID)
        {
            using (var db = new JNVDataContext())
            {
                db.Del_Pictures_By_AlbumName(AlbumID);
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Pictures Deleted Successfully", Encoding.UTF8, "application/json")
                };

            }
        }

        /// <summary>
        /// Add Picture
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Picture()
        {
            try
            {
                tbl_picture objPictureDetails = new tbl_picture();
                objPictureDetails.Picture_Name = Convert.ToString(HttpContext.Current.Request.Form["Picture_Name"]);
                objPictureDetails.Album_Name = Convert.ToString(HttpContext.Current.Request.Form["Album_Name"]);
                objPictureDetails.City_ID = Convert.ToInt32(HttpContext.Current.Request.Form["City_ID"]);


                using (var db = new JNVDataContext())
                {

                    db.Set_Picture(objPictureDetails.Picture_Name, objPictureDetails.Album_Name, objPictureDetails.City_ID);

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
