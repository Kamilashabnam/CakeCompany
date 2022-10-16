using CakeCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Provider.Interface
{
    public interface ITransportProvider
    {
        public abstract string CheckForAvailability(List<Product> products);
        public abstract void TransportProducts(List<Product> products);
    }
}
