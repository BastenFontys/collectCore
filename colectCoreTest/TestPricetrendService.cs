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

    }
}
