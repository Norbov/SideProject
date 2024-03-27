using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SideProject.Models.Entities;
using SideProject.Models;
using SideProject.Data;
using SideProject.Service;
using static System.Net.Mime.MediaTypeNames;

namespace SideProject.Controllers
{
    public class DataController : Controller
    {
        //private readonly AplicationDbContext _context;
        private readonly IDataService _dataService;
        //public readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _iWebHostEnvironment;

        public DataController(/*AplicationDbContext context,*/ IDataService dataService/*, IWebHostEnvironment iWebHostEnvironment*/)
        {
            //_context = context;
            _dataService = dataService;
            //_iWebHostEnvironment = iWebHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upload()
        {

            return View();;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(/*IFormFile file,[FromServices] IWebHostEnvironment iWebHostEnvironment*/ AddImage viewModel)
        {
            /*string fileName = $"{_iWebHostEnvironment.WebRootPath}\\files\\{file.FileName}";

            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }*/

            string user = "Test";
            fileFormat fileFormat = fileFormat.pdf;
            await _dataService.UploadImage(viewModel.file, user, fileFormat);
            /*var image = new Image
            {
                //uploader = viewModel.uploader,
                fileFormat = viewModel.fileFormat,
                image = viewModel.image,
                user = "Test"
            };
            await _context.images.AddAsync(image);
            await _context.SaveChangesAsync();*/
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Download()
        {
            var imageList = await _dataService.Images("Test");
            return View(imageList);
        }

        [HttpPost]
        public async Task<IActionResult> Download(int Id)
        {
            var image = await _dataService.DownloadImage(Id);
            if (image.image == null)
            {
                return View();
            }
            else
            {

                byte[] byteArr = image.image;
                string mimeType = "";
                string format = "";
                switch (image.fileFormat)
                {
                    case fileFormat.pdf:
                        mimeType = "application/pdf";
                        format = "pdf";
                        break;
                    case fileFormat.png:
                        mimeType = "application/png";
                        format = "png";
                        break;
                    default:
                        break;
                }

                return new FileContentResult(byteArr, mimeType)
                {
                    FileDownloadName = $"Image{image.user}{image.Id}.{format}"
                };
            }
        }
    }
}
