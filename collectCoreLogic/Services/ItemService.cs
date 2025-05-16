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
    public class ItemService
    {
        private readonly IItemRepo _itemRepo;
        private ItemMapper _itemMapper;

        public ItemService(IItemRepo itemRepo, ItemMapper itemMapper)
        {
            _itemRepo = itemRepo;
            _itemMapper = itemMapper;
        }

        public async Task<List<Item>> GetAllItems()
        {
            List<Item> modelList = new List<Item>();
            var dtoList = await _itemRepo.GetAllItems();
            foreach (ItemDTO dto in dtoList)
            {
                modelList.Add(_itemMapper.ToModel(dto));
            }
            return modelList;
        }

        public async Task<List<Item>> GetItemsByCollectionID(int collectionID)
        {
            List<Item> modelList = new List<Item>();
            var dtoList = await _itemRepo.GetItemsByCollectionID(collectionID);
            foreach (ItemDTO dto in dtoList)
            {
                modelList.Add(_itemMapper.ToModel(dto));
            }
            return modelList;
        }
    }
}
