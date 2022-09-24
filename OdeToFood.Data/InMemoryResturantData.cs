using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 0, Name = "Li's Pizza", Location="Rome", Cuisine=CuisineType.Italian},
                new Restaurant { Id = 1, Name = "Shuang's Tacco", Location="Mexico City", Cuisine=CuisineType.Mexican},
                new Restaurant { Id = 2, Name = "Jennifer's Curry", Location="New Delhi", Cuisine=CuisineType.Indian},
            };
        }
        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in _restaurants
                   where string.IsNullOrWhiteSpace(name) ||r.Name.ToLower().StartsWith(name.ToLower())
                   orderby r.Name 
                   select r;
        }
        
        public Restaurant GetById(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _restaurants.Add(newRestaurant);
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int SaveChanges()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = _restaurants.SingleOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                _restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return _restaurants.Count();
        }
    }

}
