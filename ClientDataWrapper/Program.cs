using System;

namespace ClientDataWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataWrapper = new ODataWrapper.DataWrapper();
            dataWrapper.GetOrderInfo();
        }
    }
}
