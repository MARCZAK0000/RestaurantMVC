using Restaurant.Domain.Dto;
using Restaurant.Domain.PaginationResponse;
using Restaurant.Domain.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ServicesDishes.Handler
{
    public interface IDishesServicesHandler
    {
        Task<PaginationResponse<List<ShowDishes>>> GetRestaurantDishesAsync(string restaurantEncodedName, int PageSize, int PageNumber); 
    }
}
