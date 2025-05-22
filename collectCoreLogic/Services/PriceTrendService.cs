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

        public async Task<List<float>> GetPriceTrend(int collectionID, string range)
        {
            if (range == "1Y")
            {
                return await _pricetrendRepo.GetPriceTrend1Y(collectionID);
            }
            else if(range == "6M")
            {
                return await _pricetrendRepo.GetPriceTrend6M(collectionID);
            }
            else if (range == "3M")
            {
                return await _pricetrendRepo.GetPriceTrend3M(collectionID);
            }
            else if (range == "1M")
            {
                return await _pricetrendRepo.GetPriceTrend1M(collectionID);
            }
            else if (range == "1W")
            {
                return await _pricetrendRepo.GetPriceTrend1W(collectionID);
            }
            else
            {
                return await _pricetrendRepo.GetPriceTrend1M(collectionID);
            }

        }

        public List<string> GetLabels(string range)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var labels = new List<string>();

            switch (range)
            {
                case "1W":
                    for (int i = 6; i >= 0; i--)
                    {
                        var day = today.AddDays(-i);
                        labels.Add(day.ToString("ddd"));
                    }
                    break;

                case "1M":
                    for (int i = 3; i >= 0; i--)
                    {
                        var week = today.AddDays(-7 * i);
                        labels.Add(week.ToString("MMM dd"));
                    }
                    break;

                case "3M":
                    for (int i = 2; i >= 0; i--)
                    {
                        var month = today.AddMonths(-i);
                        labels.Add(month.ToString("MMM"));
                    }
                    break;

                case "6M":
                    for (int i = 5; i >= 0; i--)
                    {
                        var month = today.AddMonths(-i);
                        labels.Add(month.ToString("MMM"));
                    }
                    break;

                case "1Y":
                    for (int i = 11; i >= 0; i--)
                    {
                        var month = today.AddMonths(-i);
                        labels.Add(month.ToString("MMM"));
                    }
                    break;

                default:
                    for (int i = 3; i >= 0; i--)
                    {
                        var week = today.AddDays(-7 * i);
                        labels.Add(week.ToString("MMM dd"));
                    }
                    break;
            }

            return labels;
        }
    }
}
