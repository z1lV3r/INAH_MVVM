using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.Services
{
    public class FileService
    {
        public string GetImagePath(string id)
        {
            var files = Directory.GetFiles(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images"), "*" + id.ToString() + "*");
            return files.Length > 0 ? files.First() : "/Resources/Images/notFound.png";
        }
    }
}
