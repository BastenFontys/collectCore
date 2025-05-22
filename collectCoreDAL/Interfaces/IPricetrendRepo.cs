using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreDAL.Interfaces
{
    public interface IPricetrendRepo
    {
        public Task<List<float>> GetPriceTrend1Y(int collectionID);
        public Task<List<float>> GetPriceTrend6M(int collectionID);
        public Task<List<float>> GetPriceTrend3M(int collectionID);
        public Task<List<float>> GetPriceTrend1M(int collectionID);
        public Task<List<float>> GetPriceTrend1W(int collectionID);

    }
}
