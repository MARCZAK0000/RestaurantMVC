using Restaurant.Domain.Dto;
using Restaurant.Domain.Enitites;
using Restaurant.Domain.HelperServices;
using Restaurant.Domain.ResponseHelper;
using Restaurant.Infrastructure.Database;

namespace Restaurant.Infrastructure.Repostiory
{
    public class DishesRepository : Domain.Repostiory.IDishesRepository
    {
        private readonly RestaurantDatabaseContext _databaseContext;
        private readonly ResponseBuilder _response;
        private readonly IHelperServices _helperServices;

        public DishesRepository(RestaurantDatabaseContext databaseContext, IHelperServices helperServices)
        {
            _databaseContext = databaseContext;
            _response = new ResponseBuilder();
            _helperServices = helperServices;
            
        }

        public async Task<Response> CreateDishAsync(Dishes dish)
        {
            var key = await _helperServices.GetGeneratedRandomKeyAsync();
            dish.DishEncodeName(key);

            _databaseContext.Dishes.Add(dish);
            await _databaseContext.SaveChangesAsync();

            _databaseContext.SaveChangesFailed += _databaseContext_SaveChangesFailed;

            return _response.SetResult(true)
                .SetMessage("Dishes saved")
                .Build();
        }

        private void _databaseContext_SaveChangesFailed(object? sender, Microsoft.EntityFrameworkCore.SaveChangesFailedEventArgs e)
        {
            throw new Exception("Something went bad with saving dish to database");
        }
    }
}
