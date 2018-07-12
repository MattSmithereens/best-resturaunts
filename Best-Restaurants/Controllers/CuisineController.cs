﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestRestaurants.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestRestaurants.Controllers
{
    public class CuisineController : Controller
    {
        [HttpGet("/cuisines")]
        public ActionResult Index()
        {
            List<Cuisines> cuisineList = new List<Cuisines> { };
            cuisineList = Cuisines.GetAll();
            return View(cuisineList);
        }

        [HttpPost("/cuisines")]
        public ActionResult NewCuisine(string name, int cuisineId)
        {
            Cuisines newCuisine = new Cuisines(name, cuisineId);
            newCuisine.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/cuisines/add")]
        public ActionResult Create()
        {
            List<Cuisines> cuisinesList = new List<Cuisines> { };
            cuisinesList = Cuisines.GetAll();

            return View(cuisinesList);
        }

    }
}
