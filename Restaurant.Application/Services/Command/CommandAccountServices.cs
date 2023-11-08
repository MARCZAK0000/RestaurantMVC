using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Dto;
using Restaurant.Domain.Repostiory;
using Restaurant.Domain.ResponseHelper;

namespace Restaurant.Application.Services.Command
{
    public class CommandAccountServices : ICommandAccountServices
    {

        private readonly IUserRepository _userRepository;

        public CommandAccountServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<Domain.ResponseHelper.Response> CreateAccountAsync(CreateAccountDto create)
        {
            var result = await _userRepository.CreateAsync(create);

            return result;
        }

        public async Task<SignInResult> SignInAsync(SignInDto singIn)
        {
            var result = await _userRepository.SignInAsync(singIn);

            return result;
        }

        public Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var result = _userRepository.ConfirmEmailAsync(userId, token);

            return result;
        }

        public async Task<Response> ChangePhoneNumberAsync(string userID, ChangePhoneDto change)
        {
            var result = await _userRepository.ChangePhoneNumberAsync(userID, change);

            return result;
        }

        public async Task<Response> ChangePasswordAsync(string userId, ChangePasswordDto changePassword)
        {
            var result = await _userRepository.ChangePasswordAsync(userId,changePassword);

            return result;
        }

        
    }
}
