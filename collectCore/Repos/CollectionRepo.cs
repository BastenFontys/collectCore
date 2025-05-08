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


        public async Task<List<Collection>> GetCollectionsByUserID(int userID)
        {
            List<Collection> collections = new List<Collection>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT Collection_ID, Name FROM [CoreC].[dbo].[Collection] WHERE User_ID = @userID;", connection))
                {
                    command.Parameters.AddWithValue("@userID", userID);
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


        public async Task<Collection> GetCollectionByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT Collection_ID, Name FROM [CoreC].[dbo].[Collection] WHERE Collection_ID = @id;", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Collection
                                {
                                    CollectionID = (int)reader["Collection_ID"],
                                    Name = reader["Name"].ToString()
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


        public async Task<Collection> CreateCollection(int userID, string name)
        {
            int NewCollectionID;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO [CoreC].[dbo].[Collection] (User_ID, Name) VALUES (@userID, @name); SELECT CAST(SCOPE_IDENTITY() AS INT);", connection))
                    {
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@name", name);

                        NewCollectionID = (int)await command.ExecuteScalarAsync();
                    }
                }

                return await GetCollectionByID(NewCollectionID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("stackTrace: " + ex.StackTrace);
                return null;
            }
        }

        public void DeleteCollection(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DELETE FROM [CoreC].[dbo].[Collection] WHERE Collection_ID = @id;", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("stackTrace: " + ex.StackTrace);
            }
        }

        public void AddItemToCollection(int id, int itemid)
        {
            int NewCollectionID;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO [CoreC].[dbo].[Collection_item]] (Collection_ID, Item_ID) VALUES (@id, @itemID);", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@itemID", itemid);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("stackTrace: " + ex.StackTrace);
            }
        }
    }
}
