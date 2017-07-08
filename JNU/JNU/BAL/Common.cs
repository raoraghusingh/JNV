using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace JNU.BAL
{
    public static class Common
    {
        public static string UploadFile(HttpPostedFile file, string mapPath)
        {

            string fileName = new FileInfo(file.FileName).Name;

            if (file.ContentLength > 0)
            {
                Guid id = Guid.NewGuid();

                var filePath = Path.GetFileName(id.ToString() + "_" + fileName);

                if (!File.Exists(mapPath + filePath))
                {
                    file.SaveAs(mapPath + filePath);
                    return filePath;
                }
                return null;
            }
            return null;

        }
    }
}