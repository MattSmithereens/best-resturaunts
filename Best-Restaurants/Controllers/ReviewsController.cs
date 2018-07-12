using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestRestaurants.Controllers
{
    public class ReviewsController : Controller
    {
        [HttpGet("/reviews")]
        public ActionResult Index()
        {
            List<Reviews> reviewList = new List<Reviews> { };
            reviewList = Reviews.GetAll();
            return View(reviewList);
        }

        [HttpPost("/reviews")]
        public ActionResult NewReview(int reviewsRating, int peopleId, int restaurantId)
        {
            Reviews newReview = new Reviews(reviewsRating, peopleId, restaurantId);
            newReview.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/reviews/add")]
        public ActionResult Create()
        {
            List<Cuisines> cuisinesList = new List<Cuisines> { };
            cuisinesList = Cuisines.GetAll();

            return View(cuisinesList);
        }
    }
}
