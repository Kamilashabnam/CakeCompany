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
    public class CakeProviderTests
    {
        [Test]
       
        [TestCase("ImportantCakeShop",1,Cake.RedVelvet,200,Cake.RedVelvet)]
        [TestCase("ImportantCakeShop", 1, Cake.Chocolate, 200, Cake.Chocolate)]
        [TestCase("ImportantCakeShop", 1, Cake.Vanilla, 200, Cake.Vanilla)]
        public void Bake_ShouldReturnProductOfSameOrder_WhenOrderGiven(string clientName,int id,Cake name, double quantity,Cake orderName)
        {
            var mockCakeProvider = new Mock<ICakeProvider>();
            Order order1 = new(clientName,EstimatedDeliveryTime:DateTime.Now,id,name,quantity);
            mockCakeProvider.Setup(x => x.Bake(order1)).Returns(new Product

            {
                Cake = orderName,
                Id = new Guid(),
                Quantity = order1.Quantity
            });
            //Act
            var cake = mockCakeProvider.Object;
            var result = cake.Bake(order1);
            //Assert
            Assert.That(result.Cake, Is.EqualTo(order1.Name));
        }
    }
}
