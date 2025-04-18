using Microsoft.Data.SqlClient;
using collectCore.Models;
using collectCore.Interfaces;

namespace collectCore.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly string _connectionString;

        public UserRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }


        public async Task<User> GetByIdAsync(int id)
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
                                return new User
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


        public async Task<User> GetByCredentialsAsync(string email, string password)
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
                                return new User
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
    }
}
