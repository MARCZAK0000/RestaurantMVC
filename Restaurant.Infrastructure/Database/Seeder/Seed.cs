using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Database.Seeder
{
    public class Seed : Data
    {

        private readonly RestaurantDatabaseContext _databaseContext;

        public Seed(RestaurantDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task DataSeeder()
        {
            if(await _databaseContext.Database.CanConnectAsync())
            {
                if(_databaseContext.Restautrants.Any()) 
                {
                    var result = GetRestautrants();

                    _databaseContext.AddRange(result);
                    await _databaseContext.SaveChangesAsync();
                }
            }
        }
    }
}
