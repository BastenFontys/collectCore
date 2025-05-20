using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreDAL.Interfaces
{
    public interface IPricetrendRepo
    {
        public Task<List<float>> GetPriceTrend(int collectionID);
    }
}
