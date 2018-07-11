using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BestRestaurants.Models;

namespace Best_Restaurants.Tests
{
    [TestClass]
    public class PeopleTests : IDisposable
    {
        public void Dispose()
        {
            People.DeleteAll();
        }
        public PeopleTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restaurants_test;";
        }

        [TestMethod]
        public void GetCuisine_GetsSetsCuisines_ReturnEqualValue()
        {
            People newPeople = new People("Bob");
            newPeople.PeopleName = "Tim";

            Assert.AreEqual("Tim", newPeople.PeopleName);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
        {
            People firstItem = new People("Bob");
            People secondItem = new People("Bob");

            Assert.AreEqual(firstItem, secondItem);
        }

        [TestMethod]
        public void GetPeople_GetsSetsPeople_ReturnEqualValue()
        {
            People newPeople = new People("Ballstein");

            newPeople.Save();

            string nameResult = newPeople.PeopleName;

            List<People> listResult = People.GetAll();
            List<People> actualPeopleList = new List<People>() { newPeople };

            Assert.AreEqual("Ballstein", nameResult);
            CollectionAssert.AreEqual(actualPeopleList, listResult);
        }
    }
}
