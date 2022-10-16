using CakeCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Provider.Interface
{
    public interface ICakeProvider
    {
        public abstract DateTime Check(Order order);
        public abstract Product Bake(Order order);
        public abstract List<Product> GetProducts(Order[] orders, IPaymentProvider paymentProvider);
    }
}
