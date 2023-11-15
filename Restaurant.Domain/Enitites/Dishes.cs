namespace Restaurant.Domain.Enitites
{
    public class Dishes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Describition { get; set; }    

        public decimal Price { get; set; }  

        public string DishEncodedName { get; private set; }

        public Restaurant? Restautrant { get; set; }

        public int? RestaurantID { get; set; }   

        public string DishEncodeName(string key) => DishEncodedName = key;
    }
}
