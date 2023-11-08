using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Restaurant.Application.ServicesRestaurant.Command;
using Restaurant.Domain.Dto;
using Restaurant.Domain.Enitites;
using Restaurant.Domain.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ServicesRestauran.Command
{
    public class RestaurantCommandServices : IRestaurantCommandServices
    {
        private readonly Domain.Repostiory.IRestaurantRepository _restaurantRepositroy;

        private readonly IMapper _mapper;
        public RestaurantCommandServices(Domain.Repostiory.IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepositroy = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<Response> CreateRestaurantAsync(CreateRestaurantDto createRestaurantDto)
        {

            var restaurant = _mapper.Map<Restaurant.Domain.Enitites.Restaurant>(createRestaurantDto);
            var result = await _restaurantRepositroy.CreateRestaurantAsync(restaurant);

            return result;
        }

        public async Task<Response> UpdateRestaurantAsync(EditRestaurantDto editRestaurantDto, string encodedNamed)
        {
            var result = await _restaurantRepositroy.EditRestaurantAsync(editRestaurantDto, encodedNamed);

            return result;
        }
    }
}
