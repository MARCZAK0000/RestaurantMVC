using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Dto;
using Restaurant.Domain.Enitites;
using Restaurant.Domain.HelperServices;
using Restaurant.Domain.PaginationResponse;
using Restaurant.Domain.Repostiory;
using Restaurant.Domain.ResponseHelper;
using Restaurant.Infrastructure.Database;
using Restaurant.Infrastructure.Migrations;

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

        public async Task<Response> CreateDishAsync(Dishes dish, string EncodedName)
        {
            var getRestaurant = await _databaseContext
                .Restautrants
                .FirstOrDefaultAsync(pr => pr.EncodedName.ToLower() == EncodedName.ToLower());

            if (getRestaurant == null)
            {
                return _response.SetResult(false)
                    .SetMessage("There is no restaurant with that encodedName")
                    .Build();
            }
                
            var newDish = new Dishes()
            {
                Name = dish.Name,
                Describition = dish.Describition,
                Price = dish.Price, 
                RestaurantID = getRestaurant.Id
            };
            var key = await _helperServices.GetGeneratedRandomKeyAsync();
            newDish.DishEncodeName(key);

            _databaseContext.Dishes.Add(newDish);
            await _databaseContext.SaveChangesAsync();

            _databaseContext.SaveChangesFailed += _databaseContext_SaveChangesFailed;

            return _response.SetResult(true)
                .SetMessage("Dishes saved")
                .Build();
        }

        

        public async Task<PaginationResponse<IEnumerable<Dishes>>> ShowDishesAsync(string restaurantEncodedName, int PageSize, int PageNumber)
        {
            var paginationResponse = new PaginationResponseBuilder<IEnumerable<Dishes>>();
            var restaurant = await _databaseContext.Restautrants.FirstOrDefaultAsync(pr => pr.EncodedName.ToLower() == restaurantEncodedName.ToLower());

            if (restaurant is null)
            {
                throw new Exception("Not Found restaurant");
            }

            var baseQuery = _databaseContext.Dishes
                .Include(pr => pr.Restautrant)
                .Where(pr => pr.RestaurantID == restaurant.Id);

            var result = await baseQuery.Skip(PageSize * (PageNumber  - 1)).Take(PageSize).ToListAsync();

            var TotalItemCount = baseQuery.Count();

            return paginationResponse
                .SetTotalCount(TotalItemCount)
                .SetItems(result)
                .Build();

        }


        public async Task<Dishes> GetDishAsync(string restaurantEncodedName, string EncodedName)
        {
            var dish = await _databaseContext.Dishes
                .Include(pr=>pr.Restautrant)
                .Where(pr=>pr.Restautrant!.EncodedName.ToLower() == restaurantEncodedName.ToLower())
                .FirstOrDefaultAsync(pr=>pr.DishEncodedName.ToLower() == EncodedName.ToLower());

            if(dish is null)
            {
                throw new Exception("Not found");
            }

             return dish;
          }


        private void _databaseContext_SaveChangesFailed(object? sender, Microsoft.EntityFrameworkCore.SaveChangesFailedEventArgs e)
        {
            throw new Exception("Something went bad with saving dish to database");
        }

        public async Task<Response> EditDishAsync(string restaurantEncodedName, string encodedName, EditDishDto edit)
        {
            var dish = await _databaseContext.Dishes
                .Include(pr => pr.Restautrant)
                .Where(pr => pr.Restautrant!.EncodedName.ToLower() == restaurantEncodedName.ToLower())
                .FirstOrDefaultAsync(pr => pr.DishEncodedName.ToLower() == encodedName.ToLower());

            if (dish is null)
            {
                _response
                    .SetMessage("We cannot find dish")
                    .SetResult(false)
                    .Build();
            }


            dish!.Price = edit.Price;
            await _databaseContext.SaveChangesAsync();
            _databaseContext.SaveChangesFailed += _databaseContext_SaveChangesFailed;

            return _response.SetMessage("Well done")
                .SetResult(true)
                .Build();
        }
    }
}
