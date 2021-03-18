
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core

{
    public class Restaurant
    {
        public int Id { get; set; } // To use when storing in a database

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }


    }
}
