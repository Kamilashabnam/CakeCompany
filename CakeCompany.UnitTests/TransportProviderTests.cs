using CakeCompany.Models;
using CakeCompany.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.UnitTests
{
    [TestFixture]
    public class TransportProviderTests
    {
        [Test]
        public void CheckForAvailability_ShouldReturnVan_WhenSumOfQuantityIsLessThan1000()
        {
            //Arrange
            var transport = new TransportProvider();
            var listOfProducts = new List<Product>
            { new Product { Cake=Cake.RedVelvet, Id=new Guid(), Quantity=500},
              new Product { Cake=Cake.Chocolate, Id=new Guid(), Quantity=300 }
            };
            //Act
            var result = transport.CheckForAvailability(listOfProducts);
            //Assert
            Assert.That(result,Is.EqualTo("Van") );
        }

        [Test]
        public void CheckForAvailability_ShouldReturnTruck_WhenSumOfQuantityIsGreaterThan1000AndLessThan5000()
        {
            //Arrange
            var transport = new TransportProvider();
            var listOfProducts = new List<Product>
            { new Product { Cake=Cake.RedVelvet, Id=new Guid(), Quantity=500},
              new Product { Cake=Cake.Chocolate, Id=new Guid(), Quantity=2000 }
            };
            //Act
            var result = transport.CheckForAvailability(listOfProducts);
            //Assert
            Assert.That(result, Is.EqualTo("Truck"));
        }

        [Test]
        public void CheckForAvailability_ShouldReturnVan_WhenSumOfQuantityIsGreaterThan5000()
        {
            //Arrange
            var transport = new TransportProvider();
            var listOfProducts = new List<Product>
            { new Product { Cake=Cake.RedVelvet, Id=new Guid(), Quantity=5000},
              new Product { Cake=Cake.Chocolate, Id=new Guid(), Quantity=3000 }
            };
            //Act
            var result = transport.CheckForAvailability(listOfProducts);
            //Assert
            Assert.That(result, Is.EqualTo("Ship"));
        }
    }
}
