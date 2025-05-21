using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using collectCoreDAL.DTO;
using collectCoreDAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace collectCoreDAL.Repositories
{
    public class PriceTrendRepo : IPricetrendRepo
    {
        private readonly string _connectionString;

        public PriceTrendRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<List<float>> GetPriceTrend(int collectionID)
        {
            List<float> averages = new List<float>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "SELECT AVG(Total_value) AS Avg_Total_Value " +
                    "FROM [CoreC].[dbo].[Collection_price_history] " +
                    "WHERE Collection_ID = 2 AND Date_recorded >= DATEADD(MONTH, -11, GETDATE()) " +
                    "AND Date_recorded < GETDATE() " +
                    "GROUP BY YEAR(Date_recorded), MONTH(Date_recorded) " +
                    "ORDER BY YEAR(Date_recorded), MONTH(Date_recorded)", 
                    connection))
                {
                    //command.Parameters.AddWithValue("@collectionID", collectionID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                float month = Convert.ToSingle(reader["Avg_Total_Value"]);
                                averages.Add(month);
                            }
                            return averages;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.WriteLine("stackTrace: " + ex.StackTrace);
                        return null;
                    }
                }
            }
        }
    }
}
