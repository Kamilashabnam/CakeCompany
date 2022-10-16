using CakeCompany.Models;
using CakeCompany.Provider.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Provider
{
    public class PaymentProvider : IPaymentProvider
    {
        public PaymentIn Process(Order order)
        {
            if (order.ClientName.Contains("Important"))
            {
                return new PaymentIn
                {
                    HasCreditLimit = false,
                    IsSuccessful = true
                };
            }

            return new PaymentIn
            {
                HasCreditLimit = true,
                IsSuccessful = true
            };
        }
    }
}
