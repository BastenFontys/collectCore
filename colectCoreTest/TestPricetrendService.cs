using collectCoreBLL.Services;
using collectCoreDAL.DTO;
using collectCoreDAL.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colectCoreTest
{
    public class TestPricetrendService
    {
        private readonly Mock<IItemRepo> _itemRepoMock;
        private readonly Mock<IPricetrendRepo> _priceTrendRepoMock;
        private readonly PriceTrendService _service;

        public TestPricetrendService()
        {
            _itemRepoMock = new Mock<IItemRepo>();
            _priceTrendRepoMock = new Mock<IPricetrendRepo>();
            _service = new PriceTrendService(_priceTrendRepoMock.Object, _itemRepoMock.Object);
        }

        //De onderstaande test is om te testen of mijn service class de juiste logica gebruikt om de gemiddeldes uit te rekenen.
        [Fact]
        public async Task GetPriceTrend_1Y_ReturnsCorrectAverages()
        {
            int collectionId = 1;

            var items = new List<ItemDTO>
            {
                new ItemDTO { ItemID = 1 },
                new ItemDTO { ItemID = 2 }
            };

            _itemRepoMock.Setup(repo => repo.GetItemsByCollectionID(collectionId)).ReturnsAsync(items);
            _priceTrendRepoMock.Setup(repo => repo.GetPriceTrend1Y(1)).ReturnsAsync(new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
            _priceTrendRepoMock.Setup(repo => repo.GetPriceTrend1Y(2)).ReturnsAsync(new List<float> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });


            var result = await _service.GetPriceTrend(collectionId, "1Y");


            Assert.Equal(12, result.Count);
            Assert.Equal(3, result[0]);
            Assert.Equal(5, result[1]);
            Assert.Equal(7, result[2]);
        }

        //De onderstaande test is om te testen of mijn service class default naar 1M als er een invalid range is.
        [Fact]
        public async Task GetPriceTrend_InvalidRange_Uses1MAsDefault()
        {
            int collectionId = 1;

            var items = new List<ItemDTO>
            {
                new ItemDTO { ItemID = 1 }
            };

            _itemRepoMock.Setup(repo => repo.GetItemsByCollectionID(collectionId)).ReturnsAsync(items);
            _priceTrendRepoMock.Setup(repo => repo.GetPriceTrend1M(1)).ReturnsAsync(new List<float> { 1, 1, 1, 1 });

            var result = await _service.GetPriceTrend(collectionId, "invalid");

            Assert.Equal(4, result.Count);
            foreach (var value in result)
            {
                Assert.Equal(1, value);
            }
        }

        //De onderstaande test is om te testen of mijn service class een juiste list (vol met nullen) terug geeft
        [Fact]
        public async Task GetPriceTrend_NoItems_ReturnsZeroList()
        {
            int collectionId = 1;

            _itemRepoMock.Setup(repo => repo.GetItemsByCollectionID(collectionId)).ReturnsAsync(new List<ItemDTO>());

            var result = await _service.GetPriceTrend(collectionId, "1Y");

            Assert.Equal(12, result.Count);
            foreach (var value in result)
            {
                Assert.Equal(0, value);
            }
        }

        //De onderstaande test is om te testen wat mijn service class doet als sommige items geen pricetrend heeft
        [Fact]
        public async Task GetPriceTrend_SomeTrendsNull_SkipsNulls()
        {
            int collectionId = 1;

            var items = new List<ItemDTO>
            {
                new ItemDTO { ItemID = 1 },
                new ItemDTO { ItemID = 2 }
            };

            _itemRepoMock.Setup(r => r.GetItemsByCollectionID(collectionId)).ReturnsAsync(items);

            _priceTrendRepoMock.Setup(r => r.GetPriceTrend1Y(1)).ReturnsAsync(new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
            _priceTrendRepoMock.Setup(r => r.GetPriceTrend1Y(2)).ReturnsAsync((List<float>?)null);


            var result = await _service.GetPriceTrend(collectionId, "1Y");


            Assert.Equal(12, result.Count);
            Assert.Equal(new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, result);
        }

        //De onderstaande test is om te testen wat mijn service class doet als items geen volledige pricetrend hebben
        [Fact]
        public async Task GetPriceTrend_ShorterTrendData_DoesNotCrash()
        {
            int collectionId = 1;

            var items = new List<ItemDTO>
            {
                new ItemDTO { ItemID = 1 },
                new ItemDTO { ItemID = 2 }
            };

            _itemRepoMock.Setup(r => r.GetItemsByCollectionID(collectionId)).ReturnsAsync(items);

            _priceTrendRepoMock.Setup(r => r.GetPriceTrend1Y(1)).ReturnsAsync(new List<float> { 1, 2, 3 }); // Shorter than 12
            _priceTrendRepoMock.Setup(r => r.GetPriceTrend1Y(2)).ReturnsAsync(new List<float> { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

            var result = await _service.GetPriceTrend(collectionId, "1Y");

            var expected = new List<float> { 5, 7, 9, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Assert.Equal(expected, result);

        }
    }
}
