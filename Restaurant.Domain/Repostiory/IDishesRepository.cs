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
    public interface IDishesRepository
    {
        Task<Response> CreateDishAsync(Dishes dish, string EncodedName);

        Task<PaginationResponse<IEnumerable<Dishes>>> ShowDishesAsync(string restaurantEncodedName, int PageSize, int PageNumber);

        Task<Dishes> GetDishAsync(string restaurantEncodedName, string EncodedName);

        Task<Response> EditDishAsync(string restaurantEncodedName, string encodedName, EditDishDto edit);

        Task<Response> DeleteDishAsync(string restaurantEncodedName, string dishEncodedName);
    }
}
