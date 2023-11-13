using Microsoft.EntityFrameworkCore;
using Restaurant.Application.ApplicationUser.ApplicationUser;
using Restaurant.Domain.Dto;
using Restaurant.Domain.HelperServices;
using Restaurant.Domain.PaginationResponse;
using Restaurant.Domain.ResponseHelper;
using Restaurant.Infrastructure.Database;

namespace Restaurant.Infrastructure.Repostiory
{
    public class RestaurantRepository : Domain.Repostiory.IRestaurantRepository
    {
        private readonly IUserContext _userContext;

        private readonly IHelperServices _helperServices;
        private readonly ResponseBuilder _response;

        private readonly RestaurantDatabaseContext _restaurantDatabaseContext;
        public RestaurantRepository(IUserContext userContext, RestaurantDatabaseContext restaurantDatabaseContext, IHelperServices helperServices)
        {
            _userContext = userContext;
            _response = new ResponseBuilder();
            _restaurantDatabaseContext = restaurantDatabaseContext;
            _helperServices = helperServices;
        }

        public async Task<Response> CreateRestaurantAsync(Domain.Enitites.Restaurant newRestaurant)
        {
            var getuser = _userContext.GetCurrentUser();

            if (getuser is null)
            {
                return _response.SetResult(false)
                    .SetMessage("Non authorize user")
                    .Build();
            }


            var restaurnat = new Domain.Enitites.Restaurant()
            {
                Name = newRestaurant.Name,
                Description = newRestaurant.Description,
                Type = newRestaurant.Type,
                ContactDetails = newRestaurant.ContactDetails,
                CreatedById = getuser.Id,
            };

            restaurnat.EncodeName(await _helperServices.GetGeneratedRandomKeyAsync());
            _restaurantDatabaseContext.Add(restaurnat);
            await _restaurantDatabaseContext.SaveChangesAsync();

            _restaurantDatabaseContext.SaveChangesFailed += restaurantDatabaseContext_SaveChangesFailed;

            return _response.SetResult(true)
                .SetMessage("Done")
                .Build();


        }


        public async Task<PaginationResponse<IEnumerable<Domain.Enitites.Restaurant>>> GetAllRestaurantAsync(int pageSize, int pageNumber, string querySearch)
        {
            var response = new PaginationResponseBuilder<IEnumerable<Domain.Enitites.Restaurant>>();
            var baseQuery = _restaurantDatabaseContext
                .Restautrants
                .Include(pr => pr.ContactDetails)
                .Where(pr => querySearch == null || pr.ContactDetails.City.ToLower().Contains(querySearch));

            var result = await baseQuery.
                 Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            var totalCount = baseQuery.Count();

            return response.SetItems(result)
                .SetTotalCount(totalCount)
                .Build();


        }

        public async Task<Domain.Enitites.Restaurant> GetRestautrantAsync(string encodeName)
        {
            var result = await _restaurantDatabaseContext.Restautrants
                .Include(pr => pr.ContactDetails)
                .FirstOrDefaultAsync(pr => pr.EncodedName.ToLower() == encodeName.ToLower());

            if (result is null)
            {
                throw new Exception("Not found");
            }

            return result;
        }


        public async Task<Response> EditRestaurantAsync(EditRestaurantDto edit, string encodedName)
        {
            var restaurant = _restaurantDatabaseContext
                .Restautrants
                .Include(pr => pr.ContactDetails)
                .FirstOrDefault(pr => pr.EncodedName == encodedName);

            if (restaurant is null)
            {
                return _response
                    .SetResult(false)
                    .SetMessage($"We can't find restaurant with that {encodedName}")
                    .Build();
            }

            if (edit.NewName is not null) restaurant.Name = edit.NewName;
            if (edit.NewDescription is not null) restaurant.Description = edit.NewDescription;
            restaurant.Type = edit.NewTypes;
            if (edit.NewStreet is not null) restaurant.ContactDetails.Street = edit.NewStreet;
            if (edit.NewCity is not null) restaurant.ContactDetails.City = edit.NewCity;
            if (edit.NewPostalCode is not null) restaurant.ContactDetails.PostalCode = edit.NewPostalCode;
            if (edit.NewPostalCity is not null) restaurant.ContactDetails.PostalCity = edit.NewPostalCity;
            if (edit.NewPhoneNumber is not null) restaurant.ContactDetails.PhoneNumber = edit.NewPhoneNumber;
            if (edit.NewEmail is not null) restaurant.ContactDetails.Email = edit.NewEmail;

            await _restaurantDatabaseContext.SaveChangesAsync();
            _restaurantDatabaseContext.SaveChangesFailed += restaurantDatabaseContext_SaveChangesFailed;

            return _response
                .SetResult(true)
                .Build();

        }


        private void restaurantDatabaseContext_SaveChangesFailed(object? sender, Microsoft.EntityFrameworkCore.SaveChangesFailedEventArgs e)
        {

            throw new Exception("Something went wrong");
        }

        public async Task<PaginationResponse<IEnumerable<Domain.Enitites.Restaurant>>> GetAllUserRestaurantsAsync(int pageSize, int pageNumber, string userID)
        {
            var response = new PaginationResponseBuilder<IEnumerable<Domain.Enitites.Restaurant>>();

            var baseQuery = _restaurantDatabaseContext
                .Restautrants
                .Include(pr => pr.ContactDetails)
                .Where(pr => pr.CreatedById!.ToLower() == userID.ToLower());


            var result = await baseQuery.
                Skip(pageSize * (pageNumber - 1))
               .Take(pageSize)
               .ToListAsync();

            var totalCount = baseQuery.Count();

            return response.SetItems(result)
                .SetTotalCount(totalCount)
                .Build();

        }
    }

}
