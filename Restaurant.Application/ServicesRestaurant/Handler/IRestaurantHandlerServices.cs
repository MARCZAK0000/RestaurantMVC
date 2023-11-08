using Restaurant.Domain.Dto;
using Restaurant.Domain.PaginationResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ServicesRestaurant.Handler
{
    public interface IRestaurantHandlerServices
    {
        Task<PaginationResponse<List<GetRestaurantDto>>> GetAllRestaurantAsync(int pageSize, int pageNumber, string querySearch);

        Task<ParticularGetRestaurantDto> GetRestaurantAsync(string encodeName);

        Task<PaginationResponse<List<GetRestaurantDto>>> GetAllUserRestaurantsAsync(int  pageSize, int pageNumber, string userID);
    }
}
