using Microsoft.AspNetCore.Identity;
using SideProject.Models;
using SideProject.Models.Entities;

namespace SideProject.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> SingUpAsync(SignUpModel signUpModel)
        {
            var user = new ApplicationUser()
            {
                userName = signUpModel.userName,
                email = signUpModel.email,
                password = signUpModel.password
            };

            return await _userManager.CreateAsync(user, signUpModel.password);
        }
    }
}
