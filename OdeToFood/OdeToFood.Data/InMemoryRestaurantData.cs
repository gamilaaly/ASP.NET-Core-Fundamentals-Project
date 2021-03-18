using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;


namespace OdeToFood.Data
{
    // Creating a class that implements the IRestaurantData interface, we must implement al the data in the interface
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {   // This is a way of declaring the list and intialzing it in one step
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "New York", Cuisine = CuisineType.Indian},
                new Restaurant { Id = 2, Name = "Cinammon Club", Location = "London", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican }

            };
    }
        /**       public IEnumerable<Restaurant> GetAll()
               {
                   return from r in restaurants
                          orderby r.Name
                          select r;
               } 
        **/
        public int Commit()
        {
            return 0;
        }
        public Restaurant GetById (int id)
        {   
            //The id is unique, so it will return the single restaurant or a default null one
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name= null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name) // strats with allows us to search for total and sub matches
                   //if null, all restaurants will be returned
                   orderby r.Name
                   select r;
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        Restaurant IRestaurantData.Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}

