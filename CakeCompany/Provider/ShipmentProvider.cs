using CakeCompany.Provider.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Provider
{
    public class ShipmentProvider : IShipmentProvider
    {
        private readonly IOrderProvider _orderProvider;
        private readonly ICakeProvider _cakeProvider;
        private readonly ITransportProvider _transportProvider;
        private readonly IPaymentProvider _paymentProvider;

        public ShipmentProvider(IOrderProvider orderProvider, ICakeProvider cakeProvider, ITransportProvider transportProvider, IPaymentProvider paymentProvider)
        {
            _orderProvider = orderProvider;
            _cakeProvider = cakeProvider;
            _transportProvider = transportProvider;
            _paymentProvider = paymentProvider; 
        }
        public void GetShipment()
        {
            //Call order to get new orders 
            var orders = _orderProvider.GetOrders();
            
            //call to get the products by checking various conditions
            var products = _cakeProvider.GetProducts(orders,_paymentProvider);

            //call to transport the products
            _transportProvider.TransportProducts(products);
        }
    }
}
