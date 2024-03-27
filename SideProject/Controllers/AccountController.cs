using Microsoft.AspNetCore.Mvc;
using SideProject.Data;
using SideProject.Models;
using SideProject.Models.Entities;
using SideProject.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using SideProject.Service;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace SideProject.Controllers
{
    public class AccountController : Controller
    {
        //public readonly IAccountRepository _accountRepository;
        //private readonly AplicationDbContext _context;
        //private readonly IConfiguration _configuration;
        private readonly IApplicationUserService _applicationUserService;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(/*IAccountRepository accountRepository*//*AplicationDbContext context, IConfiguration configuration,*/ IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager)
        {
            //_accountRepository = accountRepository;
            //_context = context;
            //_configuration = configuration;
            _applicationUserService = applicationUserService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser applicationUser)
        {
            /*var account = await _context.accounts.FindAsync(applicationUser.userName);
            if (account != null && applicationUser.password == account.password)
            {
                string token = CreateToken(account);
                Console.WriteLine("Found " + applicationUser.userName);
                Console.WriteLine("Token " + token);
                //Response.Cookies.Append(Constans.AccessToken,token);
                return Ok(token);
            }*/

            string token = await _applicationUserService.Login(applicationUser);
            if(token != null)
            {
                return Ok(token);
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
            /*var account = new ApplicationUser()
            {
                userName = signUpModel.userName,
                email = signUpModel.email,
                password = signUpModel.password,
                Role = "User"
            };

            await _context.accounts.AddAsync(account);
            await _context.SaveChangesAsync();*/

            if (_userManager.Users.Any(u => u.UserName == signUpModel.userName || u.Email == signUpModel.email))
            {
                throw new ApplicationException("Username/Email already exists!");
            }
            var user = new ApplicationUser
            {
                UserName = signUpModel.userName,
                Email = signUpModel.email
            };

            var result = await _userManager.CreateAsync(user, signUpModel.password);
            await _applicationUserService.Create(signUpModel);

            return result.Succeeded ? RedirectToAction("Login", "Account") : throw new ApplicationException("Registration failed!");
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
