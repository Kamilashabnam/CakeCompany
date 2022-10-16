using CakeCompany.Provider;
using CakeCompany.Provider.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.UnitTests
{
    [TestFixture]
    public class ShipmentProviderTests
    {
        private readonly ShipmentProvider _sut;
        private readonly Mock<ITransportProvider> _transportProvider = new Mock<ITransportProvider>();
        private readonly Mock<ICakeProvider> _cakeProvider = new Mock<ICakeProvider>();
        private readonly Mock<IOrderProvider> _derProvider = new Mock<IOrderProvider>();
        private readonly Mock<IPaymentProvider> _paymentProvider = new Mock<IPaymentProvider>();

        public ShipmentProviderTests()
        {
            _sut= new ShipmentProvider(_derProvider.Object, _cakeProvider.Object, _transportProvider.Object,_paymentProvider.Object);
        }
        [Test]
        public void GetShipment_ShouldCallMethod_WhenInvoked()
        {
            //Test to ensure method is called
        }
        
    }
}
