using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ApplicationUser.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser GetCurrentUser();
    }

    public class UserContext : IUserContext
    {

        private readonly IHttpContextAccessor _contextAccessord;

        public UserContext(IHttpContextAccessor contextAccessord)
        {
            _contextAccessord = contextAccessord;
        }


        public CurrentUser GetCurrentUser()
        {
            var user = _contextAccessord.HttpContext?.User;

            if (user.Identity.Name is null)
            {
                return new CurrentUser(null!, null!);
            }

            string? id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

            string? email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;


            return new CurrentUser(id, email);
        }
    }
}
