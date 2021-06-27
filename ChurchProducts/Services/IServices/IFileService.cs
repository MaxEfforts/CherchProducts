using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchProducts.IServices
{
    public interface IFileService
    {
        public string UploadFile(IFormFile file, string directory);
        public void RemoveFile(string directory);
    }
}
