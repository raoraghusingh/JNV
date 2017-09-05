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
    public class FacultyController : ApiController
    {

        /// <summary>
        /// Get all teacher by cityID
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFacultiesByCityID(int CityID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Teachers_By_CityIDResult> TeacherDetails = db.Get_Teachers_By_CityID(CityID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(TeacherDetails).ToString(), Encoding.UTF8, "application/json")
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
        /// Get all teacher by TeacherID
        /// </summary>
        /// <param name="TeacherID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFacultyByID(int FacultyID)
        {
            try
            {
                using (var db = new JNVDataContext())
                {
                    List<Get_Teacher_By_TeacherIDResult> TeacherDetails = db.Get_Teacher_By_TeacherID(FacultyID).ToList();
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(JArray.FromObject(TeacherDetails).ToString(), Encoding.UTF8, "application/json")
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
        /// Delete Faculty by FacultyID
        /// </summary>
        /// <param name="FacultyID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteFaculty(int FacultyID)
        {
            using (var db = new JNVDataContext())
            {
                db.Del_Teacher_By_TeacherID(FacultyID);
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Faculty Deleted Successfully", Encoding.UTF8, "application/json")
                };

            }
        }

        /// <summary>
        /// Add/Update Faculty
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddUpdateFaculty()
        {
            try
            {
                tbl_teacher objTeacherDetails = new tbl_teacher();
                objTeacherDetails.Teacher_ID = Convert.ToInt32(HttpContext.Current.Request.Form["Teacher_ID"]);
                objTeacherDetails.Teacher_Name = Convert.ToString(HttpContext.Current.Request.Form["Teacher_Name"]);
                objTeacherDetails.Email = Convert.ToString(HttpContext.Current.Request.Form["Email"]);
                objTeacherDetails.Phone = Convert.ToString(HttpContext.Current.Request.Form["Phone"]);
                objTeacherDetails.School = Convert.ToString(HttpContext.Current.Request.Form["School"]);
                objTeacherDetails.Subject = Convert.ToString(HttpContext.Current.Request.Form["Subject"]);
                objTeacherDetails.City_ID = Convert.ToInt32(HttpContext.Current.Request.Form["City_ID"]);
                objTeacherDetails.State_ID = Convert.ToInt32(HttpContext.Current.Request.Form["State_ID"]);


                using (var db = new JNVDataContext())
                {
                    if (objTeacherDetails.Teacher_ID > 0)
                    {
                        db.Upd_Teacher_By_TeacherID(objTeacherDetails.Teacher_ID, objTeacherDetails.Teacher_Name, objTeacherDetails.Email, objTeacherDetails.Phone, objTeacherDetails.School, objTeacherDetails.Subject, objTeacherDetails.City_ID, objTeacherDetails.State_ID);
                    }
                    else
                    {
                        db.Set_Teacher(objTeacherDetails.Teacher_Name, objTeacherDetails.Email, objTeacherDetails.Phone, objTeacherDetails.School, objTeacherDetails.Subject, objTeacherDetails.City_ID, objTeacherDetails.State_ID);
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
