using Restaurant.Domain.Dto;
using Restaurant.Domain.Enitites;
using Restaurant.Domain.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ServicesDishes.Command
{
    public interface IDishesServicesCommand
    {
        Task<Response> CreateDishAsync(DishDto newDish, string RestaurantEncodedName);

        Task<Response> EditDishAsync(string RestaurantEncodedName, string encodedName, EditDishDto edit);

        Task<Response> DeleteDishAsync(string restaurantEncodedName, string dishEncodedName);
    }
}
