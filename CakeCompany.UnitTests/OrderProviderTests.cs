using CakeCompany.Models;
using CakeCompany.Provider;
using CakeCompany.Provider.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.UnitTests
{
    [TestFixture]
    public class OrderProviderTests
    {
        
        [Test]
        //Test to return the orders
        public void GetLatestOrders_ShouldReturnOrder()
        {
            //Arrange
            var mockOrderProvider = new Mock<IOrderProvider>();
            mockOrderProvider.Setup(x => x.GetLatestOrders()).Returns(new Order[]
            {
            new("CakeBox", DateTime.Now, 1, Cake.RedVelvet, 120.25),
            new("ImportantCakeShop", DateTime.Now, 1, Cake.RedVelvet, 120.25)
            });
            //Act
            var order = mockOrderProvider.Object;
            var result =order.GetLatestOrders();
            //Assert
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public void GetOrders_WhenNewOrderIsAvailable_ShouldReturnOrder()
        {
            //Arrange
            var mockOrderProvider = new Mock<IOrderProvider>();
            mockOrderProvider.Setup(x => x.GetOrders()).Returns(new Order[]
            {
            new("CakeBox", DateTime.Now, 1, Cake.RedVelvet, 120.25)
            });
            //Act
            var order = mockOrderProvider.Object;
            var result = order.GetOrders();
            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GetOrders_WhenNewOrderIsNotAvailable_ShouldThrowException()
        {
            var mockOrderProvider = new Mock<IOrderProvider>();
            mockOrderProvider.Setup(x => x.GetOrders()).Throws (new ArgumentNullException());
            //Act
            var order = mockOrderProvider.Object;
            //Assert
            Assert.That(()=>order.GetOrders(),Throws
                .ArgumentNullException);
        }
    }
}
