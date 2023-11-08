using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Dto;
using Restaurant.Domain.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services.Command
{
    public interface ICommandAccountServices
    {
        Task <Domain.ResponseHelper.Response> CreateAccountAsync(CreateAccountDto create);

        Task<SignInResult> SignInAsync(SignInDto singIn);

        Task<bool> ConfirmEmailAsync(string userId, string token);

        Task<Response> ChangePhoneNumberAsync(string userID, ChangePhoneDto change);

        Task<Response> ChangePasswordAsync(string userId, ChangePasswordDto changePassword);

        
    }
}
