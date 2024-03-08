using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SideProject.Models.Entities;
using SideProject.Models;
using SideProject.Data;

namespace SideProject.Controllers
{
    public class DataController : Controller
    {
        private readonly AplicationDbContext _context;
        public DataController(AplicationDbContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Upload(AddImage viewModel)
        {
            var image = new Image
            {
                uploader = viewModel.uploader,
                fileFormat = viewModel.fileFormat,
                image = viewModel.image
            };
            await _context.images.AddAsync(image);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
