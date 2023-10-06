// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Net.Http;
using System.Text;
using ShiraSodaBot.Data;
using ShiraSodaBot.Models;
using System.Text.Json;

namespace ShiraMelonSoda
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            TwitchChatHandler twitchChat = new TwitchChatHandler(config["ApiSettings:oauth"], "cdawgva", "woworoo");

            string message;
            while(true)
            {
                message = twitchChat.ReadMessage().chatMessage;
                Console.WriteLine(message);
            }
        }
    }

}