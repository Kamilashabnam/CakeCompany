using CakeCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Provider.Interface
{
    public interface IPaymentProvider
    {
        public abstract PaymentIn Process(Order order);
    }
}
