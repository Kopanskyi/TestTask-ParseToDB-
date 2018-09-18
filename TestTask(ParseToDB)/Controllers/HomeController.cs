using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using TestTask_ParseToDB_.Models;

namespace TestTask_ParseToDB_.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment environment;

        public HomeController(IHostingEnvironment hostingEnvirontment)
        {
            environment = hostingEnvirontment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0) return Content("file not selected");

            string rootPath = environment.WebRootPath;
            string filePath = $@"{rootPath}\UploadedFiles\{file.FileName}";


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //ViewData["FilePath"] = filePath;

            return View("Index");
        }
    }
}
