using Microsoft.AspNetCore.Mvc;
using SideProject.Data;
using SideProject.Models;
using SideProject.Models.Entities;
using SideProject.Repository;

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



        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Register(SignUpModel signUpModel)
        {
            var account = new ApplicationUser()
            {
                userName = signUpModel.userName,
                email = signUpModel.email,
                password = signUpModel.password
            };

            await _context.accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return View();
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
