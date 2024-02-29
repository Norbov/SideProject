using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SideProject.Models.Entities;
using SideProject.Models;

namespace SideProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        [Route("Test", Name = "Test")]
        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        [Route("Test", Name = "Test")]
        public IActionResult Test(Test testviewmodel)
        {
            return View();
        }
    }
}
