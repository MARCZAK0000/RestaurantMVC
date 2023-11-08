using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Database
{
    public class RestaurantDatabaseContext : IdentityDbContext
    {
        public RestaurantDatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Domain.Enitites.Restaurant> Restautrants { get; set; }

        public DbSet<Dishes> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Domain.Enitites.Restaurant>()
                .OwnsOne(pr=>pr.ContactDetails);

            base.OnModelCreating(builder);
        }
    }
}
