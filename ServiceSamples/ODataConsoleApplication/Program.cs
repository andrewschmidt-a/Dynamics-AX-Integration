using AuthenticationUtility;
using Microsoft.OData.Client;
using ODataUtility.Microsoft.Dynamics.DataEntities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ODataConsoleApplication
{
    class Program
    {
        public static string ODataEntityPath = ClientConfiguration.Default.UriString + "data";
        static void Main(string[] args)
        {
            Uri oDataUri = new Uri(ODataEntityPath, UriKind.Absolute);
            var context = new Resources(oDataUri);
            string header = string.Empty;
            context.SendingRequest2 += new EventHandler<SendingRequest2EventArgs>(delegate (object sender, SendingRequest2EventArgs e)
            {
                var response = Task.Run(async () =>
                {
                    return await OAuthHelper.AuthorizationHeader();
                }
                );
                response.Wait();
                e.RequestMessage.SetHeader(OAuthHelper.OAuthHeader, response.Result.ToString());
            });
            Console.WriteLine("Here are the list of legal entities. ");
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var legaglEntity in context.LegalEntities.AsEnumerable())
            {
                Console.WriteLine("Name: {0}", legaglEntity.Name);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.WriteLine("Here are the list of all USMF Customers.");
            Console.WriteLine("------------------------------------------------------------------");
            DataServiceQuery<Customer> usmfCustomer = context.Customers.AddQueryOption("$filter", "dataAreaId eq 'USMF'").AddQueryOption("cross-company", "true");
            foreach (Customer cus in usmfCustomer)
            {
                Console.WriteLine(string.Format("Customer ID: {0}, Name: {1}, Company: {2}", cus.CustomerAccount, cus.Name, cus.DataAreaId));
            }
            Console.WriteLine("End of result. Press any key to close this window....");
            Console.ReadLine();
        }


    }
}
