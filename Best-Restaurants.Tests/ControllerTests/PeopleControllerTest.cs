using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BestRestaurants.Controllers;

namespace Best_Restaurants.Tests
{
    [TestClass]
    public class PeopleControllerTest
    { 
        [TestMethod]
        public void AccountDetails_ReturnsCorrectView_True()
        {
            //Arrange
            PeopleController controller = new PeopleController();

            //Act
            ActionResult indexView = controller.AccountDetails(1);

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
    }
}
