using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data;
using OdeToFood.Core;
using Microsoft.Extensions.Logging;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IRestaurantData restaurantData { get; }
        public ILogger<ListModel> logger { get; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, 
                         IRestaurantData restaurantData,
                          ILogger<ListModel> logger )
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }
        public void OnGet()
        {
            logger.LogError("Executing ListModel");
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
