using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SideProject.Data;
using SideProject.Models;
using SideProject.Models.Entities;

namespace SideProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AplicationDbContext _context;

        public UserController(AplicationDbContext context)
        {
            _context = context;
        }

        /*[HttpPost]
        public async Task<ActionResult<List<User>>>AddUser2(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.users.ToListAsync());
        }*/

        [HttpGet]
        [Route("Add", Name = "Add")]
        public IActionResult Add()
        {

            return View();
            //return ControllerContext.MyDisplayRouteInfo();
        }

        [HttpPost]
        [Route("Add", Name = "Add")]
        public async Task<IActionResult> Add(AddUserViewModel viewModel)
        {
            var user = new User
            {
                name = viewModel.name,
                email = viewModel.email
            };
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        [Route("Users", Name = "GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _context.users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        //[Route("Users", Name = "Edit")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _context.users.FindAsync(id);
            return View(user);
        }

        [HttpPost]
        [Route("Users", Name = "Edit")]
        public async Task<IActionResult> Edit(User viewModel)
        {
            var user = await _context.users.FindAsync(viewModel.Id);
            
            if(user != null)
            {
                user.name = viewModel.name;
                user.email = viewModel.email;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllUser", "User");
        }
        /*[HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            return Ok(await _context.users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser(int id)
        {
            var user = _context.users.FindAsync(id);
            if(user == null)
            {
                return BadRequest("User does not exist");
            }
            return Ok(user);
        }*/
    }
}
