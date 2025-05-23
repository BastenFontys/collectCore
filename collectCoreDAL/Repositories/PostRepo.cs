using collectCoreDAL.DTO;
using collectCoreDAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreDAL.Repositories
{
    public class PostRepo : IPostRepo
    {
        private readonly string _connectionString;

        public PostRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<List<PostDTO>> GetAllPostsByUserID(int userID)
        {
            List<PostDTO> posts = new List<PostDTO>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT Post_ID, Post_image, ImageType, Caption, Date_posted FROM [CoreC].[dbo].[Post] WHERE User_ID = @userID;", connection))
                {
                    command.Parameters.AddWithValue("@userID", userID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PostDTO post = new PostDTO
                                {
                                    PostID = (int)reader["Post_ID"],
                                    ImageData = (byte[])reader["Post_image"],
                                    MimeType = reader["ImageType"].ToString(),
                                    Caption = reader["Caption"].ToString(),
                                    DatePosted = (DateOnly)reader["Date_posted"]
                                };

                                posts.Add(post);
                            }
                            if (posts.Count() > 0)
                            {
                                return posts;
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
