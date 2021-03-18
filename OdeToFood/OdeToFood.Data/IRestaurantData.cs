﻿using OdeToFood.Core;
using System.Collections.Generic;


namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        //  IEnumerable<Restaurant> GetAll(); //Met hod to get all restaurants
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Delete(int id);
        int Commit();
        int GetCountOfRestaurants();
    }
}
