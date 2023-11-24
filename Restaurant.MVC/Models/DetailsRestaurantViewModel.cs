using Restaurant.Domain.Dto;
using Restaurant.Domain.PaginationResponse;

namespace Restaurant.MVC.Models
{
    public class DetailsRestaurantViewModel
    {
        public DetailsRestaurantViewModel(PaginationResponse<List<ShowDishes>> listOfDishes, ParticularGetRestaurantDto restaurant)
        {
            ListOfDishes = listOfDishes;
            Restaurant = restaurant;
        }

        public PaginationResponse<List<ShowDishes>> ListOfDishes { get; set; }  

        public ParticularGetRestaurantDto Restaurant { get; set; }


        
    }
}
