using CakeCompany.Models;
using CakeCompany.Models.Transport;
using CakeCompany.Provider.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Provider
{
    public class TransportProvider : ITransportProvider
    {
        public string CheckForAvailability(List<Product> products)
        {
            if (products.Sum(p => p.Quantity) < 1000)
            {
                return "Van";
            }

            if (products.Sum(p => p.Quantity) > 1000 && products.Sum(p => p.Quantity) < 5000)
            {
                return "Truck";
            }

            return "Ship";
        }
    

        public void TransportProducts(List<Product> products)
        {
        var transport = CheckForAvailability(products);

        if (transport == "Van")
        {
            var van = new Van();
            van.Deliver(products);
        }

        if (transport == "Truck")
        {
            var truck = new Truck();
            truck.Deliver(products);
        }

        if (transport == "Ship")
        {
            var ship = new Ship();
            ship.Deliver(products);
        }
    }
    }
}
