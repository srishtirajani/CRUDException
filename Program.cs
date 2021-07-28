using System;
using System.Data;
using System.Data.SqlClient;

namespace CRUDException
{
    public class PriceLessThan50Exception: Exception
    {
        public PriceLessThan50Exception(string message): base(message) { }
    }
    class Program
    {
        public static string connStr = @"Data Source=LAPTOP-IH3L07PH;Database=Assignment1DB;Integrated Security= true";
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(Program.connStr);
            SqlDataReader reader = null;
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Item; ", conn);
            try
            {
                reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    int val = Convert.ToInt32(reader[2].ToString());
                    if (val > 50)
                    {
                        throw (new PriceLessThan50Exception("Price must be less than 50"));
                    }
                    Console.WriteLine("{0}  {1}  {2}  {3}", reader[0], reader[1], reader[2], reader[3].ToString().Split()[0]);
                }
            }
            catch (PriceLessThan50Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
            
            conn.Close();
        }
    }
    public void viagit(){
    }

}
