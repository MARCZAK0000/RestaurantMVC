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


        public async Task<Response> EditDishAsync(string RestaurantEncodedName, string encodedName, EditDishDto edit) => await _dishesRepository.EditDishAsync(RestaurantEncodedName, encodedName, edit);
        
        public async Task<Response> DeleteDishAsync(string restaurantEncodedName, string dishEncodedName) => await _dishesRepository.DeleteDishAsync(restaurantEncodedName, dishEncodedName);

    }
}
