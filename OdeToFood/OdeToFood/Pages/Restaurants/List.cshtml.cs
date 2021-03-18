using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; } // Public property to be able to fetch the restaurant's data to be viewed on the razor page

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        //public string SearchTerm { get; set; } // The one was used when we passed an argument for the onGet method

        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger) // Constructor for the ListModel class with an argument from 
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet( )
        {   // SearchTerm = seacrchTerm --> This line was used ehn using SearchTerm as an output model only without the Binding Property, and the value, name helpers in HTML instead of asp-for
            logger.LogError("Executing ListModel");
            //Message = "Hello, World!";
            Message = config["Message"]; //Getting the value of the Message Key in the conf JSON object (which appears in appsettings.json file)
            // Restaurants = restaurantData.GetAll();
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
