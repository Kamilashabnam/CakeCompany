using CakeCompany.Provider.Interface;
using CakeCompany.Provider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Autofac;
using IContainer = Autofac.IContainer;
using Serilog;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CakeCompany.Configuration
{
    public class ContainerConfig
    {
        /*Implementing autofac setup - registering shipmentprovider whenever it looks for IShipmentProvider 
       interface the register type will return an instance of shipmentprovider class*/
        public static IContainer Configure()
        {
            Log.Information("Implementing autofac setup for dependency injection");
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ShipmentProvider>().As<IShipmentProvider>();
            builder.RegisterType<CakeProvider>().As<ICakeProvider>(); //can simply even more by register all types in a common assembly
            builder.RegisterType<TransportProvider>().As<ITransportProvider>();
            builder.RegisterType<OrderProvider>().As<IOrderProvider>();
            builder.RegisterType<PaymentProvider>().As<IPaymentProvider>();
            return builder.Build();
        }

    }
}
