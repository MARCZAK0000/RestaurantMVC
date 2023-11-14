using Restaurant.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Repostiory
{
    public class DishesRepository : Domain.Repostiory.IDishesRepository
    {
        private readonly RestaurantDatabaseContext _databaseContext;

        public DishesRepository(RestaurantDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
