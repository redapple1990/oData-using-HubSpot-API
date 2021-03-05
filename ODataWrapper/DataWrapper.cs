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

            var test = context.Orders;
            IAsyncResult resultOrder = test.BeginExecute((res) =>
            {
                Console.WriteLine(res);
            }, null);

            IEnumerable<Order> order = test.EndExecute(resultOrder);

            foreach(var o in order)
            {
                Console.WriteLine(o.CustomerID);
            }
        }

        public void GetOrderResponse()
        {

        }
    }
}
