using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Dto;
using Restaurant.Domain.ResponseHelper;

namespace Restaurant.Domain.Repostiory
{
    public interface IUserRepository
    {
        Task<Domain.ResponseHelper.Response> CreateAsync(CreateAccountDto create);

        Task<SignInResult> SignInAsync(SignInDto singIn);

        Task <bool> ConfirmEmailAsync(string userId, string token);

        Task SignOutAsync();

        Task<IdentityUser> GetCurrentUserAsync(string userId);

        Task<Response> ChangePhoneNumberAsync(string userId, ChangePhoneDto changePhone);
        
        Task<Response> ChangePasswordAsync(string userId, ChangePasswordDto changePassword);

        Task<Response> GenerateEmailTokenAsync(string userId);
    }
}
