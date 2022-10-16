using CakeCompany.Models;
using CakeCompany.Provider.Interface;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Provider
{
    public class CakeProvider : ICakeProvider
    {
        
        public Product Bake(Order order)
        {
            if (order.Name == Cake.Chocolate)
            {
                Log.Information("Chocolate cake is processing to bake");
                return new()
                {
                    Cake = Cake.Chocolate,
                    Id = new Guid(),
                    Quantity = order.Quantity
                };
            }

            if (order.Name == Cake.RedVelvet)
            {
                Log.Information("Redvelvet cake is processing to bake");
                return new()
                {
                    Cake = Cake.RedVelvet,
                    Id = new Guid(),
                    Quantity = order.Quantity
                };
            }
            Log.Information("Vanilla cake is processing to bake");
            return new()
            {
                Cake = Cake.Vanilla,
                Id = new Guid(),
                Quantity = order.Quantity
            }; ;
        }

        public DateTime Check(Order order)
        {
            Log.Information("Calculating delivery time");
                if (order.Name == Cake.Chocolate)
                {
                    return DateTime.Now.Add(TimeSpan.FromMinutes(30));
                }

                if (order.Name == Cake.RedVelvet)
                {
                    return DateTime.Now.Add(TimeSpan.FromMinutes(60));
                }

                return DateTime.Now.Add(TimeSpan.FromHours(15));
            }

        public List<Product> GetProducts(Order[] orders,IPaymentProvider paymentProvider)
        {
            var cancelledOrders = new List<Order>();
            var products = new List<Product>();


            foreach (var order in orders)
            {
                var estimatedBakeTime = Check(order);

                if (estimatedBakeTime > order.EstimatedDeliveryTime || !paymentProvider.Process(order).IsSuccessful)
                {
                    Log.Information("Baking is cancelled since it requires more bake time");
                    cancelledOrders.Add(order);

                }
                var product = Bake(order);
                products.Add(product);
            }

            return products;

        }
    }
}
