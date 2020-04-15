using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PurchaSaler.Api.Services
{
    public class UploadImages
    {
        private readonly IWebHostEnvironment _environment;
        public UploadImages(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public string Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\images\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\images\\");
                    }
                    using (FileStream fileStream = File.Create
                        (_environment.WebRootPath + "\\images\\" + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        return  "http:\\\\localhost:5000"+"\\images\\" + file.FileName;
                    }
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
        }
    }
}
