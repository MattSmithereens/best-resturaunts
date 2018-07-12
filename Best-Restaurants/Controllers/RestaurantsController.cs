using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestRestaurants.Controllers
{
    public class RestaurantsController : Controller
    {
        [HttpGet("/restaurants")]
        public ActionResult Index()
        {
            List<Restaurants> restaurantList = new List<Restaurants>{ };
            restaurantList = Restaurants.GetAll();
            return View(restaurantList);
        }

        [HttpPost("/restaurants")]
        public ActionResult NewRestaurant(string name, int cuisineId)
        {
            Restaurants newRestaurant = new Restaurants(name, cuisineId);
            newRestaurant.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/restaurants/add")]
        public ActionResult Create()
        {
            List<Cuisines> cuisinesList = new List<Cuisines> { };
            cuisinesList = Cuisines.GetAll();

            return View(cuisinesList);
        }
    }
}
