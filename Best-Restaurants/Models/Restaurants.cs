using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace BestRestaurants.Models
{
    public class Restaurants
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int CuisineId { get; set; }

        public Restaurants(string restaurantName, int cuisineId, int Id = 0 )
        {
            this.RestaurantId = Id;
            this.RestaurantName = restaurantName;
            this.CuisineId = cuisineId;
        }

        public override bool Equals(System.Object otherRestaurant)
        {
            if (!(otherRestaurant is Restaurants))
            {
                return false;
            }
            else
            {
                Restaurants newRestaurant = (Restaurants)otherRestaurant;
                bool restaurantIdEquality = (this.RestaurantId == newRestaurant.RestaurantId);
                bool restaurantNameEquality = (this.RestaurantName == newRestaurant.RestaurantName);
                bool cuisineIdEquality = (this.CuisineId == newRestaurant.CuisineId);
                return (restaurantIdEquality && restaurantNameEquality && cuisineIdEquality);
            }
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM restaurants;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Restaurants> GetAll()
        {
            List<Restaurants> allRestaurants = new List<Restaurants> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restaurants;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int restaurantId = rdr.GetInt32(0);
                string restaurantName = rdr.GetString(1);
                int cuisineId = rdr.GetInt32(2);
                Restaurants newRestaurant = new Restaurants(restaurantName, cuisineId, restaurantId);
                allRestaurants.Add(newRestaurant);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allRestaurants;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO restaurants (name, cuisine_id) VALUES (@RestaurantName, @CuisineId);";

            cmd.Parameters.AddWithValue("@RestaurantName", this.RestaurantName);
            cmd.Parameters.AddWithValue("@CuisineId", this.CuisineId);


            cmd.ExecuteNonQuery();
            this.RestaurantId = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Restaurants Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `restaurants` WHERE id = @thisId;";

            cmd.Parameters.AddWithValue("@thisId", id);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int restaurantId = 0;
            string restaurantName = "";
            int cuisineId = 0;

            while (rdr.Read())
            {
                restaurantId = rdr.GetInt32(0);
                restaurantName = rdr.GetString(1);
                cuisineId = rdr.GetInt32(2);
            }

            Restaurants foundItem = new Restaurants(restaurantName, cuisineId, restaurantId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundItem;
        }

    }
}
