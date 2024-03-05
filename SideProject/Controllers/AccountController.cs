using Microsoft.AspNetCore.Mvc;
using SideProject.Data;
using SideProject.Models;
using SideProject.Models.Entities;
using SideProject.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace SideProject.Controllers
{
    public class AccountController : Controller
    {
        //public readonly IAccountRepository _accountRepository;
        private readonly AplicationDbContext _context;
        public AccountController(/*IAccountRepository accountRepository*/AplicationDbContext context)
        {
            //_accountRepository = accountRepository;
            _context = context;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser applicationUser)
        {
            var account = await _context.accounts.FindAsync(applicationUser.userName);
            if (account != null && applicationUser.password == account.password)
            {
                Console.WriteLine("Found " + applicationUser.userName);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignUpModel signUpModel)
        {
            Console.WriteLine("Test");
            var account = new ApplicationUser()
            {
                userName = signUpModel.userName,
                email = signUpModel.email,
                password = signUpModel.password
            };

            await _context.accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "Account");
        }

        /*[HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await _accountRepository.SingUpAsync(signUpModel);
            

            if (result.Succeeded)
            {
                //return Ok(result.Succeeded);
                return RedirectToAction("Index");
            }
            return Unauthorized();
        }*/
    }
}
