using System;
using MySql.Data.MySqlClient;
using Best_Restaurants;

namespace BestRestaurants.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}
