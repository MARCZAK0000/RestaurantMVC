﻿using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.ServicesRestaurant.Handler;
using Restaurant.Application.ServicesRestaurant.Command;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Domain.Dto;
using Restaurant.Application.ApplicationUser.ApplicationUser;
using Restaurant.MVC.Extension;
using Restaurant.Application.ServicesDishes.Command;

namespace Restaurant.MVC.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantHandlerServices _restaurantHandlerServices;

        private readonly IRestaurantCommandServices _restaurantCommandServices;

        private readonly IUserContext _userContext;

        private readonly IDishesServicesCommand _dishesServicesCommand;

        public RestaurantController(IRestaurantHandlerServices restaurantHandlerServices, IRestaurantCommandServices restaurantCommandServices, IUserContext userContext,
            IDishesServicesCommand dishesServicesCommand)
        {
            _restaurantHandlerServices = restaurantHandlerServices;
            _restaurantCommandServices = restaurantCommandServices;
            _userContext = userContext;
            _dishesServicesCommand = dishesServicesCommand;
        }


        public async Task<IActionResult> Index(int pageNumber = 1, string querySearch = default!)
        {
            const int pageSize = 10;

            var result = await _restaurantHandlerServices.GetAllRestaurantAsync(pageSize, pageNumber, querySearch);

            return View(result);
        }
        [Authorize]
        public IActionResult Create()
        {
            var user = _userContext.GetCurrentUser();
            if (!_userContext.CheckUser(user))
            {
                return RedirectToAction("NoAccess", "Home");
            }
            return View( new Domain.Dto.CreateRestaurantDto());
        }
        [Authorize]
        [Route("/Restaurant/{userID}/UserRestaruants")]
        public async Task<IActionResult> UserRestaruants(string userID, int pageNumber = 1)
        {
            const int pageSize = 10;

            var user = _userContext.GetCurrentUser();

            if (!_userContext.CheckUser(user))
            {
                return RedirectToAction("NoAccess", "Home");
            }


            if (userID is null)
            {
                return RedirectToAction("Index", "Home");
            }
            var result = await _restaurantHandlerServices.GetAllUserRestaurantsAsync(pageSize, pageNumber, userID);
            return View(result);
        }


        [Route("/Restaurant/{encodedName}/details")]
        public async Task<IActionResult> Details(string encodedName)
        {


            if(encodedName is null)
            {
                return RedirectToAction("Index");
            }
            var result = await _restaurantHandlerServices.GetRestaurantAsync(encodedName);
            return View(result);
        }

        [Authorize]
        [Route("/Restaurant/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {

            if (encodedName is null)
            {
                return RedirectToAction("Index");
            }
            var user = _userContext.GetCurrentUser();

            if (!_userContext.CheckUser(user))
            {
                return RedirectToAction("NoAccess", "Home");
            }

            var result = await _restaurantHandlerServices.GetRestaurantAsync(encodedName);

            if (!result.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            return View(new EditRestaurantDto()
            {
                OldName = result.Name,
                OldDescription = result.Description,
                OldType = result.Type,
                OldStreet = result.Street,
                OldCity = result.City,
                OldPostalCode = result.PostalCode,
                OldPostalCity = result.PostalCity,
                OldEmail = result.Email,
                OldPhoneNumber = result.PhoneNumber,
                EncodedName  = encodedName
            });
        }


        //HTTPReques
        [HttpPost]
        public async Task<IActionResult> Create(CreateRestaurantDto create)
        {
            
            if(!ModelState.IsValid) 
            {
                return View(create);
            }

            var user = _userContext.GetCurrentUser();

            if (user is null)
            {
                return RedirectToAction("Login", "AccountController");
            }
            var result = await _restaurantCommandServices.CreateRestaurantAsync(create);

            if(!result.Result) 
            {
                return View(create); 
            }
            this.SetNotification("success", "Git Gud");
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [Route("/Restaurant/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(EditRestaurantDto edit, string encodedName)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit), new { encodedName = encodedName });
            }

            var user = _userContext.GetCurrentUser();
            if (user is null)
            {
                return RedirectToAction("Login", "AccountController");
            }

            var result = await _restaurantCommandServices.UpdateRestaurantAsync(edit, encodedName);

            if (!result.Result)
            {
                ViewBag.Error = result.Message;
                return View(edit);
            }

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [Route("/Restaurant/{encodedName}/Edit/Dish")]
        public async Task<IActionResult> AddDish([FromBody] DishDto dish, string encodedName)
        {
            var user = _userContext.GetCurrentUser();

            if (!_userContext.CheckUser(user))
            {
                return Forbid();
            }

            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }

          
            var result = await _dishesServicesCommand.CreateDishAsync(dish, encodedName);

            if(!result.Result) 
            {
                this.SetNotification("Error", "Can't add Dishes");
                return BadRequest();
            }
            this.SetNotification("Success", "Congratulations");
            return Ok();
        }

        [HttpGet]
        [Route("/Restaurant/{encodedName}/Edit/Dish")]
        public async Task<IActionResult> GetDish(string encodedName)
        {
            var user = _userContext.GetCurrentUser();

            if (!_userContext.CheckUser(user))
            {
                return Forbid();
            }

            var result = await 
        }
    }
}
