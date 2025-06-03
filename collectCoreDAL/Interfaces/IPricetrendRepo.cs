using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreDAL.Interfaces
{
    public interface IPricetrendRepo
    {
        public Task<List<float>> GetPriceTrend1Y(int itemID);
        public Task<List<float>> GetPriceTrend6M(int itemID);
        public Task<List<float>> GetPriceTrend3M(int itemID);
        public Task<List<float>> GetPriceTrend1M(int itemID);
        public Task<List<float>> GetPriceTrend1W(int itemID);

    }
}
