using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
            ViewBag.Text = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Text = "File not selected";
                return View("Index");
            }

            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension != ".txt")
            {
                ViewBag.Text = "Wrong file extension";
                return View("Index");
            }

            string rootPath = environment.WebRootPath;
            string filePath = $@"{rootPath}\UploadedFiles\{file.FileName}";

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            await ReadFile(filePath);
            return View("Index");
        }

        private async Task ReadFile(string filePath)
        {
            byte[] array;

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                array = new byte[stream.Length];
                await stream.ReadAsync(array, 0, array.Length);
            }

            string textFromFile = Encoding.Default.GetString(array);
            ParsingText(textFromFile);
        }

        private void ParsingText(string textFromFile)
        {
            string wordToSearch = string.Format("{0}", Request.Form["wordToSearch"]);
            string[] sentencesToParse = textFromFile.Split('.');


        }
    }
}
