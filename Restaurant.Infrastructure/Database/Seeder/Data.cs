using Restaurant.Domain.Enitites;

namespace Restaurant.Infrastructure.Database.Seeder
{
    public abstract class Data
    {


        protected static IEnumerable<Domain.Enitites.Restaurant> GetRestautrants() 
        {
            var result = new List<Domain.Enitites.Restaurant>() 
            {
                new Domain.Enitites.Restaurant()
                {
                    Name = "KFC",
                    Description = "Fast Food from America",
                    Type = Domain.Enums.RestaurantTypes.FastFood,
                    CreatedTime = DateTime.Now,
                    ContactDetails = new ContactDetails()
                    {
                        Street = "Aleja Wolnosci 37",
                        City = "Częstochowa",
                        PostalCode = "42-200",
                        PostalCity = "Częstochowa",
                        PhoneNumber = "+48152789852",
                        Email = "kfc-czestochowa-wolnosc@kfc.com",
                        Country = "Poland",
                    },

                    CreatedById = "TODOs",
                    Dishes = new List<Dishes>
                    {
                        new Dishes()
                        {
                            Name = "Kubełek Classic",
                            Describition = "2 kawałki kurczaka, 4 Hot Wings (pikantne skrzydełka), 4 Hot&Spicy Strips (pikantne polędwiczki), 2 x frytki 80g, dip",
                            Price = 51.99M
                        },
                        new Dishes()
                        {
                            Name = "Grander",
                            Describition = "Świeży, ręcznie panierowany kawałek kurczaka w dużej bułce sezamowej, bekon, żółty ser Cheddar, " +
                            "smakowita czerwona cebulka, świeża zielona sałata oraz aż dwa sosy: ostry BBQ i łagodny majonezowy. ",
                            Price = 27.99M
                        },
                        new Dishes()
                        {
                            Name = "Longer",
                            Describition = "Podłużna bułka wypełniona pyszną, chrupiącą polędwiczką, świeżą sałatą oraz odrobiną ketchupu",
                            Price = 9.99M
                        }
                    },

                    
                    
                }
            };

           

            return result;


        }
    }
}

//+48697927960