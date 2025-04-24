using collectCore.Interfaces;
using collectCore.Models;
using Microsoft.Data.SqlClient;

namespace collectCore.Repos
{
    public class CollectionRepo : ICollectionRepo
    {
        private readonly string _connectionString;

        public CollectionRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Collection>> GetCollectionsByUserID(int id)
        {
            List<Collection> collections = new List<Collection>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT Collection_ID, Name FROM [CoreC].[dbo].[Collection] WHERE User_ID = @id;", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Collection collection = new Collection
                                {
                                    CollectionID = (int)reader["Collection_ID"],
                                    Name = reader["Name"].ToString()
                                };

                                collections.Add(collection);
                            }
                            if (collections.Count() > 0)
                            {
                                return collections;
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
