using CakeCompany.Models;
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
     class PaymentProviderTests
    {
            [Test]
        public void Process_ShouldReturnPaymentInfo_WhenOrderPassed()
        {
            //Arrange
            var mockPaymentProvider = new Mock<IPaymentProvider>();
            
            Order order1 = new(ClientName: "ImportantCakeShop", EstimatedDeliveryTime: DateTime.Now, Id: 1, Name: Cake.RedVelvet, Quantity: 200);
            mockPaymentProvider.Setup(x => x.Process(order1)).Returns(new PaymentIn

            {
                HasCreditLimit = false,
                IsSuccessful = true
            });
            //Act
            var payment = mockPaymentProvider.Object;
            var result =payment.Process(order1);
            //Assert
            Assert.IsTrue(result.IsSuccessful);
        }
    }
}
