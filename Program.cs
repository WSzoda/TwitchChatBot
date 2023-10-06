// See https://aka.ms/new-console-template for more information
using ShiraSodaBot;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Net.Http;
using System.Text;

namespace ShiraMelonSoda
{
    public class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            IAuthorizationHandler authorizationHandler = new ClientCredentailsAuthorization(configuration);
            authorizationHandler.Authorize();
            Console.WriteLine("JD");
        }
    }

}