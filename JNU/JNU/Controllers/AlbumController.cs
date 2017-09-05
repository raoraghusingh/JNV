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
    public class AlbumController : ApiController
    {
        /// <summary>
        /// Get all Albums by City ID
        /// </summary>
        /// <param name="CityID">City ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAlbumsByCityID(int CityID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Albums_By_CityIDResult> lstAlbums = db.Get_Albums_By_CityID(CityID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(lstAlbums).ToString(), Encoding.UTF8, "application/json")
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
        /// Delete Album by Album ID
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteAlbum(int AlbumID)
        {
            using (var db = new JNVDataContext())
            {
                db.Del_Album_By_ID(AlbumID);
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Album Delete Successfully", Encoding.UTF8, "application/json")
                };

            }
        }

        /// <summary>
        /// Add update Album
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddAlbum()
        {
            try
            {
                tbl_Album objAlbumDetails = new tbl_Album();
                objAlbumDetails.Album_Name = Convert.ToString(HttpContext.Current.Request.Form["Album_Name"]);                
                objAlbumDetails.City_ID = Convert.ToInt32(HttpContext.Current.Request.Form["City_ID"]);


                using (var db = new JNVDataContext())
                {
                    db.Set_Album(objAlbumDetails.Album_Name,objAlbumDetails.City_ID);
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