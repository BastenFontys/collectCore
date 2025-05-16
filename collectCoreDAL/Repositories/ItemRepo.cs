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
    public class ItemRepo : IItemRepo
    {
        private readonly string _connectionString;

        public ItemRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<List<ItemDTO>> GetAllItems()
        {
            List<ItemDTO> items = new List<ItemDTO>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT Item_ID, Name, Value FROM [CoreC].[dbo].[Item];", connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ItemDTO item = new ItemDTO
                                {
                                    ItemID = (int)reader["Item_ID"],
                                    Name = reader["Name"].ToString(),
                                    ItemValue = Convert.ToSingle(reader["Value"])
                                };
                                items.Add(item);
                            }
                            return items;
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

        public async Task<List<ItemDTO>> GetItemsByCollectionID(int collectionID)
        {
            List<ItemDTO> items = new List<ItemDTO>();
            List<int> itemIDs = new List<int>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                using (SqlCommand command = new SqlCommand("SELECT Item_ID FROM [CoreC].[dbo].[Collection_item] WHERE Collection_ID = @collectionID;", connection))
                {
                    command.Parameters.AddWithValue("@collectionID", collectionID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemIDs.Add((int)reader["Item_ID"]);
                            }
                        }

                        if (itemIDs.Count == 0)
                        {
                            return null;
                        }

                        foreach (int itemID in itemIDs)
                        {
                            using (SqlCommand itemCommand = new SqlCommand("SELECT Item_ID, Name, Value FROM [CoreC].[dbo].[Item] WHERE Item_ID = @itemID;", connection))
                            {
                                itemCommand.Parameters.AddWithValue("@itemID", itemID);

                                using (SqlDataReader itemReader = itemCommand.ExecuteReader())
                                {
                                    if (itemReader.Read())
                                    {
                                        ItemDTO item = new ItemDTO
                                        {
                                            ItemID = (int)itemReader["Item_ID"],
                                            Name = itemReader["Name"].ToString(),
                                            ItemValue = Convert.ToSingle(itemReader["Value"])
                                        };
                                        items.Add(item);
                                    }
                                }
                            }
                        }

                        return items;
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
