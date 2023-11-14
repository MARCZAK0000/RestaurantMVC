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

            if(user is null)
            {
                throw new InvalidOperationException("Current user is unknown");
            }

            if (user.Identity is null || !user.Identity.IsAuthenticated)
            {
                return new CurrentUser(null!, null!, null!);
            }

            string? id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

            string? email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;

            var roles = user.Claims.Where(c=>c.Type == ClaimTypes.Role).Select(c=>c.Value);

            return new CurrentUser(id, email, roles);
        }
    }
}
