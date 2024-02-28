using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        /*private readonly AplicationDbContext _context;

        public UserController(AplicationDbContext context)
        {
            _context = context;
        }*/

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
        public IActionResult Add(AddUserViewModel viewModel)
        {
            return View();
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
