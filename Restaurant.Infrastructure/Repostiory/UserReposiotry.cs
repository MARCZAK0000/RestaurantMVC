using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Dto;
using Restaurant.Domain.ResponseHelper;
using System.Web;

namespace Restaurant.Infrastructure.Repostiory
{
    public class UserReposiotry : Domain.Repostiory.IUserRepository
    {

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IPasswordHasher<IdentityUser> _passwordHasher;

        private readonly SignInManager<IdentityUser> _signInManager;

        public UserReposiotry(UserManager<IdentityUser> userManager, IPasswordHasher<IdentityUser> passwordHasher, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _signInManager = signInManager;
        }


        public async Task<Domain.ResponseHelper.Response> CreateAsync(CreateAccountDto create)
        {
            var responseBuilder = new Domain.ResponseHelper.ResponseBuilder();
            if (!create.Password.ToLower().Equals(create.ConfirmPassword.ToLower()))
            {
                 var responseFailed = responseBuilder
                    .SetResult(false)
                    .Build();


                return responseFailed;

            }
            var user = new IdentityUser() 
            { 
                Email = create.Email,   
                UserName = create.Email
            };

            var hashPassword = _passwordHasher.HashPassword(user, create.Password);
            user.PasswordHash = hashPassword;
            var result = await _userManager.CreateAsync(user);

            await _userManager.AddToRoleAsync(user, "User");


            var confirmationToken = string.Empty;
            if(result.Succeeded)
            {
                confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user); 
            }


            var code = HttpUtility.UrlEncode(confirmationToken);
            var responseSuccessed = responseBuilder
                .SetResult(result.Succeeded)
                .SetConfirmationEmailToken(code)
                .SetUserId(user.Id)
                .Build();

            return responseSuccessed;
        }

        public async Task<SignInResult> SignInAsync(SignInDto singIn)
        {

            var user = await _userManager.FindByEmailAsync(singIn.Email);

            if (user == null)
            {
                return SignInResult.Failed;
            }

            var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, singIn.Password);

            if(verifyPassword == PasswordVerificationResult.Failed)
            {
                return SignInResult.Failed;
            }
            user.UserName = user.Email;
            var result = await _signInManager.PasswordSignInAsync(user.UserName, singIn.Password, singIn.RememberMe, lockoutOnFailure: false);

            return result;
        }



        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var result = false;

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null || token is null) 
            {
                return result;
            }


            var confirm = await _userManager.ConfirmEmailAsync(user, token);

            if (confirm.Succeeded == false) //if token without decode will not work
            {
                var decodeToken = HttpUtility.UrlDecode(token);

                confirm = await _userManager.ConfirmEmailAsync(user,decodeToken);

            }

            return confirm == IdentityResult.Success? true: false;
            
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityUser> GetCurrentUserAsync(string userId)
        {
            var result = await _userManager.FindByIdAsync(userId);

            if(result is null) 
            {
                throw new InvalidDataException("Invalid Data");
            }

            return result;

        }

        public async Task<Response> ChangePhoneNumberAsync(string userId, ChangePhoneDto changePhone)
        {
            var _response = new ResponseBuilder();

            var user = await _userManager.FindByIdAsync(userId);

            if(user is null)
            {
                return _response
                    .SetResult(false)
                    .SetMessage("Invalid user ID")
                    .Build();
            }

            if(user.PhoneNumber == changePhone.NewPhoneNumber)
            {
                return _response
                    .SetResult(false)
                    .SetMessage("New number is the same as old number")
                    .Build();
            }

            var token = await _userManager.GenerateChangePhoneNumberTokenAsync(user, changePhone.NewPhoneNumber);

            var changeNumber = await _userManager.ChangePhoneNumberAsync(user, changePhone.NewPhoneNumber, token);

            if(changeNumber.Succeeded == false)
            {
                var errors = changeNumber.Errors.ToList();
                var message = string.Empty;
                foreach (var item in errors)
                {
                    message += item.Description + "\r\n";    
                }

                return _response.
                    SetResult(false)
                    .SetMessage(message)
                    .Build();
            }
            return _response
                .SetResult(true)
                .Build ();  
        }

        public async Task<Response> ChangePasswordAsync(string userId, ChangePasswordDto changePassword)
        {
            var _responseBuilder = new ResponseBuilder();
            var user = await _userManager.FindByIdAsync(userId);

            if(user is null)
            {
                
                return _responseBuilder
                    .SetResult(false)
                    .SetMessage("Invalid UserId")
                    .Build();
            }

            if(changePassword.NewPassword.ToLower()!= changePassword.ConfirmPassword.ToLower()) 
            {
                return _responseBuilder
                   .SetResult(false)
                   .SetMessage("Passwords are not the same")
                   .Build();
            }

            var newPassword = await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);

            if(newPassword.Succeeded == false) 
            {
                var errors = newPassword.Errors.ToArray();


                var message = string.Empty;
                foreach (var item in errors)
                {
                    message += item.Description + "\r\n";
                }

                return _responseBuilder
                    .SetResult(false)
                    .SetMessage(message)
                    .Build();
            }


            return _responseBuilder
                .SetResult(true)
                .Build();

            
        }

        public async Task<Response> GenerateEmailTokenAsync(string userId)
        {

            var response = new ResponseBuilder();
            var user = await _userManager.FindByIdAsync(userId);
            
            if(user is null)
            {
                return response
                    .SetMessage("Invalid UserId")
                    .SetResult(false)
                    .Build();
            }

            var result = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            if (string.IsNullOrEmpty(result))
            {
                return response
                    .SetMessage("There is a problem with token")
                    .SetResult(false)
                    .Build();
            }

            var encode = HttpUtility.HtmlEncode(result);
            return response
                .SetResult(true)
                .SetConfirmationEmailToken(encode) 
                .Build();
        }
    }
}
