using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SideProject.Models.Entities;
using SideProject.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SideProject.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        //[Route("Test", Name = "Test")]
        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        //[Route("Test", Name = "Test")]
        public IActionResult Test(Test testviewmodel /*AddUserViewModel testviewmodel*/)
        {
            Console.WriteLine("Siker " + testviewmodel.integer /*testviewmodel.name*/);
            return View();
        }

        [HttpGet]
        [Authorize (Roles = "User")]
        public IActionResult Test1()
        {
            var name = User?.Identity?.Name;
            var rolesClaims = User?.FindAll ( ClaimTypes.Role );
            var roles = rolesClaims?.Select(r => r.Value).ToList();
            var roles2 = User?.Claims?.Where(c =>c.Type == ClaimTypes.Role).Select(r => r.Value).ToList();
            return Ok("Authorized User " + name +" " + roles + " " + roles2);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Test2()
        {
            return Ok("Authorized Admin");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]
        public IActionResult Test3()
        {
            return Ok("Authorized Admin and User");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Test4()
        {
            return Ok("Authorized Admin or User");
        }

        [HttpGet]
        public IActionResult Test5()
        {
            return Ok("Authorized Everybody");
        }
    }
}
