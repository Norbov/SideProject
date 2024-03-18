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

namespace SideProject.Controllers
{
    public class AccountController : Controller
    {
        //public readonly IAccountRepository _accountRepository;
        private readonly AplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IApplicationUserService _applicationUserService;

        public AccountController(/*IAccountRepository accountRepository*/AplicationDbContext context, IConfiguration configuration, IApplicationUserService applicationUserService)
        {
            //_accountRepository = accountRepository;
            _context = context;
            _configuration = configuration;
            _applicationUserService = applicationUserService;
        }

        private string CreateToken(ApplicationUser applicationUser)
        {
            /*List<Claim> claims = new List<Claim>()
            {
                
            };*/

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, applicationUser.userName)//,
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in applicationUser.roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );*/

            var jwt  = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
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
                string token = CreateToken(applicationUser);
                Console.WriteLine("Found " + applicationUser.userName);
                Console.WriteLine("Token " + token);
                //Response.Cookies.Append(Constans.AccessToken,token);
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

            await _applicationUserService.Create(signUpModel);

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
