using collectCoreDAL.Interfaces;
using collectCoreDAL.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreDAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly string _connectionString;

        public UserRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }


        public async Task<UserDTO> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM [CoreC].[dbo].[User] WHERE User_ID = @id;", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new UserDTO
                                {
                                    UserID = (int)reader["User_ID"],
                                    Username = reader["Username"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    AdressStreet = reader["Adress_street"].ToString(),
                                    AdressNumber = (int)reader["Adress_number"],
                                    Biography = reader["Biography"].ToString()
                                };
                            }
                            else
                            {
                                return null;
                            }
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


        public async Task<UserDTO> GetByCredentialsAsync(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM [CoreC].[dbo].[User] WHERE Email = @email AND Password = @password", connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new UserDTO
                                {
                                    UserID = (int)reader["User_ID"],
                                    Username = reader["Username"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    AdressStreet = reader["Adress_street"].ToString(),
                                    AdressNumber = (int)reader["Adress_number"],
                                    Biography = reader["Biography"].ToString()
                                };
                            }
                            else
                            {
                                return null;
                            }
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

        public async Task<UserDTO> CreateUser(string username, string email, string password, string? adress_street, int adress_number)
        {
            int NewUserID;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO [CoreC].[dbo].[User] (Username, Email, Password, Adress_street, Adress_number) VALUES (@username, @email, @password, @adress_street, @adress_number); SELECT CAST(SCOPE_IDENTITY() AS INT);", connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        if (adress_street == null)
                        {
                            command.Parameters.AddWithValue("@adress_street", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@adress_street", adress_street);
                        }
                        command.Parameters.AddWithValue("@adress_number", adress_number);

                        NewUserID = (int)await command.ExecuteScalarAsync();
                    }
                }

                return await GetByIdAsync(NewUserID);
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
