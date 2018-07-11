using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestRestaurants.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestRestaurants.Controllers
{
    public class FormsController : Controller
    {
        [HttpGet("/accounts/new")]
        public ActionResult NewAccountForm()
        {
            return View();
        }

        [HttpPost("/accounts")]
        public ActionResult CreateAccount(string name)
        {
            
            People newPeople = new People(name);
            newPeople.Save();

            return RedirectToAction("AccountDetails", new { peopleId = newPeople.PeopleId});
        }

        [HttpGet("/account")]
        public ActionResult AccountDetails(int peopleId)
        {
            
            return View(peopleId);
        }
    }
}
