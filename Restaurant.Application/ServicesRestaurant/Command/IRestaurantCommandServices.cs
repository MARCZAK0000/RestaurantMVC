using Restaurant.Domain.Dto;
using Restaurant.Domain.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ServicesRestaurant.Command
{
    public interface IRestaurantCommandServices
    {
        Task<Response> CreateRestaurantAsync(CreateRestaurantDto createRestaurantDto);

        Task<Response> UpdateRestaurantAsync(EditRestaurantDto editRestaurantDto, string encodedName);
    }
}
