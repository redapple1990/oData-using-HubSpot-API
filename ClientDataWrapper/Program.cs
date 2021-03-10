using System;
using System.Collections.Generic;

namespace ClientDataWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataWrapper = new ODataWrapper.DataWrapper();
            dataWrapper.GetOrderInfo();

            var hubSopClient = new ODataWrapper.HubspotClientODataWrapper();
            hubSopClient.CheckCompany();

            List<string> lst = new List<string>();
            lst.Add("Name");
            lst.Add("domain");

            var queryCompanyByName = new ODataWrapper.HubspotClientODataWrapper();
            var results = hubSopClient.GetCompanyByQuery(lst);

            Console.WriteLine(results);
        }
    }
}
