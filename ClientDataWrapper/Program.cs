using System;

namespace ClientDataWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var dataWrapper = new ODataWrapper.DataWrapper();
            dataWrapper.GetOrderInfo();
        }
    }
}
