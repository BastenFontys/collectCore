using collectCoreBLL.Mappers;
using collectCoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreBLL.Services
{
    public class PriceTrendService
    {
        private readonly IPricetrendRepo _pricetrendRepo;

        public PriceTrendService(IPricetrendRepo pricetrendRepo)
        {
            _pricetrendRepo = pricetrendRepo;
        }

        public async Task<List<float>> GetPriceTrend(int collectionID)
        {
            return await _pricetrendRepo.GetPriceTrend(collectionID);
        }
    }
}
