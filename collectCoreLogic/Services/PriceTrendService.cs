using collectCoreBLL.Mappers;
using collectCoreDAL.DTO;
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
        private readonly IItemRepo _itemRepo;

        public PriceTrendService(IPricetrendRepo pricetrendRepo, IItemRepo itemRepo)
        {
            _pricetrendRepo = pricetrendRepo;
            _itemRepo = itemRepo;
        }

        public async Task<List<float>> GetPriceTrend(int collectionID, string range)
        {
            List<float> averages = new List<float>();
            var itemsbyid = await _itemRepo.GetItemsByCollectionID(collectionID);
            List<ItemDTO> items = new List<ItemDTO>(itemsbyid);

            if (range == "1Y")
            {
                float[] monthlyTotals = new float[12];

                foreach (ItemDTO item in items)
                {
                    var itemTrend = await _pricetrendRepo.GetPriceTrend1Y(item.ItemID);

                    if (itemTrend != null)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            monthlyTotals[i] += itemTrend[i];
                        }
                    }
                }

                return monthlyTotals.ToList();
            }
            else if(range == "6M")
            {
                float[] monthlyTotals = new float[6];

                foreach (ItemDTO item in items)
                {
                    var itemTrend = await _pricetrendRepo.GetPriceTrend6M(item.ItemID);

                    if (itemTrend != null)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            monthlyTotals[i] += itemTrend[i];
                        }
                    }
                }

                return monthlyTotals.ToList();
            }
            else if (range == "3M")
            {
                float[] monthlyTotals = new float[3];

                foreach (ItemDTO item in items)
                {
                    var itemTrend = await _pricetrendRepo.GetPriceTrend3M(item.ItemID);

                    if (itemTrend != null)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            monthlyTotals[i] += itemTrend[i];
                        }
                    }
                }

                return monthlyTotals.ToList();
            }
            else if (range == "1M")
            {
                float[] monthlyTotals = new float[4];

                foreach (ItemDTO item in items)
                {
                    var itemTrend = await _pricetrendRepo.GetPriceTrend1M(item.ItemID);

                    if (itemTrend != null)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            monthlyTotals[i] += itemTrend[i];
                        }
                    }
                }

                return monthlyTotals.ToList();
            }
            else if (range == "1W")
            {
                float[] monthlyTotals = new float[7];

                foreach (ItemDTO item in items)
                {
                    var itemTrend = await _pricetrendRepo.GetPriceTrend1W(item.ItemID);

                    if (itemTrend != null)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            monthlyTotals[i] += itemTrend[i];
                        }
                    }
                }

                return monthlyTotals.ToList();
            }
            else
            {
                float[] monthlyTotals = new float[4];

                foreach (ItemDTO item in items)
                {
                    var itemTrend = await _pricetrendRepo.GetPriceTrend1M(item.ItemID);

                    if (itemTrend != null)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            monthlyTotals[i] += itemTrend[i];
                        }
                    }
                }

                return monthlyTotals.ToList();
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
