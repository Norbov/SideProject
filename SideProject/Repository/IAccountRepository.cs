using Microsoft.AspNetCore.Identity;
using SideProject.Models;
using SideProject.Models.Entities;

namespace SideProject.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SingUpAsync(SignUpModel signUpModel);
    }
}
