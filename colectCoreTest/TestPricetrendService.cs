using collectCoreBLL.Services;
using collectCoreDAL.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colectCoreTest
{
    class TestPricetrendService
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
    }
}
