using collectCoreDAL.DTO;
using collectCoreBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreBLL.Mappers
{
    public class PostMapper
    {
        public Post ToModel(PostDTO dto)
        {
            return new Post
            {
                PostID = dto.PostID,
                ImageData = dto.ImageData,
                MimeType = dto.MimeType,
                Caption = dto.Caption,
                DatePosted = dto.DatePosted
            };
        }

        public PostDTO ToDTO(Post model)
        {
            return new PostDTO
            {
                PostID = model.PostID,
                ImageData = model.ImageData,
                MimeType = model.MimeType,
                Caption = model.Caption,
                DatePosted = model.DatePosted
            };
        }
    }
}
