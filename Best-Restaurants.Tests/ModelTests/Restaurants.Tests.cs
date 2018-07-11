using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BestRestaurants.Models;

namespace Best_Restaurants.Tests
{
    [TestClass]
    public class RestaurantsTests : IDisposable
    {
        public void Dispose()
        {
            Restaurants.DeleteAll();
        }
        public RestaurantsTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restaurants_test;";
        }

        [TestMethod] 
        public void GetRestaurants_GetsSetsRestaurants_ReturnEqualValue()
        {
            Restaurants newRestaurants = new Restaurants("McDonalds", 1);
            newRestaurants.RestaurantName = "WalMart";

            Assert.AreEqual("WalMart", newRestaurants.RestaurantName);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
        {
            Restaurants firstItem = new Restaurants("Bob", 1);
            Restaurants secondItem = new Restaurants("Bob", 1);

            Assert.AreEqual(firstItem, secondItem);
        }

        [TestMethod]
        public void GetRestaurants_GetsSetsRestaurant_ReturnEqualValue()
        {
            Restaurants newRestaurant = new Restaurants("Taco Bell", 1);

            newRestaurant.Save();

            string nameResult = newRestaurant.RestaurantName;

            List<Restaurants> listResult = Restaurants.GetAll();
            List<Restaurants> actualRestaurantList = new List<Restaurants>() { newRestaurant };

            Assert.AreEqual("Taco Bell", nameResult);
            CollectionAssert.AreEqual(actualRestaurantList, listResult);
        }
    }
}
