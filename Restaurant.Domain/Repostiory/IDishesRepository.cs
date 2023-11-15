using Restaurant.Domain.Dto;
using Restaurant.Domain.Enitites;
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
        Task<Response> CreateDishAsync(Dishes dish);

    }
}
