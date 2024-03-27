using Microsoft.EntityFrameworkCore;
using SideProject.Models.Entities;
using SideProject.Models;
using SideProject.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace SideProject.Service
{
    public interface IApplicationUserService
    {
        public Task Create(SignUpModel signUpModel);

        public Task<string> Login(ApplicationUser applicationUser);
    }

    public class ApplicationUserService : IApplicationUserService
    {
        private readonly AplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public ApplicationUserService(AplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string CreateToken(ApplicationUser applicationUser)
        {
            /*List<Claim> claims = new List<Claim>()
            {

            };*/

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, applicationUser.UserName)//,
                                                                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in applicationUser.roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task Create(SignUpModel signUpModel)
        {
            var account = new ApplicationUser()
            {
                UserName = signUpModel.userName,
                Email = signUpModel.email,
                password = signUpModel.password,
                roles = new List<string> {"User"}
            };

            await _context.accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task<string> Login(ApplicationUser applicationUser)
        {
            var account = await _context.accounts.FindAsync(applicationUser.UserName);
            if (account != null && applicationUser.password == account.password)
            {
                string token = CreateToken(account);
                Console.WriteLine("Found " + applicationUser.UserName);
                Console.WriteLine("Token " + token);
                //Response.Cookies.Append(Constans.AccessToken,token);
                return token;
            }
            return null;
        }
    }
}
