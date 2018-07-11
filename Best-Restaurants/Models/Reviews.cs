using System;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BestRestaurants.Models
{
    public class Reviews
    {
        public int ReviewsId { get; set; }
        public int ReviewsRating { get; set; }
        public int PeopleId { get; set; }
        public int RestaurantId { get; set; }

        public Reviews(int Id, int reviewsRating, int peopleId, int restaurantId)
        {
            this.ReviewsId = Id;
            this.ReviewsRating = reviewsRating;
            this.PeopleId = peopleId;
            this.RestaurantId = restaurantId;
        }

        public Reviews(int reviewsRating, int peopleId, int restaurantId)
        {
            this.ReviewsRating = reviewsRating;
            this.PeopleId = peopleId;
            this.RestaurantId = restaurantId;
        }

        public override bool Equals(System.Object otherReviews)
        {
            if (!(otherReviews is Reviews))
            {
                return false;
            }
            else
            {
                Reviews newReviews = (Reviews)otherReviews;
                bool reviewsIdEquality = (this.ReviewsId == newReviews.ReviewsId);
                bool reviewsRatingEquality = (this.ReviewsRating == newReviews.ReviewsRating);
                bool peopleIdEquality = (this.PeopleId == newReviews.PeopleId);
                bool restaurantIdEquality = (this.RestaurantId == newReviews.RestaurantId);

                return (reviewsIdEquality && reviewsRatingEquality && peopleIdEquality && restaurantIdEquality);
            }
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM reviews;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Reviews> GetAll()
        {
            List<Reviews> allReviews = new List<Reviews> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM reviews;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int reviewsId = rdr.GetInt32(0);
                int reviewsRating = rdr.GetInt32(1);
                int peopleId = rdr.GetInt32(2);
                int restaurantId = rdr.GetInt32(3);

                Reviews newReviews = new Reviews(reviewsId, reviewsRating, peopleId, restaurantId);
                allReviews.Add(newReviews);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allReviews;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO reviews (rating, people_id, restaurant_id) VALUES (@ReviewsRating, @PeopleId, @RestaurantId);";

            cmd.Parameters.AddWithValue("@ReviewsRating", this.ReviewsRating);
            cmd.Parameters.AddWithValue("@PeopleId", this.PeopleId);
            cmd.Parameters.AddWithValue("@RestaurantId", this.RestaurantId);

            cmd.ExecuteNonQuery();
            this.ReviewsId = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
