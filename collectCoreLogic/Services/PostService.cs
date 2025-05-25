using collectCoreBLL.Mappers;
using collectCoreBLL.Models;
using collectCoreDAL.DTO;
using collectCoreDAL.Interfaces;
using collectCoreDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreBLL.Services
{
    public class PostService
    {
        private readonly IPostRepo _postRepo;
        private PostMapper _postMapper;

        public PostService(IPostRepo postRepo, PostMapper postMapper)
        {
            _postRepo = postRepo;
            _postMapper = postMapper;
        }

        public async Task<List<Post>> GetAllPostsByUserID(int userID)
        {
            List<Post> modelList = new List<Post>();
            var dtoList = await _postRepo.GetAllPostsByUserID(userID);

            if (dtoList == null)
            {
                return null;
            }

            foreach (PostDTO dto in dtoList)
            {
                modelList.Add(_postMapper.ToModel(dto));
            }
            return modelList;
        }
    }
}
