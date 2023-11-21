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
        private readonly IDishesRepository _dishesRepository;

        private readonly IMapper _mapper;
        public DishesServicesHandler(IDishesRepository dishesRepository, IMapper mapper)
        {
            _dishesRepository = dishesRepository;
            _mapper = mapper;
        }

        public async Task<ShowDishes> GetDishAsync(string restaurantEncodedName, string encodedName)
        {
            var response = await _dishesRepository.GetDishAsync(restaurantEncodedName, encodedName);

             var result = _mapper.Map<ShowDishes>(response);

             return result;
                                     }

        public async Task<PaginationResponse<List<ShowDishes>>> GetRestaurantDishesAsync(string restaurantEncodedName, int PageSize, int PageNumber)
        {

            var response = new PaginationResponseBuilder<List<ShowDishes>>();
            var result = await _dishesRepository.ShowDishesAsync(restaurantEncodedName,PageSize, PageNumber);

            

            var mapResult = _mapper.Map<List<ShowDishes>>(result.Items);
            var totalCount = result.TotalItemsCount;

            return response
                .SetTotalCount(totalCount)
                .SetItemsTo(PageSize, PageNumber)
                .SetItemsFrom(PageSize, PageNumber)
                .SetPageParameters(totalCount, PageSize, PageNumber)
                .SetItems(mapResult)
                .Build();
        }
    }
}
