using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infrastructure.Database;
using Restaurant.Infrastructure.HelperServices;
using Restaurant.Infrastructure.Repostiory;

namespace Restaurant.Infrastructure.Extension
{
    public static class ServicesExtension
    {

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantDatabaseContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("MyConnectionString"));
            }); //Register Database


            services.AddIdentity<IdentityUser, IdentityRole>(options=> 
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            })
            .AddEntityFrameworkStores<RestaurantDatabaseContext>()
            .AddDefaultTokenProviders(); //Register Microsoft Identity  and EFCore 



            services.AddScoped<Domain.Repostiory.IUserRepository, UserReposiotry>();

            services.AddScoped<Domain.HelperServices.IHelperServices, HelperServices.HelperServices>();
            services.AddScoped<Domain.Repostiory.IRestaurantRepository, RestaurantRepository>();


        }

       
    }
}
