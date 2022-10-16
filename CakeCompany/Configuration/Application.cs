using CakeCompany.Provider.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Configuration
{
    public class Application : IApplication
    {
        IShipmentProvider _shipmentProvider;
        public Application(IShipmentProvider shipmentProvider)
        {
            _shipmentProvider = shipmentProvider;
        }

        public void Run()
        {
            Log.Information("Shipment Process started");
            _shipmentProvider.GetShipment();
        }
    }
}
