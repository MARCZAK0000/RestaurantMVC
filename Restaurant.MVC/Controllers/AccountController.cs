using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.ApplicationUser.ApplicationUser;
using Restaurant.Application.Services.Command;
using Restaurant.Application.Services.Handler;
using Restaurant.Domain.Dto;
using Restaurant.MVC.Extension;

namespace Restaurant.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly Application.Services.Command.ICommandAccountServices _commandAccountServices;

        private readonly Application.Services.Handler.IHandlerAccountServices _handlerAccountServices; 

        private readonly Application.ApplicationUser.ApplicationUser.IUserContext _currentUser;

        public AccountController(ICommandAccountServices commandAccountServices, IHandlerAccountServices handlerAccountServices, IUserContext currentUser)
        {
            _commandAccountServices = commandAccountServices;
            _handlerAccountServices = handlerAccountServices;
            _currentUser = currentUser;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = _currentUser.GetCurrentUser();

            var result = await _handlerAccountServices.GetInformationsAsync(currentUser.Id);

            return View(result);
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [Authorize]
        [Route("/account/manage/ChangePassword")]
        public IActionResult ChangePassword() 
        {
            return View(new ChangePasswordDto());
        }

        [Authorize]
        [Route("/account/manage/ChangePhoneNumber")]
        public IActionResult ChangePhoneNumber()
        {
            return View(new ChangePhoneDto());
        }
        [Authorize]
        [Route("/account/manage/EmailConfirmation")]
        public IActionResult EmailConfirmation(string Token)
        {
            
            var currentUser= _currentUser.GetCurrentUser();

            var token = Token ?? string.Empty;
            
            return View(new ConfirmEmailDto() { Email = currentUser.Email, Token = token }) ;
        }
        [Route("/account/manage/SuccessfullConfirmation")]
        public IActionResult SuccessfullConfirmation()
        {
            var currentUser = _currentUser.GetCurrentUser();

            return View(new ConfirmEmailDto() { Email = currentUser.Email});
        }

        public async Task<IActionResult> SignOut()
        {
            var user = _currentUser.GetCurrentUser();   

            if (user == null)
            {
                RedirectToAction(nameof(Login));
            }

            await _handlerAccountServices.SignOutAsync();

            this.SetNotification("success", "Git Gud");
            return RedirectToAction(nameof(Login));
        }

        [Route("/account/manage/{UserId}/confirm-email/{Token}")]
        public async Task<IActionResult> ConfirmEmail(string UserId, string Token)
        {
            var command = await _commandAccountServices.ConfirmEmailAsync(UserId, Token);

            return View(command);
        }




        //PostMethods
        [HttpPost]
        public async Task<IActionResult> Login(Domain.Dto.SignInDto singIn)
        {
            if (!ModelState.IsValid)
            {              
                return View(singIn);
            }

            var result = await _commandAccountServices.SignInAsync(singIn);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View(singIn);    
        }


        [HttpPost]
        public async Task<IActionResult> Register(Domain.Dto.CreateAccountDto create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _commandAccountServices.CreateAccountAsync(create);

            if (result.Result)
            {
                return RedirectToAction(nameof(ConfirmEmail), new { UserId = result.UserId, Token = result.ConfirmationToken });
            }

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePhoneNumber(ChangePhoneDto change)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Change Failed";
                ViewBag.Erorr = "Invalid phone number";
                return View(change);
            }

            var user = _currentUser.GetCurrentUser();

            var result = await _commandAccountServices.ChangePhoneNumberAsync(user.Id, change);

            if (!result.Result)
            {
                ViewBag.Message = "Change Failed";
                ViewBag.Error = result.Message;
                return View(change);
            }

            ViewBag.Message = "Change Successed";
            return View(change);
            
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto change)
        {
            if(!ModelState.IsValid) 
            {
                
                return View(change);
            }

            var user = _currentUser.GetCurrentUser();

            var result = await _commandAccountServices.ChangePasswordAsync(user.Id, change);


            if (!result.Result)
            {
                return View(change);
            }

            ViewBag.Message = "Change Successed";
            return View(change);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateToken( ConfirmEmailDto confirm)
        {
            var user = _currentUser.GetCurrentUser();

            var result = await _handlerAccountServices.GenerateEmailTokenAsync(user.Id);

            if(!result.Result) 
            {

                return RedirectToAction(nameof(EmailConfirmation));
            }

            confirm.Token = result.ConfirmationToken;
            return RedirectToAction(nameof(EmailConfirmation),new { Token = result.ConfirmationToken});

        }

        [HttpPost]
        public async Task<IActionResult> SuccessfullConfirmation(ConfirmEmailDto confirm)
        {
            var user = _currentUser.GetCurrentUser();

           
            if(confirm.TokenToEmail == null) 
            {
                return View(confirm);
            }
            var token = confirm.TokenToEmail;
            var result = await _commandAccountServices.ConfirmEmailAsync(user.Id, token);

            if (!result)
            {
                return RedirectToAction(nameof(EmailConfirmation), new {Token = token});
            }

            return View(new ConfirmEmailDto() { Email = user.Email });


        }
    }
}
