using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CardsHost.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ImageHostController : Controller
    {
       // public static IHostingEnvironment _environment;
        public ImageHostController()
        {
            
        }
        public class FileUploadApi
        {
            public IFormFile files { get; set; }
        }

        [HttpPost]
        public async Task<string> Index(string files)
        {
            var root = Environment.GetEnvironmentVariable("root");
            if(files.Length > 0)
            {
                try
                {
                    if(!Directory.Exists(root + files.ToString()))
                    {
                        Directory.CreateDirectory(root + files);
                    }
                }catch(Exception ex)
                {
                    return ex.ToString();
                }
                using(FileStream s = System.IO.File.Create(root + files))
                {
                    
                   
                    s.Flush();
                    return files;
                }
            }
            return "";
        }
    }
}
