using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureADServiceClient
{
    class Program
    {
        private static readonly string Authority = ConfigurationManager.AppSettings["Authority"];
        private static readonly string Tenant = ConfigurationManager.AppSettings["Tenant"];
        private static readonly string ClientId = ConfigurationManager.AppSettings["ClientId"];
        private static readonly string AppKey = ConfigurationManager.AppSettings["AppKey"];

        private static readonly string ResourceId = ConfigurationManager.AppSettings["ResourceId"];
        private static readonly string BaseAddress = ConfigurationManager.AppSettings["BaseAddress"];

        static void Main(string[] args)
        {
            Process().Wait();
            Console.ReadLine();
        }

        private static async Task Process()
        {
            var authContext = new AuthenticationContext(string.Format(Authority, Tenant));
            var clientCredential = new ClientCredential(ClientId, AppKey);

            AuthenticationResult result = null;

            Console.WriteLine("Getting token...");
            try
            {
                result = authContext.AcquireToken(ResourceId, clientCredential);
            }
            catch (AdalException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }

            if (result == null)
            {
                Console.WriteLine("Error");
                return;
            }

            Console.WriteLine("Token: {0}", result.AccessToken);

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

            Console.WriteLine("Requesting service...");
            var response = await httpClient.GetAsync(BaseAddress + "/api/ListBooks");

            if (response.IsSuccessStatusCode)
            {
                var s = await response.Content.ReadAsStringAsync();
                s = s.Trim('"').Replace("\\r\\n", Environment.NewLine);
                Console.WriteLine("Response:");
                Console.Write(s);
            }
            else
            {
                Console.WriteLine("Error:  {0}", response.ReasonPhrase);
            }
        }
    }
}
