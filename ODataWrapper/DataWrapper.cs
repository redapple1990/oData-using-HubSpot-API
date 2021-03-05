using Reference;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;

namespace ODataWrapper
{
    public class DataWrapper
    {
        const string serviceRoot = "https://services.odata.org/V3/Northwind/Northwind.svc";

        public void GetOrderInfo()
        {
            var context = new NorthwindEntities(new Uri(serviceRoot));

            var queryOrder = context.Orders;

            foreach (var o in ProcessOrder(queryOrder))
            {
                string customer = (o.Customer == null) ?
                                    "" : o.Customer.ContactName;
                Console.WriteLine("Order ID : {0} for the customer is {1}", o.OrderID, customer);
            }
        }

        public void GetOrderResponseByOrderID(string OrderID)
        {
            var context = new NorthwindEntities(new Uri(serviceRoot));
            var queryOrder = context.Orders.AddQueryOption("Order ID", OrderID);

            foreach (var o in ProcessOrder(queryOrder))
            {
                string customer = (o.Customer == null) ?
                                    "" : o.Customer.ContactName;
                Console.WriteLine("Order ID : {0} for the customer is {1}", o.OrderID, customer);
            }
        }

        private IEnumerable<Order> ProcessOrder(DataServiceQuery<Order> queryOrder)
        {
            IAsyncResult resultOrder = queryOrder.BeginExecute((res) =>
            {
                Console.WriteLine(res);
            }, null);

            IEnumerable<Order> objOrder = queryOrder.EndExecute(resultOrder);

            return objOrder;
        }
    }
}
