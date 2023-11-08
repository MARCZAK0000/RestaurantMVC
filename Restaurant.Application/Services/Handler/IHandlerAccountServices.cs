using Restaurant.Domain.Dto;
using Restaurant.Domain.ResponseHelper;

namespace Restaurant.Application.Services.Handler
{
    public interface IHandlerAccountServices
    {
        Task<Domain.Dto.UserInfoDto>  GetInformationsAsync(string UserId);

        Task<Response> GenerateEmailTokenAsync(string userId);

        Task SignOutAsync();
    }
}