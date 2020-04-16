using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaSaler.Api.Services
{
    public class UploadPhotos
    {
        private readonly IWebHostEnvironment _environment;

        public UploadPhotos(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public List<string> Upload(List<IFormFile> files)
        {
            string path = "http:\\\\localhost:5000" + "\\images\\";
            //返回的文件地址
            List<string> filesPath = new List<string>();
            try
            {
                if (!Directory.Exists(_environment.WebRootPath + "\\images\\"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\images\\");
                }
                foreach (var item in files)
                {
                    if (item != null)
                    {
                        //插入图片数据                 
                        using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\images\\" + item.FileName))
                        {
                            item.CopyTo(fileStream);
                            fileStream.Flush();
                        }
                        filesPath.Add(path + item.FileName);
                    }
                }
                return filesPath;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
