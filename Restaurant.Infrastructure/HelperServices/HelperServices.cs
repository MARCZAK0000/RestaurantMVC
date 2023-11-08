using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.HelperServices;
using Restaurant.Infrastructure.Database;

namespace Restaurant.Infrastructure.HelperServices
{
    public class HelperServices : IHelperServices
    {
        private readonly RestaurantDatabaseContext _restaurantDatabaseContext;

        public HelperServices(RestaurantDatabaseContext restaurantDatabaseContext)
        {
            _restaurantDatabaseContext = restaurantDatabaseContext;
        }

        public async Task<string> GetGeneratedRandomKeyAsync()
        {
            var getlist = await _restaurantDatabaseContext
                .Restautrants.
                Select(pr=>pr.EncodedName)
                .ToListAsync();


            var key = string.Empty;
            do
            {
                key = GenerateRandomKey();

            }while (getlist.Contains(key));
            return key;

        }


        private string GenerateRandomKey()
        {
            var chars = "abcdefghijklmnoprstuvwxyz0123456789";

            return new string(
                Enumerable.Repeat(chars, 12)
                .Select(s => s[Random.Shared.Next(chars.Length)])
                .ToArray()
                );
        }
    }
}
