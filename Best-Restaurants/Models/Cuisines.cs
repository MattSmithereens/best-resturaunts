using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BestRestaurants.Models
{
    public class Cuisines
    {
        public int CuisinesId { get; set; }
        public string CuisinesType { get; set; }

        public Cuisines(int Id, string CuisinesType)
        {
            this.CuisinesId = Id;
            this.CuisinesType = CuisinesType;
        }

        public Cuisines(string CuisinesType)
        {
            this.CuisinesType = CuisinesType;

        }

        public override bool Equals(System.Object otherCuisines)
        {
            if (!(otherCuisines is Cuisines))
            {
                return false;
            }
            else
            {
                Cuisines newCuisines = (Cuisines)otherCuisines;
                bool cuisinesIdEquality = (this.CuisinesId == newCuisines.CuisinesId);
                bool cuisinesTypeEquality = (this.CuisinesType == newCuisines.CuisinesType);
                return (cuisinesIdEquality && cuisinesTypeEquality);
            }
        }

        public static List<Cuisines> GetAll()
        {
            List<Cuisines> allCuisines = new List<Cuisines> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cuisines;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int cuisinesId = rdr.GetInt32(0);
                string cuisinesType = rdr.GetString(1);
                Cuisines newCuisines = new Cuisines(cuisinesId, cuisinesType);
                allCuisines.Add(newCuisines);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCuisines;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO cuisines (type) VALUES (@CuisinesType);";

            cmd.Parameters.AddWithValue("@CuisinesType", this.CuisinesType);


            cmd.ExecuteNonQuery();
            this.CuisinesId = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }




    }
}
