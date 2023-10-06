// See https://aka.ms/new-console-template for more information
using ShiraSodaBot;
using System.Data;
using System.Net.Http;
using System.Text;

namespace ShiraMelonSoda
{
    public class Program
    {
        void Main(string[] args)
        {
            IAuthorizationHandler authorizationHandler = new ClientCredentailsAuthorization();
            Console.WriteLine("JD");
        }
    }

}