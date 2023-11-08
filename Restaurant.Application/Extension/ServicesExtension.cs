using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.ApplicationUser.ApplicationUser;
using Restaurant.Application.AutoMapperProfile;
using Restaurant.Application.Services.Command;
using Restaurant.Application.Services.Handler;
using Restaurant.Application.ServicesRestauran.Command;
using Restaurant.Application.ServicesRestaurant.Command;
using Restaurant.Application.ServicesRestaurant.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Extension
{
    public static class ServicesExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddValidatorsFromAssemblyContaining<Application.Services.Command.Validators.CreateAccValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            services.AddScoped<IUserContext, UserContext>();

            services.AddScoped<ICommandAccountServices, CommandAccountServices>();

            services.AddScoped<IHandlerAccountServices, HandlerAccountServices>();

            services.AddScoped<IRestaurantHandlerServices, RestaurantHandlerServices>();

            services.AddScoped<IRestaurantCommandServices, RestaurantCommandServices>();

        }
    }
}
