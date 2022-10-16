using CakeCompany.Models;
using CakeCompany.Provider.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Provider
{
    public class OrderProvider : IOrderProvider
    {
        public Order[] GetLatestOrders()
        {
            Log.Information("Getting the latest orders");
            return new Order[]
            {
            new("CakeBox", DateTime.Now, 1, Cake.RedVelvet, 120.25),
            new("ImportantCakeShop", DateTime.Now, 1, Cake.RedVelvet, 120.25)
            };
        }

        public Order[] GetOrders()
        {
            var order = GetLatestOrders();
            if (!order.Any())
            {
                Log.Error("No orders passed");
                throw new ArgumentNullException();
            }

            else
                Log.Information("New order recieved");
                return order;
        }
    }
}
