using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


        public async Task<List<float>> GetPriceTrend1Y(int itemID)
        {
            List<float> averages = new List<float>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "SELECT AVG(Total_value) AS Avg_Total_Value, " +
                    "FROM [CoreC].[dbo].[Item_price_history] " +
                    "WHERE Item_ID = @itemID " +
                    "AND Date_recorded >= DATEADD(MONTH, -11, CAST(GETDATE() AS DATE)) " +
                    "AND Date_recorded < CAST(GETDATE() AS DATE) " +
                    "GROUP BY YEAR(Date_recorded), MONTH(Date_recorded) " +
                    "ORDER BY YEAR(Date_recorded), MONTH(Date_recorded);",
                    connection))
                {
                    command.Parameters.AddWithValue("@itemID", itemID);
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

        public async Task<List<float>> GetPriceTrend6M(int itemID)
        {
            List<float> averages = new List<float>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "SELECT AVG(Total_value) AS Avg_Total_Value, " +
                    "FROM [CoreC].[dbo].[Item_price_history] " +
                    "WHERE Item_ID = @itemID " +
                    "AND Date_recorded >= DATEADD(MONTH, -5, CAST(GETDATE() AS DATE)) " +
                    "AND Date_recorded < CAST(GETDATE() AS DATE) " +
                    "GROUP BY YEAR(Date_recorded), MONTH(Date_recorded) " +
                    "ORDER BY YEAR(Date_recorded), MONTH(Date_recorded);",
                    connection))
                {
                    command.Parameters.AddWithValue("@itemID", itemID);
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

        public async Task<List<float>> GetPriceTrend3M(int itemID)
        {
            List<float> averages = new List<float>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "SELECT AVG(Total_value) AS Avg_Total_Value, " +
                    "FROM [CoreC].[dbo].[Item_price_history] " +
                    "WHERE Item_ID = @itemID " +
                    "AND Date_recorded >= DATEADD(MONTH, -2, CAST(GETDATE() AS DATE)) " +
                    "AND Date_recorded < CAST(GETDATE() AS DATE) " +
                    "GROUP BY YEAR(Date_recorded), MONTH(Date_recorded) " +
                    "ORDER BY YEAR(Date_recorded), MONTH(Date_recorded);",
                    connection))
                {
                    command.Parameters.AddWithValue("@itemID", itemID);
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

        public async Task<List<float>> GetPriceTrend1M(int itemID)
        {
            List<float> averages = new List<float>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "SELECT AVG(Total_value) AS Avg_Total_Value " +
                    "FROM [CoreC].[dbo].[Item_price_history] " +
                    "WHERE Item_ID = @itemID " +
                    "AND Date_recorded >= DATEADD(WEEK, -3, CAST(GETDATE() AS DATE)) " +
                    "AND Date_recorded < CAST(GETDATE() AS DATE) " +
                    "GROUP BY DATEPART(YEAR, Date_recorded), " +
                    "DATEPART(WEEK, Date_recorded) " +
                    "ORDER BY DATEPART(YEAR, Date_recorded), DATEPART(WEEK, Date_recorded);",
                    connection))
                {
                    command.Parameters.AddWithValue("@itemID", itemID);
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

        public async Task<List<float>> GetPriceTrend1W(int itemID)
        {
            List<float> averages = new List<float>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "SELECT AVG(Total_value) AS Avg_Total_Value " +
                    "FROM [CoreC].[dbo].[Item_price_history] " +
                    "WHERE Item_ID = @itemID " +
                    "AND Date_recorded >= DATEADD(DAY, -7, CAST(GETDATE() AS DATE)) " +
                    "AND Date_recorded < CAST(GETDATE() AS DATE) " +
                    "GROUP BY CAST(Date_recorded AS DATE) " +
                    "ORDER BY CAST(Date_recorded AS DATE);",
                    connection))
                {
                    command.Parameters.AddWithValue("@itemID", itemID);
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
