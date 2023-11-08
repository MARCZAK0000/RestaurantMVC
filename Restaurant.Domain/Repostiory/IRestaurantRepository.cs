using Restaurant.Domain.Dto;
using Restaurant.Domain.Enitites;
using Restaurant.Domain.PaginationResponse;
using Restaurant.Domain.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Repostiory
{
    public interface IRestaurantRepository
    {
        Task<Response> CreateRestaurantAsync(Enitites.Restaurant restautrant);

        Task<PaginationResponse<IEnumerable<Enitites.Restaurant>>> GetAllRestaurantAsync(int pageSize, int pageNumber, string querySearch);
        
        Task<PaginationResponse<IEnumerable<Enitites.Restaurant>>> GetAllUserRestaurantsAsync(int pageSize, int pageNumber, string userID);

        Task<Enitites.Restaurant> GetRestautrantAsync(string encodeName);

        Task<Response> EditRestaurantAsync(EditRestaurantDto edit, string encodedName);  
    }
}
