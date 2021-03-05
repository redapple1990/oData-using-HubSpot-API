using Reference;
using System;
using System.Collections.Generic;

namespace ODataWrapper
{
    public class DataWrapper
    {
        public void GetOrderInfo()
        {
            var serviceRoot = "https://services.odata.org/V3/Northwind/Northwind.svc";
            var context = new NorthwindEntities(new Uri(serviceRoot));

            IEnumerable<Order> orders = context.Orders;
            foreach (var o in orders)
            {
                Console.WriteLine("{0} {1}", o.OrderID, o.ShipRegion);
            }
        }
    }
}
