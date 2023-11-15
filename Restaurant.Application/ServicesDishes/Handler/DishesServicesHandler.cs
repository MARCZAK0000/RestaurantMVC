using AutoMapper;
using Restaurant.Domain.Dto;
using Restaurant.Domain.PaginationResponse;
using Restaurant.Domain.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ServicesDishes.Handler
{
    public class DishesServicesHandler : IDishesServicesHandler
    {
        private readonly IRestaurantRepository _restaurantRepository;

        private readonly IMapper _mapper;
        public DishesServicesHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<ShowDishes>> GetRestaurantDishes(string restaurantEncodedName)
        {
            throw new NotImplementedException();
        }
    }
}
