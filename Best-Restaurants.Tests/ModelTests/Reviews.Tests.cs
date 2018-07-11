using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BestRestaurants.Models;

namespace Best_Restaurants.Tests
{
    [TestClass]
    public class ReviewsTests : IDisposable
    {
        public void Dispose()
        {
            Reviews.DeleteAll();
        }
        public ReviewsTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restaurants_test;";
        }

        [TestMethod]
        public void GetReviews_GetsSetsReviews_ReturnEqualValue()
        {
            Reviews newReviews = new Reviews(1, 1, 1);
            newReviews.ReviewsRating = 2;

            Assert.AreEqual(2, newReviews.ReviewsRating);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
        {
            Reviews firstItem = new Reviews(1, 2, 3);
            Reviews secondItem = new Reviews(1, 2, 3);

            Assert.AreEqual(firstItem, secondItem);
        }

        [TestMethod]
        public void GetPeople_GetsSetsReview_ReturnEqualValue()
        {
            Reviews newReview = new Reviews(1, 2, 3);

            newReview.Save();

            int ratingResult = newReview.ReviewsRating;

            List<Reviews> listResult = Reviews.GetAll();
            List<Reviews> actualReviewList = new List<Reviews>() { newReview };

            Assert.AreEqual(1, ratingResult);
            CollectionAssert.AreEqual(actualReviewList, listResult);
        }
    }
}
