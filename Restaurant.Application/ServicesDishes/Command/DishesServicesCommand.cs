using Restaurant.Domain.Dto;
using Restaurant.Domain.Repostiory;
using Restaurant.Domain.ResponseHelper;

namespace Restaurant.Application.ServicesDishes.Command
{
    public class DishesServicesCommand : IDishesServicesCommand
    {
        private readonly Domain.Repostiory.IDishesRepository _dishesRepository;
        public DishesServicesCommand(IDishesRepository dishesRepository)
        {
            _dishesRepository = dishesRepository;
        }

        public async Task<Response> CreateDishAsync(DishDto newDish, string RestaurantEncodedName)
        {
            var result =  await _dishesRepository.CreateDishAsync(new Domain.Enitites.Dishes()
            {
                Name = newDish.Name,
                Describition = newDish.Describition,
                Price = newDish.Price,
            }, RestaurantEncodedName);

            return result;
        }
    }
}
