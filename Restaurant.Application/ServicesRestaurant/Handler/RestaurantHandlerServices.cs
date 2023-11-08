using AutoMapper;
using Restaurant.Domain.Dto;
using Restaurant.Domain.PaginationResponse;
using Restaurant.Domain.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ServicesRestaurant.Handler
{
    public class RestaurantHandlerServices : IRestaurantHandlerServices
    {
        private readonly Domain.Repostiory.IRestaurantRepository _restaurantRepository;

        private IMapper _mapper;

        public RestaurantHandlerServices(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;   
        }

        public async Task<PaginationResponse<List<GetRestaurantDto>>> GetAllRestaurantAsync(int pageSize, int pageNumber, string querySearch)
        {
            var response = await _restaurantRepository.GetAllRestaurantAsync(pageSize, pageNumber, querySearch);

            var mapResult = _mapper.Map <List<GetRestaurantDto>>(response.Items);

            var result = new PaginationResponseBuilder<List<GetRestaurantDto>>();

            var totalCount = response.TotalItemsCount;

            return result
            .SetItems(mapResult)
            .SetItemsFrom(pageSize, pageNumber)
            .SetItemsTo(pageSize, pageNumber)
            .SetPageParameters(totalCount, pageSize, pageNumber)
            .Build();
        }

        public async Task<PaginationResponse<List<GetRestaurantDto>>> GetAllUserRestaurantsAsync(int pageSize, int pageNumber, string userID)
        {
            var response = await _restaurantRepository.GetAllUserRestaurantsAsync(pageSize, pageNumber, userID);

            var mapResult = _mapper.Map <List<GetRestaurantDto>> (response.Items);

            var result = new PaginationResponseBuilder<List<GetRestaurantDto>>();
            var totalCount = response.TotalItemsCount;

            return result
            .SetItems(mapResult)
            .SetItemsFrom(pageSize, pageNumber)
            .SetItemsTo(pageSize, pageNumber)
            .SetPageParameters(totalCount, pageSize, pageNumber)
            .Build();

        }

        public async Task<ParticularGetRestaurantDto> GetRestaurantAsync(string encodeName)
        {
            var restautrant = await _restaurantRepository.GetRestautrantAsync(encodeName);

            var result = _mapper.Map<ParticularGetRestaurantDto>(restautrant);

            return result;
        }
    }
}
