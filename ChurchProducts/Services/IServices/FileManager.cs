using ChurchProducts.IServices;
using ImageMagick;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace ChurchProducts.Helpers
{
    public class FileManager : IFileService
    {
        public void RemoveFile(string directory)
        {
            if (directory != null && directory != "")
            {
                var fileInfo = new System.IO.FileInfo(Path.GetFullPath("wwwroot//" + directory));
                fileInfo.Delete();
            }
        }

        public string UploadFile(IFormFile file, string directory)
        {
            if (file != null)
            {
                string exte = file.FileName.Split(".").Last();
                var myUniqueFileName = string.Format(@"{0}." + exte, DateTime.Now.Ticks);
                if (directory[0] == '/')
                {
                    directory.Remove(0);
                }
                if (directory[directory.Length - 1] == '/')
                {
                    directory.Remove(directory.Length - 1);
                }
                var path = Path.GetFullPath("wwwroot//" + directory + "//" + myUniqueFileName);


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Close();
                    if (exte == "jpg" || exte == "png" || exte == "jpeg")
                    {
                        var optimizer = new ImageOptimizer();
                        optimizer.Compress(new FileInfo(path));
                    }
                    return directory + "/" + myUniqueFileName;
                }
            }
            else
            {
                return "";
            }
        }
    }
}
