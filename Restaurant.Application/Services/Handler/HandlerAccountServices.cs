using AutoMapper;
using Restaurant.Domain.Dto;
using Restaurant.Domain.Repostiory;
using Restaurant.Domain.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services.Handler
{
    public class HandlerAccountServices : IHandlerAccountServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public HandlerAccountServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task SignOutAsync()
        {
            await _userRepository.SignOutAsync();
        }


        public async Task<UserInfoDto> GetInformationsAsync(string UserId)
        {
            var user = await _userRepository.GetCurrentUserAsync(UserId);

            var result = _mapper.Map<UserInfoDto>(user);

            return result;


        }

        public async Task<Response> GenerateEmailTokenAsync(string userId)
        {
            var user = await _userRepository.GenerateEmailTokenAsync(userId);

            return user;
        }
    }
}
