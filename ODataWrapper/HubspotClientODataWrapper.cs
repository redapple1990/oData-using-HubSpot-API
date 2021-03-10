using HubSpot.NET.Api.Company;
using HubSpot.NET.Api.Company.Dto;
using HubSpot.NET.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ODataWrapper
{
    public class HubspotClientODataWrapper
    {
        public void CheckCompany()
        {
            HubSpotApi api = new HubSpotApi("ApiKey");
            testcompany(api);
        }

        public CompanySearchResultModel<CompanyHubSpotModel> GetCompany()
        {
            HubSpotApi api = new HubSpotApi("ApiKey");
            return GetCompanyByDomain(api);
        }

        public CompanyListHubSpotModel<CompanyHubSpotModel> GetCompanyByQuery(List<string> lst)
        {
            HubSpotApi api = new HubSpotApi("ApiKey");
            return GetCompanyMoreByQuery(api,lst);
        }

        private CompanySearchResultModel<CompanyHubSpotModel> GetCompanyByDomain(HubSpotApi api)
        {
            var companies = api.Company.GetByDomain("squaredup.com", new CompanySearchByDomain()
            {
                Limit = 10
            });

            return companies;
        }


        private CompanyListHubSpotModel<CompanyHubSpotModel> GetCompanyMoreByQuery(HubSpotApi api,List<string> lst)
        {
        //    [DataMember(Name = "companyId")]
        //    [IgnoreDataMember]
        //    public long? Id { get; set; }
        //    [DataMember(Name = "name")]
        //    public string Name { get; set; }
        //    [DataMember(Name = "domain")]
        //    public string Domain { get; set; }
        //    [DataMember(Name = "website")]
        //    public string Website { get; set; }
        //    [DataMember(Name = "description")]
        //    public string Description { get; set; }
        //    [DataMember(Name = "country")]
        //    public string Country { get; set; }
        //public bool IsNameValue { get; }

            //List<string> lstProperties = new List<string>();
            //lstProperties.Add("Name");

            ListRequestOptions lstRequestOptions = new ListRequestOptions();
            lstRequestOptions.PropertiesToInclude = lst;
            
            var companies = api.Company.List(lstRequestOptions);

            return companies;
        }

        private void testcompany(HubSpotApi api)
        {
            try
            {
                Tests(api);
                Console.WriteLine("Companies example completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Companies tests failed!");
                Console.WriteLine(ex.ToString());
            }
        }

        private static void Tests(HubSpotApi api)
        {
            /**
            * Create a company
            */
            var company = api.Company.Create(new CompanyHubSpotModel()
            {
                Domain = "squaredup.com",
                Name = "Squared Up"
            });

            /**
             * Update a company's property
             */
            company.Description = "Data Visualization for Enterprise IT";
            api.Company.Update(company);


            /**
             * Get all companies with domain name "squaredup.com"
             */
            var companies = api.Company.GetByDomain("squaredup.com", new CompanySearchByDomain()
            {
                Limit = 10
            });

            /**
             * Delete a contact
             */
            api.Company.Delete(company.Id.Value);

        }
    }
}
