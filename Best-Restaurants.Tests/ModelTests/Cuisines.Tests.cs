using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BestRestaurants.Models;

namespace Best_Restaurants.Tests
{
    [TestClass]
    public class CuisinesTest : IDisposable
    {
        public void Dispose()
        {
            Cuisines.DeleteAll();
        }
        public CuisinesTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restaurants_test;";
        }

        [TestMethod]
        public void GetCuisine_GetsSetsCuisines_ReturnEqualValue()
        {
            Cuisines newCuisines = new Cuisines("Chinese");
            newCuisines.CuisinesType = "Italian"; 

            Assert.AreEqual("Italian", newCuisines.CuisinesType);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
        {
            Cuisines firstItem = new Cuisines("French");
            Cuisines secondItem = new Cuisines("French");

            Assert.AreEqual(firstItem, secondItem);
        }

        [TestMethod]
        public void GetAll_GetsSetsAllCuisines_ReturnEqualValue()
        {
            Cuisines newCuisines = new Cuisines("Chinese");

            newCuisines.Save();

            List<Cuisines> listResult = Cuisines.GetAll();
            List<Cuisines> actualCuisinesList = new List<Cuisines>() { newCuisines };

            string typeResult = newCuisines.CuisinesType;

            Assert.AreEqual("Chinese", typeResult);
            CollectionAssert.AreEqual(actualCuisinesList, listResult);
        }
    }
}
