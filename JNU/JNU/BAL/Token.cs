using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JNU.BAL
{
    public class Token
    {
        public static string GenerateToken(string username)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var now = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
            now = now + Convert.ToDouble(ConfigurationManager.AppSettings["TokenExpireTime"]);
            var payload = new Dictionary<string, object>()
                {
                  
                    {"username", username},
                    { "exp", now }
                };
            HttpContext.Current.Session["payload"] = payload;
            var secretKey = ConfigurationManager.AppSettings["TokenSecretKey"].ToString();
            return JWT.JsonWebToken.Encode(payload, secretKey, JWT.JwtHashAlgorithm.HS256);
        }
        public static string IsValidToken(string token)
        {
            var secretKey = ConfigurationManager.AppSettings["TokenSecretKey"].ToString();
            try
            {
                string jsonPayload = JWT.JsonWebToken.Decode(token, secretKey);
                return "Authorised";
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Invalid token!");                
                return ex.Message;
            }
        }
    }
}