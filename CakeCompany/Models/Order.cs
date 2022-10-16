using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Models
{
    public record Order(string ClientName, DateTime EstimatedDeliveryTime, int Id, Cake Name, double Quantity);
}
